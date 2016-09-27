using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace WaybillParser
{
    public class WaybillParserImplemention
    {
        public int LengthOfFile;

        public void SendDataFromTheWaybill(string file, double PermissibleMass, string email)
        {
            string[,] ArrayOfWaybill = ParseWaybill(file);
            double sum = OrderPrice(ArrayOfWaybill);
            bool MassIsNormal = MassLessThanPermissible(ArrayOfWaybill, PermissibleMass);
            SendMail(LetterGeneration(sum, MassIsNormal), email);
        }

        public string[,] ParseWaybill(string file)
        {
            string[] ArrayLines = ParseLinesFromWaybillFile(file);
            string[,] ArrayOfWaybill = new string[LengthOfFile, 5];
            for (var i = 0; i < LengthOfFile; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    var tempArray = ArrayLines[i].Split('|');
                    ArrayOfWaybill[i, j] = tempArray[j];
                }
            }
            return ArrayOfWaybill;
        }

        public string[] ParseLinesFromWaybillFile(string file)
        {
            var readFile = File.ReadAllLines(file);
            List<string> list = readFile.ToList();
            string[] ArrayLines = list.ToArray();
            LengthOfFile = ArrayLines.Length;
            return ArrayLines;
        }

        public double OrderPrice(string[,] ArrayOfWaybill)
        {
            double sum = 0;
            for (var i = 0; i < LengthOfFile - 1; i++)
            {
                sum = sum + Convert.ToDouble(ArrayOfWaybill[i + 1, 4]);
            }
            return sum;
        }
        public double EntireMass (string[,] ArrayOfWaybill)
        {
            double EntireMass = 0;
            for (var i = 0; i < LengthOfFile - 1; i++)
            {
                EntireMass = EntireMass + Convert.ToDouble(ArrayOfWaybill[i + 1, 3]);
            }
            return EntireMass;
        }

        public bool MassLessThanPermissible(string[,] ArrayOfWaybill, double PermissibleMass)
        {
            if (EntireMass(ArrayOfWaybill) < PermissibleMass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string LetterGeneration(double sum, bool massIsNormal)
        {
            string temp;
            if (massIsNormal)
            {
                temp = "Масса заказа не превышает допустимую";
            }
            else temp = "Масса заказа превышает допустимую";
            return "Общая сумма заказа: " + sum + "\n" + temp;
        }

        public void SendMail(string letter, string email)
        {
            try
            {
                using (MailMessage mm = new MailMessage("Bot <test1l1@yandex.ru>", email))
                {
                    mm.Subject = "Накладная";
                    mm.Body = letter;
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("test1l1@yandex.ru", "1qaz2ws");
                        sc.Send(mm);
                    }
                }
            }
            catch (SmtpException)
            { }
        }
    }
}

using System;

namespace EquationSolver
{
    public class EquationSolverImplemention
    {
        public double[] SolveEquation(string equation)
        {
            var numbers = ParseEquation(equation);
            return SolveEquation(numbers[0], numbers[1], numbers[2]);
        }

        public double[] ParseEquation(string equation)
        {
            equation = equation.ToLower().Replace("^2", "").Replace('*', '\0');
            var abc = equation.Split('x');
            abc[2] = abc[2].Remove(abc[2].IndexOf('='), abc[2].Length - abc[2].IndexOf('=')); // Удаляем "=0"
            return new[] { Convert.ToDouble(abc[0]), Convert.ToDouble(abc[1]), Convert.ToDouble(abc[2]) };
        }

        public double[] SolveEquation(double a, double b, double c)
        {
            var discriminant = CountDiscriminant(a, b, c);
            var countRoots = CountEquationRoots(discriminant);
            double[] arrayElements;
            switch (countRoots)
            {
                case 2:
                    arrayElements = new double[2];
                    arrayElements[0] = CountFirstRoot(a, b, discriminant);
                    arrayElements[1] = CountSecondRoot(a, b, discriminant);
                    break;
                case 1:
                    arrayElements = new double[1];
                    arrayElements[0] = CountSingleRoot(a, b);
                    break;
                default:
                    arrayElements = new double[0];
                    break;
            }
            return arrayElements;
        }

        public int CountDiscriminant(double a, double b, double c)
        {
            return Convert.ToInt32(b * b - 4 * a * c);
        }

        public int CountEquationRoots(int discriminant)
        {
            if (discriminant > 0)
            {
                return 2;
            }
            else if (discriminant == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public double CountSingleRoot(double a, double b)
        {
            return -b / (2 * a);
        }

        public double CountFirstRoot(double a, double b, int discriminant)
        {
            return ((-b + Math.Sqrt(discriminant)) / (2 * a));
        }

        public double CountSecondRoot(double a, double b, int discriminant)
        {
            return ((-b - Math.Sqrt(discriminant)) / (2 * a));
        }
    }
}

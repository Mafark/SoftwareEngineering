using Microsoft.VisualStudio.TestTools.UnitTesting;
using EquationSolver;
using System.Linq;

namespace EquationSolverTests
{
    [TestClass]
    public class EquationSolverTests
    {
        [TestMethod]
        public void CountDiskriminant_SatisfiesAlgorithm()
        {
            var equationSolver = new EquationSolverImplemention();
            var a = 3;
            var b = 5;
            var c = 2;
            var expectedDiscriminant = 1;
            var discriminant = equationSolver.CountDiscriminant(a, b, c);
            Assert.AreEqual(expectedDiscriminant, discriminant);
        }

        [TestMethod]
        public void CountSquareRootsForNegativeDiscriminator_ReturnsZero()
        {
            var equationSolver = new EquationSolverImplemention();
            var discriminant = -2;
            var expectedCount = 0;
            var count = equationSolver.CountEquationRoots(discriminant);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void CountSquareRootsForPositiveDiscriminator_ReturnsTwo()
        {
            var equationSolver = new EquationSolverImplemention();
            var discriminant = 2;
            var expectedCount = 2;
            var count = equationSolver.CountEquationRoots(discriminant);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void CountSquareRootsForZeroDiscriminator_ReturnsOne()
        {
            var equationSolver = new EquationSolverImplemention();
            var discriminant = 0;
            var expectedCount = 1;
            var count = equationSolver.CountEquationRoots(discriminant);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void CountFirstRoot_ReturnsTrue()
        {
            var equationSolver = new EquationSolverImplemention();
            var a = 1;
            var b = 1;
            var discriminant = 9;
            var expectedCount = 1;
            var count = equationSolver.CountFirstRoot(a, b, discriminant);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void CountSecondRoot_ReturnsTrue()
        {
            var equationSolver = new EquationSolverImplemention();
            var a = 1;
            var b = 4;
            var discriminant = 4;
            var expectedCount = -3;
            var count = equationSolver.CountSecondRoot(a, b, discriminant);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void CountSingleRoot_ReturnsTrue()
        {
            var equationSolver = new EquationSolverImplemention();
            var a = 1;
            var b = 2;
            double expectedCount = -1;
            var count = equationSolver.CountSingleRoot(a, b);
            Assert.IsTrue(expectedCount == count);
        }

        [TestMethod]
        public void SolveEquation_GetRoots_ReturnsTrue()
        {
            var equationSolver = new EquationSolverImplemention();
            var a = 1;
            var b = 3;
            var c = 2;
            double[] expectedArray = { -1, -2 };
            var resultingArray = equationSolver.SolveEquation(a, b, c);
            Assert.IsTrue(expectedArray.SequenceEqual(resultingArray));
        }
        [TestMethod]
        public void ParseEquation_GetVariables_ReturnsTrue()
        {
            var equationSolver = new EquationSolverImplemention();
            double[] expectedArray = { 12, 3, -2 }; 
            var resultingArray = equationSolver.ParseEquation("12x^2+3*x-2=0");
            Assert.IsTrue(expectedArray.SequenceEqual(resultingArray));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MiniCalculator.Application;
namespace MiniCalculator.NUnitTests
{
    [TestFixture] 
    public class Tests
    {
        MyIntType a = new MyIntType();
        MyIntType b = new MyIntType();
        MyIntType result = new MyIntType();
        #region ConstructorTests
        [Test()]
        public void ConstructorMyIntType_GoodData_GoodResult()
        {
            MyIntType a = new MyIntType(4);
            Assert.AreEqual(a.value, 4);
        }

        [Test(), ExpectedException(typeof(OverflowException))]
        public void ConstructorMyIntType_BadData_OverflowException()
        {
            MyIntType a = new MyIntType(50);
        }
        #endregion
        #region PropetyMyIntTypeTest
        [Test(), ExpectedException(typeof(OverflowException))]
        public void PropetyMyIntType_BadData_OverflowException()
        {
            a.value = 37;
        }
        #endregion
        #region AdditionTests
        [Test()]
        public void AddTwoNumber_GoodData_GoodResult()
        {
            a.value = 7;
            b.value = 7;
            result.value = 14;
            Assert.AreEqual(MyCalculator.PerformOperation(1, a, b), result);
        }
        [Test()]
        public void AddTwoNumber_GoodData_BadResult()
        {
             a.value = 36;
             b.value = 7;
             result.value = 0;
            Assert.AreEqual(MyCalculator.PerformOperation(1, a, b),result);
        }
    
#endregion
        #region SubstractionTests
        [Test()]
        public void SubTwoNumber_GoodData_GoodResult()
        {
            a.value = 3;
            b.value = 1;
            result.value = 2;
            Assert.AreEqual(MyCalculator.PerformOperation(2, a, b), result);
        }
        [Test()]
        public void SubTwoNumber_GoodData_BadResult()
        {
            a.value = 0;
            b.value = 10;
            result.value = 33;
            Assert.AreEqual(MyCalculator.PerformOperation(2, a, b), result);
        }
#endregion
        #region MultiplicationTests
        [Test()]
        public void Multiplication_GoodData_GoodResult()
        {
            a.value = 3;
            b.value = 1;
            result.value = 3;
            Assert.AreEqual(MyCalculator.PerformOperation(3, a, b), result);
        }
        [Test()]
        public void Multiplication_GoodData_BadResult()
        {
            a.value = 3;
            b.value = 13;
            result.value = -4;
            Assert.AreEqual(MyCalculator.PerformOperation(3, a, b), result);
        }
#endregion
        #region DivitionTests
        [Test()]
        public void Division_GoodData_GoodResult()
        {
            a.value = 3;
            b.value = 1;
            result.value = 3;
            Assert.AreEqual(MyCalculator.PerformOperation(4, a, b), result);
        }
        [Test()]
        public void Division_GoodData_BadResult()
        {
            a.value = 36;
            b.value = -3;
            result.value = 31;
            Assert.AreEqual(MyCalculator.PerformOperation(4, a, b), result);
        }
        [Test(), ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest_ZeroDenominator_DivideByZeroException()
        {
            a.value = 3;
            b.value = 0;
            MyCalculator.PerformOperation(4, a, b);
        }
        #endregion
        #region OperationTests
        [Test(), ExpectedException(typeof(ArgumentException))]
        public void OperationTest_WrongOperation_ArgumentException()
        {
            MyCalculator.PerformOperation(5, a, b);
        }

        [Test()]
        public void OperationTest_ExistOperation_True()
        {
            Assert.AreEqual(MyCalculator.isCorrectOperation(1),true);
        }

        [Test()]
        public void OperationTest_WrongOperation_False()
        {
            Assert.AreEqual(MyCalculator.isCorrectOperation(6), false);
        }
#endregion
    }
}

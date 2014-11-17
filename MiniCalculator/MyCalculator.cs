using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiniCalculator.Application
{
    public class MyCalculator
    {
        // словарь операций
        static Dictionary<int, Func<MyIntType, MyIntType, MyIntType>> _operations =
            new Dictionary<int, Func<MyIntType, MyIntType, MyIntType>>
            {
                {1, Addition},
                {2, Subtracting},
                {3, Multiplication},
                {4, Division}
            };

        /// <summary>
        /// Проверяет существует ли данная операция
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool isCorrectOperation(int operation)
        {
            return _operations.ContainsKey(operation);;
        }
        
        public static MyIntType PerformOperation(int operation, MyIntType a, MyIntType b)
        {
            if(!isCorrectOperation(operation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", operation));
            return _operations[operation](a, b);
        }

        static private MyIntType Addition(MyIntType a, MyIntType b)
        {
            return a + b;
        }
        static private MyIntType Subtracting(MyIntType a, MyIntType b)
        {
            return a - b;
        }
        static private MyIntType Multiplication(MyIntType a, MyIntType b)
        {
            return a * b;
        }
        static private MyIntType Division(MyIntType a, MyIntType b)
        {
            return a / b;
        }
    }
}

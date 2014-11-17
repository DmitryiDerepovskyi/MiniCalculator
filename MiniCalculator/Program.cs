using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculator.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // exit отвечает за выход из цикла
            bool exit = false;
            int numberOperation, operand1, operand2;
            MyIntType firstOperand, secondOperand;
            while (!exit)
            {
                Console.WriteLine("Input operation\n" +
                    "1.Addition\n" +
                    "2.Subtracting\n" +
                    "3.Multiplication\n" +
                    "4.Division");
                try
                { 
                    numberOperation = Convert.ToInt32(Console.ReadLine()); 
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (!MyCalculator.isCorrectOperation(numberOperation))
                {
                    Console.WriteLine("Incorrect number of operation");
                    continue;
                }
                try
                { 
                    Console.WriteLine("Input first operand");
                    operand1 = Convert.ToInt32(Console.ReadLine());
                    firstOperand = new MyIntType(operand1);
                    Console.WriteLine("Input second operand");
                    operand2 = Convert.ToInt32(Console.ReadLine());
                    secondOperand = new MyIntType(operand2);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                } 
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // нахождение результата 
                try
                {
                    Console.WriteLine("Result {0}", MyCalculator.PerformOperation(numberOperation, firstOperand, secondOperand));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Continue?(Y/N)");
                char choose = (char)Console.Read();
                if (Char.ToLower(choose) == 'n')
                    exit = true;
            }
        }
    }
}

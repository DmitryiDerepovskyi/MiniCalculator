using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculator.Application
{
    public class MyIntType
    {
        public MyIntType()
        {
            this.value = (MAX_VALUE + MIN_VALUE) / 2;
        }

        public MyIntType(int value)
        {
            this.value = value;
        }

        public const int MIN_VALUE = -7;
        public const int MAX_VALUE = 36;
        private int _value;

        public int value
        {
            get{ return _value;}
            set {
                if (value > MAX_VALUE || value < MIN_VALUE)
                    throw new OverflowException(string.Format("Overflow! {0} does not belong to the range [{1}; {2}]", 
                        value, MIN_VALUE, MAX_VALUE));
                else
                    _value = value;
            }
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        public override  bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            MyIntType p = obj as MyIntType;
            if ((System.Object)p == null)
            {
                return false;
            }
        // Return true if the fields match:
               return _value == p.value;
        }

        #region overload operator
        public static MyIntType operator +(MyIntType a, MyIntType b)
        {
            return new MyIntType(OverflowHandling(a.value + b.value));
        }
        public static MyIntType operator -(MyIntType a, MyIntType b)
        {
            return new MyIntType(OverflowHandling(a.value - b.value));
        }
        public static MyIntType operator *(MyIntType a, MyIntType b)
        {
            return new MyIntType(OverflowHandling(a.value * b.value));
        }
        public static MyIntType operator /(MyIntType a, MyIntType b)
        {
            if (b.value == 0)
                throw new DivideByZeroException();
            return new MyIntType(OverflowHandling(a.value / b.value));
        }
        public static bool operator ==(MyIntType a, MyIntType b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(MyIntType a, MyIntType b)
        {
            return a.value == b.value;
        }
        public static bool operator >(MyIntType a, MyIntType b)
        {
            return a.value > b.value;
        }
        public static bool operator <(MyIntType a, MyIntType b)
        {
            return a.value < b.value;
        }
        #endregion

        /// <summary>
        /// Реализация круговой арифметики 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int OverflowHandling(int number)
        {
            if (number > MAX_VALUE)
                number = (number - MIN_VALUE) % (MAX_VALUE - MIN_VALUE) + MIN_VALUE;
            if (number < MIN_VALUE)
                number = (number - MAX_VALUE) % (MAX_VALUE - MIN_VALUE) + MAX_VALUE;
            return number;
        }
    }
}

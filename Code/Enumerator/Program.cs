using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IntEnumerator enumerator = new IntEnumerator(10, 2, 4, 6);

            while (true)
            {
                enumerator.MoveNext();

                if(enumerator.Current % 2 == 0)
                {
                    enumerator.MoveNext();
                }

                Console.WriteLine(enumerator.Current);
            }
        }
    }

    public class IntEnumerator
    {
        private int[] _data;
        private int _i = -1;

        public int Current
        {
            get
            {
                return _data[_i];
            }
        }

        public IntEnumerator(params int[] data)
        {
            _data = data;
        }

        public void MoveNext()
        {
            _i++;
            if (_data.Length >= _i-1)
            {
                _i = 0;
            }
        }
    }
}

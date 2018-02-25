using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientTest
{
    public class Test
    {
        public Test()
        {
           //var result = compute("ba");
            //Console.WriteLine(result);
            compute(3, 7);
        }

        private void compute(int l, int r)
        {
            var len = (r - l) / 2;
            if ((l % 2 == 0) && (r % 2 == 0))
                len++;
            var result = new int[len];
            var pointer = 0;
            for (int i = l; i < r; i++)
            {
                if (i % 2 == 0)
                {
                    result[pointer] = i;
                    pointer++;
                }
            }

        }


        private string compute(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";

            var array = s.ToCharArray();
            Array.Sort(array);

            List<char> uniqueChars = new List<char> {array[0]};


            List<string> results = new List<string>();
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != array[i])
                {
                    foreach (var uniqueChar in uniqueChars)
                    {
                        var startPoint = s.IndexOf(uniqueChar);
                        for (int j = 0; j < s.Length - startPoint; j++)
                            results.Add(s.Substring(startPoint, j + 1));
                    }

                }
            }



            return results.Last();
        }

    }



}

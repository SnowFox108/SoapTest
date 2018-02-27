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
            var result = compute("banana");
            Console.WriteLine(result);
            //compute(3, 7);
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

            List<char> uniqueChars = new List<char> { array[0] };


            List<string> results = new List<string>();
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != array[i])
                {
                    uniqueChars.Add(array[i]);
                }
            }

            foreach (var uniqueChar in uniqueChars)
            {
                var startIndex = 0;
                var tempList = new List<string>();
                while (s.IndexOf(uniqueChar, startIndex) != -1)
                {
                    startIndex = s.IndexOf(uniqueChar, startIndex);
                    for (int i = 0; i < s.Length - startIndex; i++)
                    {
                        var item = s.Substring(startIndex, i + 1);
                        if (tempList.IndexOf(item) == -1)
                        {
                            tempList.Add(item);
                            results.Add(item);
                        }
                    }
                    startIndex++;
                }
            }
            return results.Last();
        }

    }



}

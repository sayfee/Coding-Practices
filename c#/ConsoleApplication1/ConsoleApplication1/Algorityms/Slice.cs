using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Slice
    {
        public static void Main1(string[] args)
        {
            int[] A = { 4, 2, 2, 5, 1, 5, 8 };
            //Console.WriteLine(solution(A));

            Console.WriteLine(solution2(101));
            Console.ReadKey();
        }

        static int solution2(int N)
        {
            int a = 2;
            int b = N;
            int c = a;
            while(true)
            {
                if (a >= b)
                {
                    return 2* (b + (c));
                }
                else if (N % a == 0)
                {
                    b = N / a;
                    c = a;
                }
                
                a++;
                
            }


            return 0;
        }

        //A[] = {4.2.2.5.1.5.8}
        
        static int solution(int[] A)
        {
            int minAvg = 20000000;
            int minInd = -1;
            for (int i = 0; i < A.Length; i++)
            {
                int count = 1;
                int total = 0;
                for (int j = i+1; j < A.Length; j++)
                {
                    if (i != j)
                    {
                        count++;
                        total += A[i] + A[j];

                        int Avg = total / count;

                        if (minAvg > Avg)
                        {
                            minAvg = Avg;
                            minInd = i;
                        }
    

                    }
                }
            }

                return minInd;
        }
    }
}

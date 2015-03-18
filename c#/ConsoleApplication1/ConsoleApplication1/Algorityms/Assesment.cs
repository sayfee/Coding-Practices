using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Assesment
    {
        public static void Main1(string[] args)
        {


            //int[] Ar = { 1, 8, -3, 0, 1, 3, -2, 4, 5 };
            //int[] Ar2 = { 1, 8, -3, 0, 1, -2, 4, 5 };
            //int[] Ar3 = { 1, 8 };
            //int[] Ar4 = { 3, 3, 3 };
            //int[] Ar5 = { 3, 2, 4 };

            //int[] Ar6 = { 1, -2, 2, 0, 4, -1 };          
            
            int[] A = { 1, 1, 0, 1, 0, 0 };
           // int[] A1 = { 1, 1, 1, 1, 0, 0 };
            int[] A2 = { 0, 0, 1, 0, 1, 1 };
            int[] A3 = { 0, 0, 0, 0, 1, 1 };
            int[] A4 = { 0, 0, 0, 1, 1, 1 };

            int[] A10 = { 1 };
            int[] A1 = { 5, 4, 2, 5, 4, 2 , 1};

            Console.WriteLine(LonelyInteger(A10));

            Console.ReadKey();
        }

        public static int LonelyInteger(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int number = A[i];
                bool isFound = false;
                for (int j = 0; j < A.Length; j++)
                {
                    if (i != j && A[i] == A[j])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                    return A[i];
            
            }
        
            return 0;
        }

        public static int LonelyInteger2(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int number = A[i];
                bool isFound = false;
                for (int j = 0; j < A.Length; j++)
                {
                    if (i != j && A[i] == A[j])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                    return A[i];

            }

            return 0;
        }

        public static int Solution2(int K, int[] A)
        {
            int count = 0;
            for (int i = 0; i < A.Length / 2; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[i] + A[j] == K)
                        count++;
                }

            int half = 0;
            for (int i = 0; i < A.Length; i++)
                if (A[i] * 2==K)
                    half++;

            return count * 2 + half;
        }

        public static int solution(int[] A)
        {
            int n = A.Length;
            int result = 0;
            //birbirine esit olanlar
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] == A[i + 1])
                    result = result + 1;
            }
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                if (i > 0)
                {
                    if (A[i - 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                if (i < n - 1)
                {
                    if (A[i + 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                r = Math.Max(r, count);
            }
            return result + r;
        }
    }
}

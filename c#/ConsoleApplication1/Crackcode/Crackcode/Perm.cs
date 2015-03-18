using System;
namespace Crackcode
{
    public static class Perm
    {
        public static void main()
        {
            int perm = 6;
            Console.WriteLine(perm + " Prmt " + PermCalc(perm));
            Console.WriteLine(perm + " Fbn  " + Fibonocci(perm));
        }

        //3.2
        public static int PermCalc(int p)
        {
            int retunValue = p;
            if (p < 2) return retunValue;

            for (int i = p; i > 2; i--)
            {
                return PermCalc(i - 1) * p;
            }

            //for (int i = 0; i < p; i++)
            //{
            //    retunValue = i * PermCalc(i+1);
            //}
            return retunValue;
        }

        public static int Fibonocci(int f)
        {
            if (f < 2) return 1;

            for (int i = f; i >= 2; i--)
            {
                return Fibonocci(i - 1) + i;
            }

            return 0;
        }

        public static List<string> Permutation(string chr)
        {
            List<string> permt = new List<string>();
            for (int i = 0; i < chr.Length; i++)
            { 
                for(
            }
        
        }
    }
}
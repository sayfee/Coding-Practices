using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace ConsoleApplication1
{
    class RetryPattern
    {

        public static void RetryAction(Func<int, string> action, int numRetries, int secondsToWaitBeforeRetry)
        {
            while (numRetries-- >= 0)
            { 
                try
                {
                    string ret = action(numRetries);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ex: " + ex.Message);
                    if (numRetries <= 0 || !IsTemporary(ex))
                        throw ex; 
                    else
                        Thread.Sleep(secondsToWaitBeforeRetry * 1000);
                }

            } 
        }
         
        public static bool IsTemporary(Exception ex)
        {
            if (ex.Message.Contains("temp"))
                return true;

            var webException = ex as WebException;
            if (webException != null)
            {
                //any of this exception will allow a retry
                if (new[] { WebExceptionStatus.ConnectionClosed, WebExceptionStatus.RequestCanceled }.Contains(webException.Status))
                    return true;

            }
            return false;
        }
    }

    class ActualWork
    {
        public static string DoSomething(int secondsToWaitBeforeRetry)
        {
            Console.WriteLine(" Try : " + secondsToWaitBeforeRetry);

            if (DateTime.Now.Second % 5 != 0)
                throw new Exception("timeout-Not allowed for if not 5 second");

            if (DateTime.Now.Second % 2 == 0)
                throw new Exception("temp-Not allowed for even second");

            Console.WriteLine(DateTime.Now + " - " + "They called me " );
            return "Ok";
        }

     
    
    }

}

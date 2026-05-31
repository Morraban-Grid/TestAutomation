using System;
using System.Diagnostics;
namespace TestAutomation.Tests.PageObjectPattern.Helpers
{
    public static class WaitHelper
    {
        public static void WaitForCondition(Func<bool> condition, int msTimeout =
        4000)
        {
            // Este código es muy útil para esperar a que una condición se cumpla,
            // como por ejemplo, que un elemento web sea visible o clickeable,
            // o que el texto de un elemento sea igual a un valor esperado.
            var stopWatch = new Stopwatch(); // Definimos una variable de tipo Stopwatch
            stopWatch.Start(); // Iniciamos la variable.
            Exception? ex;
            do
            {
                try
                {
                    ex = null;
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ex = e;
                }
            } while (stopWatch.ElapsedMilliseconds < msTimeout);
            stopWatch.Stop();
            if (ex != null)
            {
                throw new TimeoutException("Error executing the condition", ex);
            }
            throw new TimeoutException("Error the condition was false");// Si la condifición es false,
                                                                            // lanzamos una excepción de timeout.
        }
    }
}
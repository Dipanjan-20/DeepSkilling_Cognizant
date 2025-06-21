
using System;

namespace SingletonPattern
{
    public class Logger
    {
        private static Logger instance = null;
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logger1 = Logger.GetInstance();
            logger1.Log("First message");

            var logger2 = Logger.GetInstance();
            logger2.Log("Second message");

            if (logger1 == logger2)
                Console.WriteLine("Both logger1 and logger2 are the same instance.");
            else
                Console.WriteLine("Different logger instances (should not happen).");

         
        }
    }
}


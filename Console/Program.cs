using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class ConsoleSettings
    {

        public ConsoleColor BackgroundColor = ConsoleColor.Yellow;
        public ConsoleColor ForegroundColor = ConsoleColor.DarkCyan;

        private static ConsoleSettings instance;
        
        private ConsoleSettings() { }

        public static ConsoleSettings Instance => 
            instance ?? (instance = new ConsoleSettings());

        public static ConsoleSettings GetInstance()
        {
            if (instance == null) instance = new ConsoleSettings();
            
            return instance;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            var n = ConsoleSettings.GetInstance();
            var n2 = ConsoleSettings.GetInstance();
            Console.WriteLine(n == n2);

            Console.BackgroundColor = n.BackgroundColor;
            Console.ForegroundColor = n.ForegroundColor;
            
             
            Console.WriteLine("Hello world");
            Console.ReadKey();

        }
    }
}

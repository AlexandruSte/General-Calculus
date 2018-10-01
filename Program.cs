using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralCalculus
{

    class Program
    {
        class Reader
        {
            private static Thread inputThread;
            private static AutoResetEvent getInput, gotInput;
            private static string input;

            static Reader()
            {
                getInput = new AutoResetEvent(false);
                gotInput = new AutoResetEvent(false);
                inputThread = new Thread(reader);
                inputThread.IsBackground = true;
                inputThread.Start();
            }

            private static void reader()
            {
                while (true)
                {
                    getInput.WaitOne();
                    input = Console.ReadLine();
                    gotInput.Set();
                }
            }
            
            public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
            {
                getInput.Set();
                bool success = gotInput.WaitOne(timeOutMillisecs);
                return input;
            }
        }

        static void Main(string[] args)
        {
            int number1, number2;
            int rez;
            double correctAdditions = 0, correctMultiplies = 0, correctSubtractions = 0;
            double secondsForAddition = 0, secondsForMultiply = 0, secondsForSubtractions = 0;
            double procentForAddition = 0, procentForMultiply = 0, procentForSubtraction = 0;
            int numberOfAdditions = 0, numberOfMultiplies = 0, numberOfSubtractions = 0;
            string rezfinal;
            Random rnd = new Random();
            
            Console.WriteLine("How many multiplications do you want to solve? ");
            rezfinal = Console.ReadLine();
            Int32.TryParse(rezfinal, out numberOfMultiplies);
            Console.Clear();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < numberOfMultiplies; i++)
            {
                Console.Write("# " + (i+1) + " : ");
                number1 = rnd.Next(6,19);
                number2 = rnd.Next(6,19);
                Console.Write(number1 + " x " + number2 + " = ");
                rezfinal = Reader.ReadLine(90000);
                rez = 0;
                Int32.TryParse(rezfinal, out rez);
                if (rez == (number1 * number2))
                {
                    correctMultiplies++;
                }
                Console.WriteLine(i);
                Console.Clear();
            }
            watch.Stop();
            secondsForMultiply = ( watch.ElapsedMilliseconds / 1000 );
            double d = (correctMultiplies / numberOfMultiplies);
            procentForMultiply = numberOfMultiplies != 0 ? ( d * 100) : 0;
            
            Console.WriteLine("How many additions do you want to solve? ");
            rezfinal = Console.ReadLine();
            Int32.TryParse(rezfinal, out numberOfAdditions);
            Console.Clear();
            
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < numberOfAdditions; i++)
            {
                Console.Write("# " + (i + 1) + " : ");
                number1 = rnd.Next(111, 9999);
                number2 = rnd.Next(111, 9999);
                Console.Write(number1 + " + " + number2 + " = ");
                rezfinal = Reader.ReadLine(90000);
                rez = 0;
                Int32.TryParse(rezfinal, out rez);
                if (rez == (number1 + number2))
                {
                    correctAdditions++;
                }
                Console.Clear();
            }
            watch.Stop();
            secondsForAddition = (watch.ElapsedMilliseconds / 1000);
            d = (correctAdditions / numberOfAdditions);
            procentForAddition = numberOfAdditions != 0 ? (d * 100) : 0;
            
            Console.WriteLine("How many subtractions do you want to solve? ");
            rezfinal = Console.ReadLine();
            Int32.TryParse(rezfinal, out numberOfSubtractions);
            Console.Clear();
            
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < numberOfSubtractions; i++)
            {
                Console.Write("# " + (i + 1) + " : ");
                number1 = rnd.Next(111,9999);
                number2 = rnd.Next(111,number1);
                Console.Write(number1 + " - " + number2 + " = ");
                rezfinal = Reader.ReadLine(90000);
                rez = 0;
                Int32.TryParse(rezfinal, out rez);
                if (rez == (number1 - number2))
                {
                    correctSubtractions++;
                }
                Console.Clear();
            }
            watch.Stop();
            secondsForSubtractions = (watch.ElapsedMilliseconds / 1000);
            d = (correctSubtractions / numberOfSubtractions);
            procentForSubtraction = numberOfSubtractions != 0 ? (d * 100) : 0;
            
            Console.WriteLine("You finished all the exercises!");
            Console.WriteLine("");

            Console.WriteLine("1. Multiplications : ");
            Console.WriteLine("You solved " + correctMultiplies + " multiplications correctly.");
            Console.WriteLine("The percentage is " +
                 + procentForMultiply + "%, in " + secondsForMultiply + " seconds.");
            Console.WriteLine("You spent " + secondsForMultiply / numberOfMultiplies + " seconds for every multiplication.");

            Console.WriteLine("");
            Console.WriteLine("2. Additions : ");
            Console.WriteLine("You solved " + correctAdditions + " additions correctly.");
            Console.WriteLine("The percentage is " +
                 + procentForAddition + "%, in " + secondsForAddition + " seconds.");
            Console.WriteLine("You spent " + secondsForAddition/numberOfAdditions + " seconds for every addition.");

            Console.WriteLine("");
            Console.WriteLine("3. Subtractions : ");
            Console.WriteLine("You solved " + correctSubtractions + " subtractions correctly.");
            Console.WriteLine("The percentage is " +
                 + procentForSubtraction + "%, efectuat intr-un timp de " + secondsForSubtractions + " seconds.");
            Console.WriteLine("You spent " + secondsForSubtractions / numberOfSubtractions + " seconds for every subtraction.");
        }
    }
}

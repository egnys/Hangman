using Hangman.Models;
using System.Text;

namespace Hangman
{
    internal sealed class Program
    {
        public static GameService service = new GameService();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine($"Угадайте слово: {service.answer}");
            Console.WriteLine(service.GetWord());
            //WordsLoader wordsLoader = new WordsLoader();

            StartGameLoop();
        }

        private static void StartGameLoop()
        {
            while (service.CanPlay())
            {
                Console.Write($"Введите букву, которая может быть в слове: ", Console.ForegroundColor = ConsoleColor.Gray);

                string yourAnswer = Console.ReadLine();

                if ( yourAnswer.Length != 1 && !string.IsNullOrEmpty( yourAnswer ) )
                {
                    Console.WriteLine("Пожалуйста, введите только одну букву!", Console.ForegroundColor = ConsoleColor.Red);
                    continue;
                }

                var result = service.TrySetCharInField("о");

                if(!result)
                {
                    continue;
                }
                Console.Clear();

                Console.WriteLine($"Угадайте слово: {service.answer}", Console.ForegroundColor = ConsoleColor.Gray);

            }
        }
    }
}
using Hangman.Models;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal sealed class Program
    {
        public static GameService service = new GameService(maxTries: 7);

        static void Main(string[] args)
        {
            Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}");

            StartGameLoop();
        }
        private static void ShowCurrentGameState()
        {
            Console.Clear();
            Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}", Console.ForegroundColor = ConsoleColor.Gray);
        }
        private static void StartGameLoop()
        {
            while (service.CanPlay())
            {
                Console.WriteLine(service.Field.DrawField(service.currentTry));
                Console.Write($"Введите букву, которая может быть в слове: ", Console.ForegroundColor = ConsoleColor.Gray);
                
                Regex regex = new Regex(@"^[а-я]$");

                if (!char.TryParse(Console.ReadLine(), out char yourAnswer) && regex.IsMatch(yourAnswer.ToString()))
                {
                    Console.WriteLine("Пожалуйста, введите только одну букву нижнего регистра!", Console.ForegroundColor = ConsoleColor.Red);
                    continue;
                }
                
                var result = service.TrySetCharInField(yourAnswer);

                service.CheckStatus();

                if (service.CheckWin())
                {
                    ShowCurrentGameState();
                    Console.WriteLine($"Поздравляем! Вы правильно отгадали слово.");

                    break;
                }
                if (!service.CanPlay())
                {
                    ShowCurrentGameState();
                    Console.WriteLine(service.Field.DrawField(service.currentTry));
                    Console.WriteLine($"Вы проиграли! Секретное слово - {service.SecretWord}.");

                    break;
                }

                if (!result)
                {
                    ShowCurrentGameState();

                    continue;
                }

                ShowCurrentGameState();
            }
        }
    }
}
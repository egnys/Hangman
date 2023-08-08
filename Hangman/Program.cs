using Hangman.Models;

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

        private static void StartGameLoop()
        {
            while (service.CanPlay())
            {
                Console.WriteLine(service.Field.DrawField(service.currentTry));
                Console.Write($"Введите букву, которая может быть в слове: ", Console.ForegroundColor = ConsoleColor.Gray);

                if (!char.TryParse(Console.ReadLine(), out char yourAnswer))
                {
                    Console.WriteLine("Пожалуйста, введите только одну букву!", Console.ForegroundColor = ConsoleColor.Red);
                    continue;
                }

                var result = service.TrySetCharInField(yourAnswer);

                service.CheckStatus();

                if (service.CheckWin())
                {
                    Console.Clear();
                    Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}", Console.ForegroundColor = ConsoleColor.Gray);
                    Console.WriteLine($"Поздравляем! Вы правильно отгадали слово.");

                    break;
                }
                if (!service.CanPlay())
                {
                    Console.Clear();
                    Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}", Console.ForegroundColor = ConsoleColor.Gray);
                    Console.WriteLine(service.Field.DrawField(service.currentTry));
                    Console.WriteLine($"Вы проиграли! Секретное слово - {service.SecretWord}.");

                    break;
                }

                if (!result)
                {
                    Console.Clear();
                    Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}", Console.ForegroundColor = ConsoleColor.Gray);


                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Угадайте слово:\t{service.Field.answer}\tПопытки: {service.maxTries - service.currentTry}", Console.ForegroundColor = ConsoleColor.Gray);
            }
        }
    }
}
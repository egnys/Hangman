using System.Text;

namespace Hangman.Models
{
    internal class HangmanField
    {
        public char[] _temp;

        public int _secretNumber;

        public StringBuilder answer;

        public HangmanField() { }

        public string DrawField(int currentField)
        {
            var field = new StringBuilder();
            field.AppendLine("_______");
            field.AppendLine($"|    {(currentField >= 1 ? "|" : "")}");
            field.AppendLine($"|    {(currentField >= 2 ? "O" : "")}");
            field.AppendLine($"|   {(currentField >= 4 ? "/|" : "")}{(currentField == 3 ? " |" : "")}{(currentField >= 5 ? "\\" : "")}");
            field.AppendLine($"|   {(currentField >= 6 ? "/" : "")} {(currentField >= 7 ? "\\" : "")}");
            field.AppendLine($"|");
            return field.ToString();
        }
    }
}

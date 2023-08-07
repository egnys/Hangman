using System.Text;

namespace Hangman.Models
{
    internal class HangmanField
    {
        public char[] _temp;

        public int _secretNumber;

        public StringBuilder answer;

        public HangmanField() { }

        public override string ToString()
        {
            var field = new StringBuilder();
            field.AppendLine("_______");
            field.AppendLine("|");
            field.AppendLine("|");
            field.AppendLine("|");
            field.AppendLine("|");
            field.AppendLine("|");
            return field.ToString();
        }
    }
}

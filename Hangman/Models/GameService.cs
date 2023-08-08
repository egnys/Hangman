using Hangman.Abstract;
using System.Text;

namespace Hangman.Models
{
    internal class GameService : IGameService
    {
        private bool _endgame;

        public int currentTry;

        public HangmanField Field;

        private string _secretWord;

        public readonly int maxTries;

        private readonly WordsLoader _wordsLoader;

        public string SecretWord { get => _secretWord; }

        public GameService(int maxTries)
        {
            this._endgame = false;
            this.maxTries = maxTries;
            this.Field = new HangmanField();
            this._wordsLoader = new WordsLoader();
            Random random = new Random();
            this.Field._secretNumber = random.Next(this._wordsLoader.Words.Count - 1);
            this._secretWord = this._wordsLoader.Words[this.Field._secretNumber];
            this.Field._temp = this._secretWord.ToCharArray();
            this.Field.answer = new StringBuilder(new string('-', this._secretWord.Length));
        }

        public bool CanPlay()
        {
            return !this._endgame;
        }

        public void CheckStatus()
        {
            if (this.currentTry == this.maxTries)
            {
                this._secretWord = this._wordsLoader.Words[this.Field._secretNumber];
                this._endgame = true;
            }
        }

        public bool CheckWin()
        {
            return !this.Field.answer.ToString().Contains("-");
        }

        public bool TrySetCharInField(char yourAnswer)
        {
            var result = this._secretWord.Contains(yourAnswer);
            if (result)
            {
                var index = this._secretWord.IndexOf(yourAnswer);
                this.Field.answer[index] = yourAnswer;


                this.Field._temp[index] = '+';
                this._secretWord = string.Join("", this.Field._temp);
            }
            else this.currentTry++;

            return result;
        }
    }
}

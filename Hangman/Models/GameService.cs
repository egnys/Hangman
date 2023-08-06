using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    internal class GameService
    {
        private int _step;

        private string _secretWord;

        public StringBuilder answer;

        protected readonly int maxTries;
        
        private readonly WordsLoader _wordsLoader;

        public GameService()
        {    
            this._wordsLoader = new WordsLoader();
            Random random = new Random();
            this._secretWord = this._wordsLoader.Words[random.Next(this._wordsLoader.Words.Count - 1)];
            this.answer = new StringBuilder(new string('-', this._secretWord.Length));
        }
        
        public string GetWord()
        {
            return this._secretWord;
        }
        
        public bool CanPlay()
        {
            return true;
        }

        internal bool TrySetCharInField(string yourAnswer)
        {
            var result = this._secretWord.Contains(yourAnswer);
            Console.WriteLine(yourAnswer);
            if (result)
            {
                var index = this._secretWord.IndexOf(yourAnswer);
                this.answer[index] = yourAnswer[0];
                this._step++;
                Console.WriteLine("Hello from if");
            }
            return result;
        }
    }
}

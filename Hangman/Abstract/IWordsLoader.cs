namespace Hangman.Abstract
{
    public interface IWordsLoader
    {
        public List<string> Words { get; }

        public List<string> LoadWords();
    }
}

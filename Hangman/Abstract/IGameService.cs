namespace Hangman.Abstract
{
    internal interface IGameService
    {
        public bool CanPlay();

        public bool CheckWin();

        public void CheckStatus();

        public string SecretWord { get; }

        public bool TrySetCharInField(char yourAnswer);
    }
}

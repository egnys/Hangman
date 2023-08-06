using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Abstract
{
    public interface IWordsLoader
    {
        public List<string> Words { get; }
    }
}

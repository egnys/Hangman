﻿using Hangman.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    internal class WordsLoader : IWordsLoader
    {
        private readonly string _fileName;

        private readonly string _pathToFile;

        private readonly List<string> _words;

        private readonly string _fullPathToFile;

        public List<string> Words { get => this._words; }
   
        public WordsLoader()
        {
            this._fileName = "WordsStockRus.txt";
            this._pathToFile = string.Join("\\", Path.Combine(Directory.GetCurrentDirectory()).Split("\\")[..^3]);
            this._fullPathToFile = Path.Combine(this._pathToFile, this._fileName);

            this._words = LoadWords();
        }

        private List<string> LoadWords()
        {
            return new List<string>(File.ReadAllLines(this._fullPathToFile));
        }

    }
}
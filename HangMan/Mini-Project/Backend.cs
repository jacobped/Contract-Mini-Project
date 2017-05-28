using Mini_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    public class Backend : IBackend
    {
        private string _fullWord;
        private int _maxAttempts;
        private int _errors = 0;
        private readonly List<string> _guesses = new List<string>();
        public void Setup(string word, int allowedAttempts)
        {
            _fullWord = word;
            _maxAttempts = allowedAttempts;
        }

        public int GetAllowedAttempts()
        {
            return _maxAttempts;
        }

        public int GetFailedAttempts()
        {
            return _errors;
        }

        public int GetGuessAttempts()
        {
            return _guesses.Count;
        }

        public string[] GetGuesses()
        {
            return _guesses.Select(x => x.ToString()).ToArray();
        }

        public string GetWord()
        {
            return _fullWord;
        }

        public void Guess(char guess)
        {
            guess = char.ToLower(guess);
            _guesses.Add(char.ToString(guess));

            if (!_fullWord.Any(x => x.Equals(guess)))
            {
                _errors++;
            }
        }

        public void Guess(string guess)
        {
            _guesses.Add(guess);

            if (!guess.Equals(_fullWord))
            {
                _errors++;
            }
        }

        public bool IsGameOver()
        {
            return GetGuessAttempts() >= _maxAttempts || IsGameWon();
        }

        public bool IsGameWon()
        {
            return GetWord().All(s => GetGuesses().Contains(s.ToString())) || GetGuesses().Contains(GetWord());
        }
    }
}

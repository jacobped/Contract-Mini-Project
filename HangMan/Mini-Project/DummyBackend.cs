using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Mini_Project
{
    public class DummyBackend : IBackend
    {
        private int allowedAttempts, guessAttempts = 0;
        private String word = String.Empty;
        private List<String> guesses;


        public void Setup(string word, int allowedAttempts)
        {
            this.allowedAttempts = allowedAttempts;
            this.word = word;

        }

        public void Guess(char guess)
        {
            guessAttempts++;
            guesses.Add(guess.ToString());
        }

        public void Guess(string guess)
        {
            guessAttempts++;
            guesses.Add(guess);
        }

        public string GetWord()
        {
            return word;
        }

        public int GetGuessAttempts()
        {
            return guessAttempts;
        }

        public int GetAllowedAttempts()
        {
            return allowedAttempts;
        }

        public bool IsGameWon()
        {
            if (GetGuesses().Contains(GetWord()))
                return true;
            if (GetWord().All(x => GetGuesses().Contains(x.ToString())))
                return true;
            return false;
        }

        public bool IsGameOver()
        {
            if (IsGameWon())
                return true;

            if (GetAllowedAttempts() < GetGuessAttempts())
            {
                return true;
            }
            return false;
        }

        public string[] GetGuesses()
        {
            return guesses.ToArray();
        }
    }
}
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Mini_Project
{
    [ContractClass(typeof(IBackendContract))]
    public interface IBackend
    {
        void Setup(string word, int allowedAttempts);
        void Guess(char guess);
        void Guess(string guess);
        string GetWord();
        int GetGuessAttempts();
        int GetFailedAttempts();
        int GetAllowedAttempts();
        bool IsGameWon();
        bool IsGameOver();
        string[] GetGuesses();
    }

    [ContractClassFor(typeof(IBackend))]
    internal abstract class IBackendContract : IBackend
    {
        public void Setup(string word, int allowedAttempts)
        {
            Contract.Requires(!string.IsNullOrEmpty(word));
            Contract.Requires(word.ToLower().Equals(word));
            Contract.Requires(word.All(char.IsLetter));
            Contract.Requires(allowedAttempts > 0);
            Contract.Ensures(allowedAttempts == GetAllowedAttempts());
            Contract.Ensures(word == GetWord());
        }

        public void Guess(char guess)
        {
            Contract.Requires(char.IsLower(guess));
            Contract.Ensures((Contract.OldValue(GetGuessAttempts()) +1) == GetGuessAttempts());
            Contract.Ensures(GetGuesses().Last().Equals(guess.ToString()));
            Contract.Ensures((!GetWord().Contains(guess.ToString()) && Contract.OldValue(GetFailedAttempts()) + 1 == GetFailedAttempts()) ||  
                (GetWord().Contains(guess.ToString()) && Contract.OldValue(GetFailedAttempts()) == GetFailedAttempts()));
        }

        public void Guess(string guess)
        {
            Contract.Requires(guess.ToLower().Equals(guess));
            Contract.Requires(guess.Count() > 1);
            Contract.Ensures((Contract.OldValue(GetGuessAttempts()) + 1) == GetGuessAttempts());
            Contract.Ensures(GetWord().Equals(guess) == IsGameWon());
            Contract.Ensures(GetGuesses().Last().Equals(guess));
            Contract.Ensures((!GetWord().Equals(guess) && Contract.OldValue(GetFailedAttempts()) + 1 == GetFailedAttempts()) ||
                             (GetWord().Equals(guess) && Contract.OldValue(GetFailedAttempts()) == GetFailedAttempts()));
        }

        public string GetWord()
        {
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
            return default(string);
        }

        public int GetGuessAttempts()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            Contract.Ensures(GetGuesses().Count() == GetGuessAttempts());
            return default(int);
        }

        public int GetFailedAttempts()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        public int GetAllowedAttempts()
        {
            Contract.Ensures(Contract.Result<int>() > 0);
            return default(int);
        }

        public bool IsGameWon()
        {
            Contract.Ensures(Contract.Result<bool>() == GetWord().All(s => GetGuesses().Contains(s.ToString())) || 
                Contract.Result<bool>() == GetGuesses().Contains(GetWord()));
            return default(bool);
        }

        public bool IsGameOver()
        {
            Contract.Ensures((Contract.Result<bool>() == (GetGuessAttempts() >= GetAllowedAttempts())) || 
               Contract.Result<bool>() == IsGameWon());
            return default(bool);
        }

        public string[] GetGuesses()
        {
            return default(string[]);
        }
    }
}
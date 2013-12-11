using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_1DV409.Models
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        Oldguess
    }

    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }

    public class SecretNumber
    {
        private List<GuessedNumber> m_guessedNumbers;

        private GuessedNumber m_lastGuessedNumber;

        private int? m_number;

        private const int GuessesBeforeGameOver = 6; //Number of guesses - 1

        [Required]
        [Range(1,100)]
        public int Guess { get; set; }

        public bool SessionExpired { get; set; }

        public SecretNumber()
        {
            m_guessedNumbers = new List<GuessedNumber>();
            Initialize();            
        }

        public void Initialize()
        {
            m_guessedNumbers.Clear();
            Number = new Random().Next(1, 101);
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
                throw new ArgumentOutOfRangeException("guess");

            m_lastGuessedNumber = new GuessedNumber();
            m_lastGuessedNumber.Number = guess;
            
            foreach (GuessedNumber g in GuessedNumbers)
            {
                if (g.Number == guess)
                {
                    m_lastGuessedNumber.Outcome = Outcome.Oldguess;
                    return LastGuessedNumber.Outcome;
                }
            }

            if (guess == m_number)
                m_lastGuessedNumber.Outcome = Outcome.Right;
            else if (!CanMakeGuess)
                m_lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
            else if (guess > m_number)
                m_lastGuessedNumber.Outcome = Outcome.High;
            else if (guess < m_number)
                m_lastGuessedNumber.Outcome = Outcome.Low;

            m_guessedNumbers.Add(LastGuessedNumber);
            
            return LastGuessedNumber.Outcome;
        }



        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                    return null;
                return m_number; 
            }
            private set { m_number = value; }
        }

        public GuessedNumber LastGuessedNumber
        {
            get { return m_lastGuessedNumber; }
        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get { return m_guessedNumbers.AsReadOnly(); }
        }

        internal bool CanMakeGuess
        {
            get { return Count < GuessesBeforeGameOver; } //|| LastGuessedNumber.Number == Number; }
        }

        public int Count
        {
            get { return GuessedNumbers.Count; }
        }
    }
}
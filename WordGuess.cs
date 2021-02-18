// TODO: don't forget your header (give credit for starter code)

using System;
using System.Diagnostics;

class GuessingGame
{
    /*
        Returns a "masked" copy of the word. The returned string will be of the same
        length as the original, but positions where the mask is false will be
        replaced with hypens.
    */
    static string MaskWord(string word, bool[] mask)
    {
        string masked = "";
        // TODO: add characters to masked (e.g. with += )
        return masked;
    }

    /*
        Switches to true any locations in the mask where the word matches the given guess 
    */
    static void UpdateMask(bool[] mask, string word, char guess)
    {
        // TODO: update mask
    }

    /*
        Returns true if the given boolean array has any false values.
    */
    static bool HasFalse(bool[] values)
    {
        // TODO: figure out if there are any falses in values
        return false;
    }

    static void TestMaskWord()
    {
        Debug.Assert(
            MaskWord("test", new bool[] { true, false, false, true }) ==
            "t--t");
        Debug.Assert(
            MaskWord("testing", new bool[] { true, false, false, true, false, true, false }) ==
            "t--t-n-");
    }

    static void TestUpdateMask()
    {
        string word = "test";
        bool[] mask = { false, true, false, false };
        UpdateMask(mask, word, 't');
        Debug.Assert(mask[0]);
        Debug.Assert(mask[1]);
        Debug.Assert(!mask[2]);
        Debug.Assert(mask[3]);
    }

    static void TestHasFalse()
    {
        Debug.Assert(HasFalse(new bool[] { false, true, true }));
        Debug.Assert(HasFalse(new bool[] { true, false }));
        Debug.Assert(HasFalse(new bool[] { false, false }));
        Debug.Assert(!HasFalse(new bool[] { true, true }));
    }

    static void RunTests()
    {
        TestMaskWord();
        TestUpdateMask();
        TestHasFalse();
    }

    static void Main()
    {
        RunTests();
        Console.WriteLine("Welcome to Word-Guess! It is kind of like \"hangman\".");
        Console.WriteLine("Please enter a word for the player to guess.");

        // lower-case word that the player will try to guess
        string targetWord = Console.ReadLine().ToLower();

        // true where the letter has been guessed, false at hidden positions
        bool[] mask = new bool[targetWord.Length];
        int numGuesses = 0;

        while (HasFalse(mask))
        {
            Console.Clear();
            Console.WriteLine($"You've used {numGuesses} guesses.");
            Console.WriteLine(MaskWord(targetWord, mask));
            Console.Write("Please guess a (lowercase) letter: ");
            char guess = Console.ReadKey().KeyChar;
            UpdateMask(mask, targetWord, guess);
            numGuesses += 1;
        }
        Console.Clear();
        Console.WriteLine(targetWord);
        Console.WriteLine($"You got it in {numGuesses} guesses!");
    }

}

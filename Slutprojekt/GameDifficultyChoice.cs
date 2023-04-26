using System;

public class GameDifficultyChoice
{
    public static string DifficultyChoice()
    {
        string difficultyChoice = "";
        while(difficultyChoice != "easy" && difficultyChoice != "medium" && difficultyChoice != "hard")
        {
            difficultyChoice = Console.ReadLine();
            if(difficultyChoice != "easy" && difficultyChoice != "medium" && difficultyChoice != "hard")
            {
                Console.WriteLine("Please write either 'easy', 'medium', or 'hard'. Your answer should only be written in lowercase!");
            }
        }
        return difficultyChoice;
    }
}

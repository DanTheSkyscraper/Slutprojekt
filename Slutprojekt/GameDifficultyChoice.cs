using System;

public class GameDifficultyChoice //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
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
        return difficultyChoice; //This code will restart the while-loop if the player doesn't write 'easy', 'medium' or 'hard', or if the answer isn't in lowercase.
    }
}

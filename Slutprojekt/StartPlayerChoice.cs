using System;

public class StartPlayerChoice
{
    public static string StartChoice()
    {
        string startChoice = "";
        while(startChoice != "yes" && startChoice != "no")
        {
            startChoice = Console.ReadLine();
            if(startChoice != "yes" && startChoice != "no")
            {
                Console.WriteLine("Please write either 'yes' or 'no'! Your answer should only be written in lowercase.");
            }
        }
        return startChoice;
    }
}
using System;

public class StartPlayerChoice //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
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
        return startChoice; //This code will restart the while-loop if the player doesn't write 'yes' or 'no', or if the answer isn't in lowercase.
    }
}
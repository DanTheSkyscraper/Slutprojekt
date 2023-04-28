using System;

public class GameFight //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
{
    public static string Fight()
    {
        string battleChoice = "";
        while(battleChoice != "a" && battleChoice != "d")
        {
            battleChoice = Console.ReadLine();
            if(battleChoice != "a" && battleChoice != "d")
            {
                Console.WriteLine("Please type either 'a' or 'd'. The answer should be in lowercase!");
            }
        }
        return battleChoice; //This code will restart the while-loop if the player doesn't type 'a' or 'd', or if the answer isn't in lowercase.
    }
}
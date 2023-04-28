using System;

public class GamePlayerName //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
{
    public static string GameNames()
    {
        string playerName;

        Console.WriteLine("\n My name is:"); //This code allows the player to write their name.
        playerName = Console.ReadLine();
        
        return playerName;
    }
}
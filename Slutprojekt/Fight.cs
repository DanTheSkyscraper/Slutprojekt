using System;

public class GameFight
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
        return battleChoice;
    }
}
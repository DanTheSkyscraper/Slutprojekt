using System;

public class PlayerWeaponChoice
{
    public static string WeaponChoice()
    {
        string weaponChoice = "";
        while(weaponChoice != "a" && weaponChoice != "b" && weaponChoice != "c" && weaponChoice != "d")
        {
            weaponChoice = Console.ReadLine();
            if(weaponChoice != "a" && weaponChoice != "b" && weaponChoice != "c" && weaponChoice != "d")
            {
                Console.WriteLine("Please type either 'a', 'b', 'c' or 'd'. The answer should be in lowercase!");
            }
        }
         if(weaponChoice == "a")
        {
            Console.WriteLine("You chose the 'Dagger'");
            weaponChoice = "Dagger";
        }
        else if(weaponChoice == "b")
        {
            Console.WriteLine("You chose the 'Greatsword'");
            weaponChoice = "Greatsword";
        }
        else if(weaponChoice == "c")
        {
            Console.WriteLine("You chose the 'Bow'");
            weaponChoice = "Bow";
        }
        else
        {
            Console.WriteLine("You chose the 'Sword'");
            weaponChoice = "Sword";
        }

        return weaponChoice;
    }
}

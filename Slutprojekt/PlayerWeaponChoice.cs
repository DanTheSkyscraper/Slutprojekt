using System;

public class PlayerWeaponChoice //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
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
        if(weaponChoice == "a") //If the player types 'a', the Dagger is chosen as a weapon.
        {
            Console.WriteLine("You chose the 'Dagger'");
            weaponChoice = "Dagger";
        }
        else if(weaponChoice == "b") //If the player types 'b', the Greatsword is chosen as a weapon.
        {
            Console.WriteLine("You chose the 'Greatsword'");
            weaponChoice = "Greatsword";
        }
        else if(weaponChoice == "c") //If the player types 'c', the Bow is chosen as a weapon.
        {
            Console.WriteLine("You chose the 'Bow'");
            weaponChoice = "Bow";
        }
        else //If the player types 'd', the Sword is chosen as a weapon.
        {
            Console.WriteLine("You chose the 'Sword'");
            weaponChoice = "Sword";
        }

        return weaponChoice;
    }
}

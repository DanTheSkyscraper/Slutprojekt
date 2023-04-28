using System;

public class GameDamage //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
{
    public static int playerWeaponMinDamage = 1;
    public static int playerWeaponMaxDamage = 16;
    public static int enemyEasyMinDamage = 1;
    public static int enemyEasyMaxDamage = 10;
    public static int enemyMediumMinDamage = 2;
    public static int enemyMediumMaxDamage = 12;
    public static int enemyHardMinDamage = 3;
    public static int enemyHardMaxDamage = 16;
}
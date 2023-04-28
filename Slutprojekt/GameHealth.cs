using System;

public class GameHealth //Class is visible in 4 different ways: Public, Private, Internal and Protected. Public is used here, and it allows us to access class via the objects we create of that class.
{
    public static int playerHealth = 400;
    public static int enemyHealth;
    public static int enemyEasyHealth = 20;
    public static int enemyMediumHealth = 40;
    public static int enemyHardHealth = 60;
}

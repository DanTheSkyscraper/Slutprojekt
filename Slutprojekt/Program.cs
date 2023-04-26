//The game begin here.

string restartGame = "y";
while (restartGame == "y") //This while-loop will make it so that the player can restart the game by pressing "y".
{   

    // The integers for the damage the player and enemies deal to each other is in the method (gameDamage). They will make it so that both the player and the enemies deal a certain amount of damage ot each other.
    

    // The integers for health is located in the method (gameHealth). They will make it so that both the player and the enemies have specific amounts of health.
   

    // The integers for blocking is located in the method (gameBlock). They will make it so that the player can block a specific amount of health.


    Random generator = new Random();



    Console.WriteLine("Greetings player! We welcome you to the Survival games! Here, you are going to try your best to survive. Of course, if you do not want to do this, I will not stop you from leaving. What do you say? \n\n [yes // no] \n (This is case sensitive. Please use lowercase when answering.)");

    string startChoice = StartPlayerChoice.StartChoice();

    if(startChoice == "no")
    {
        Console.WriteLine("Very well. I thank you for visiting us, and I hope you come to visit us again. The exit is through the gate to the left.");
    }
    else
    {
        Console.WriteLine("\n Jolly good! Now, before we begin with the survival games, I would like to know your name.");

       string playerName = GamePlayerName.GameNames();

        Console.WriteLine("\n What a wonderful name you have! Now, before we begin, I want you to choose the difficulty. Your choices are: [easy / medium / hard]. \n (This is case sensitive. Please use lowercase when answering.)");

        string difficultyChoice = GameDifficultyChoice.DifficultyChoice();
        
        if(difficultyChoice == "easy")
        {
            Console.WriteLine("\n Good Choice for a beginner. You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");
            
            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");
            string weaponChoice = PlayerWeaponChoice.WeaponChoice();

            Console.WriteLine("\n With that done, let the games begin! In Easy, you are going to face four enemies. Good luck!");
            
            while(GameHealth.playerHealth > 0 && GameHealth.enemyEasyHealth > 0)
            {
                for(int i = 0; i < 4; i++)
                {
                    //string playerName = GamePlayerName.GameNames();

                    string[] enemyNames = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                    string enemyName = enemyNames[generator.Next(0, 4)];
                    Console.WriteLine();
        

                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyEasyHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight();

                    if(battleChoice == "a")
                    {
                        Console.WriteLine($"\n You attack '{enemyName}' with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);
                        GameHealth.enemyEasyHealth -= playerDamage;
                        GameHealth.enemyEasyHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"'{playerName}' hit '{enemyName}' with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n '{enemyName}' attacks '{playerName}'!");
                        int enemyEasyDamage = generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage);
                        GameHealth.playerHealth -= enemyEasyDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"'{enemyName}' hit '{playerName}', dealing {enemyEasyDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"\n '{playerName}' blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"'{enemyName}' attacks '{playerName}'");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);
                        int enemyEasyDamage = generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage) - playerBlock;
                        GameHealth.playerHealth -= enemyEasyDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"'{enemyName}' hit '{playerName}', dealing {enemyEasyDamage} damage!");
                    }
                }
            }
        }
        else if(difficultyChoice == "medium")
        {
            Console.WriteLine("\n Good choice for an experienced player. You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");
            
            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");
            string weaponChoice = PlayerWeaponChoice.WeaponChoice();

            Console.WriteLine("\n With that done, let the games begin! In Medium, you are going to face five enemies. Good luck!");
            
            //while(GameHealth.playerHealth > 0 && GameHealth.enemyMediumHealth > 0)
            for(int i = 0; i < 5; i++)
            {
                string[] enemyNames = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                string enemyName = enemyNames[generator.Next(0, 4)];
                Console.WriteLine();

                //for(int i = 0; i < 5; i++)
                while(GameHealth.playerHealth > 0 && GameHealth.enemyMediumHealth > 0)
                {

                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyMediumHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight();
                    if(battleChoice == "a")
                    {
                        Console.WriteLine($"\n You attack {enemyName} with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);
                        GameHealth.enemyMediumHealth -= playerDamage;
                        GameHealth.enemyMediumHealth = Math.Max(0, GameHealth.enemyMediumHealth);
                        Console.WriteLine($"{playerName} hit {enemyName} with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n {enemyName} attacks {playerName}!");
                        int enemyMediumDamage = generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage);
                        GameHealth.playerHealth -= enemyMediumDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyMediumDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"\n {playerName} blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"{enemyName} attacks {playerName}");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);
                        int enemyMediumDamage = generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage) - playerBlock;
                        GameHealth.playerHealth -= enemyMediumDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyMediumDamage} damage!");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\n Good choice for someone looking for a challenge! You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");

            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");
            string weaponChoice = PlayerWeaponChoice.WeaponChoice();

            Console.WriteLine("\n With that done, let the games begin! In Hard, you are going to face six enemies. Good luck!");
            
            while(GameHealth.playerHealth > 0 && GameHealth.enemyHardHealth > 0)
            {

                for(int i = 0; i < 6; i++)
                {
                    //string playerName = GamePlayerName.GameNames();

                    string[] enemyName = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                    Console.WriteLine(enemyName[generator.Next(0, 4)]);

                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyHardHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight();
                    if(battleChoice == "a")
                    {
                        Console.WriteLine($"\n You attack {enemyName} with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);
                        GameHealth.enemyHardHealth -= playerDamage;
                        GameHealth.enemyHardHealth = Math.Max(0, GameHealth.enemyHardHealth);
                        Console.WriteLine($"{playerName} hit {enemyName} with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n {enemyName} attacks {playerName}!");
                        int enemyHardDamage = generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage);
                        GameHealth.playerHealth -= enemyHardDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyHardDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"\n {playerName} blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"{enemyName} attacks {playerName}");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);
                        int enemyHardDamage = generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage) - playerBlock;
                        GameHealth.playerHealth -= enemyHardDamage;
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyHardDamage} damage!");
                    }
                }
            }
        }

        if(GameHealth.playerHealth == 0)
        {
            Console.WriteLine("You has been defeated!");
            Console.WriteLine("\n Oooooh, what a shame. You did good. Better luck next time friend!");
        }
        else if(GameHealth.enemyEasyHealth == 0)
        {
            Console.WriteLine("The enemies have been defeated.");
            Console.WriteLine("\n Would you look at that! Even when you are new to this, you managed to win! Here is your prize, now off you go!");
        }
        //else if(GameHealth.enemyMediumHealth == 0)
        else if(GameHealth.enemyMediumHealth == 0)
        {
            Console.WriteLine("The enemies have been defeated.");
            Console.WriteLine("\n Speldid! I can see that you are experienced at this! Here is your prize, now off you go!");
        }
        else
        {
            Console.WriteLine("The enemies have been defeated.");
            Console.WriteLine("\n I can see that you have mastered this! Here is your prize, now off you go!");
        }
        

    }

    Console.WriteLine("\n Do you wish to play again? [y/n]"); // This is the end of the while-loop. This Console.WriteLine will give you the option to choose whether you want to restart the game or not. If 'y' is pressed, you start again. If you press 'n', you will exit the game.
    restartGame = Console.ReadLine();
}
Console.ReadLine();

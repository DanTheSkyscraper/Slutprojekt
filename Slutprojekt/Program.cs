//The game begin here.

string restartGame = "y";
while (restartGame == "y") //This while-loop will make it so that the player can restart the game by pressing "y".
{   

    Random generator = new Random(); //This random generator makes it so that the parts of the code that use it are randomized. For example, the damage dealt by the player and the enemy in this code is randomized. 

    //This is the introduction to the game. Here, the player is asked if they want to play the game or leave. The player may choose to either continue the game by writing 'yes', or quitting the game by writing 'no'. All letters in the answers are instructed to be in lowercase.
    Console.WriteLine("Greetings player! We welcome you to the Survival games! Here, you are going to try your best to survive. Of course, if you do not want to do this, I will not stop you from leaving. What do you say? \n\n [yes // no] \n (This is case sensitive. Please use lowercase when answering.)");

    string startChoice = StartPlayerChoice.StartChoice(); //This is a method. This method allows the player to choose if they want to start the game or not.

    if(startChoice == "no") //See Line 9 for more info.
    {
        Console.WriteLine("Very well. I thank you for visiting us, and I hope you come to visit us again. The exit is through the gate to the left.");
    }
    else
    {
        //This Console.WriteLine will ask the player what their name is.
        Console.WriteLine("\n Jolly good! Now, before we begin with the survival games, I would like to know your name.");

        string playerName = GamePlayerName.GameNames(); //This code is a method. This method allows the player to write what their name is.

        //This Console.WriteLine will ask the player which difficulty they want to play. The player is allowed to choose 'easy', 'medium' or 'hard'. The player is instructed to only use lowercase letters.
        Console.WriteLine("\n What a wonderful name you have! Now, before we begin, I want you to choose the difficulty. Your choices are: [easy / medium / hard]. \n (This is case sensitive. Please use lowercase when answering.)");

        string difficultyChoice = GameDifficultyChoice.DifficultyChoice(); //This code is a method. This method allows the player to choose which difficulty they want to play.
        
        if(difficultyChoice == "easy") //If the player writes 'easy', this if-statement will run.
        {
            Console.WriteLine("\n Good Choice for a beginner. You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");
            
            //This Console.WriteLine shows the player what they can choose as weapons.
            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");

            string weaponChoice = PlayerWeaponChoice.WeaponChoice(); //This code is a method. This method allows the player to choose which weapon they want to fight with.

            Console.WriteLine("\n With that done, let the games begin! In Easy, you are going to face four enemies. Good luck!");
            
            for(int i = 0; i < 4; i++) //This for-loop will run 4 times. This means that everything in this for-loop will run 4 times.
            {
                //This string-array randomizes the name of the enemy, with 5 possible names being chosen. 'enemyNames.Length' is used instead of '(0, 5)' since it always has the same size as the array. 
                string[] enemyNames = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                string enemyName = enemyNames[generator.Next(enemyNames.Length)];
                Console.WriteLine();

                //The enemies health is set to 20 every time the fight is over, until this has repeated 4 times.
                //By using 'GameHealth.enemyHealth = GameHealth.enemyEasyHealth;' instead of 'GameHealth.enemyEasyHealth; = 20', the code takes up less space. 
                GameHealth.enemyHealth = GameHealth.enemyEasyHealth;

                while(GameHealth.playerHealth > 0 && GameHealth.enemyHealth > 0) //This while-loop will run as long as the player and the enemy haven't reached 0 hp. Once the enemy reaches 0 hp, the while-loop will repeat until the for-loop it is in has looped as many times as it should. If the player reaches 0 hp, the game will end.
                {
                    //This part of the code displays the health of both the player and the enemy. 
                    //It does this by taking the class 'GameHealth' and putting the the class member 'playerHealth' for the player, and class member 'enemyHealth' for the enemy, at the end of it. This is seen in the name display in the code underneath.
                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight(); //This code is a method. This method allows the player to choose if they want to attack by typing 'a', or defend by typing 'd'. 

                    if(battleChoice == "a") //If the player types 'a', this if-statement will run.
                    {
                        Console.WriteLine($"\n You attack '{enemyName}' with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage); //'generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);' randomizes the damage the player deals to the enemies. This will randomize a number between 1 and 16.
                        GameHealth.enemyHealth -= playerDamage; //This line of code subtracts the amount of damage the player dealt, with the enemy's health.
                        GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth);' will not return 0, but 'GameHealth.enemyHealth', which is larger of the two numbers.
                        Console.WriteLine($"'{playerName}' hit '{enemyName}' with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n '{enemyName}' attacks '{playerName}'!");
                        int enemyEasyDamage = generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage); //'generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage);' randomizes the damage the easy enemies deals to the player. This will randomize a number between 1 and 10.
                        GameHealth.playerHealth -= enemyEasyDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"'{enemyName}' hit '{playerName}', dealing {enemyEasyDamage} damage!");
                    }
                    else //If the player types 'b', this if-statement will run.
                    {
                        Console.WriteLine($"\n '{playerName}' blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"'{enemyName}' attacks '{playerName}'");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock); //'generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);' randomizes the amount of damage the player blocks. This will randomize a number between 1 and 11.
                        int enemyEasyDamage = generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage) - playerBlock; //'generator.Next(GameDamage.enemyEasyMinDamage, GameDamage.enemyEasyMaxDamage)' randomizes the damage the easy enemies deals to the player. This will randomize a number between 1 and 10. This is then subtracted with the amount of damage the player blocks.
                        enemyEasyDamage = Math.Max(enemyEasyDamage, 0);
                        GameHealth.playerHealth -= enemyEasyDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"'{enemyName}' hit '{playerName}', dealing {enemyEasyDamage} damage!");
                    }
                }
            }
        }
        else if(difficultyChoice == "medium") //If the player writes 'medium', this if-statement will run.
        {
            Console.WriteLine("\n Good choice for an experienced player. You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");
            
            //This Console.WriteLine shows the player what they can choose as weapons.
            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");

            string weaponChoice = PlayerWeaponChoice.WeaponChoice(); //This code is a method. This method allows the player to choose which weapon they want to fight with.

            Console.WriteLine("\n With that done, let the games begin! In Medium, you are going to face five enemies. Good luck!");
            
            for(int i = 0; i < 5; i++) //This for-loop will run 5 times. This means that everything in this for-loop will run 5 times.
            {
                //This string-array randomizes the name of the enemy, with 5 possible names being chosen. 'enemyNames.Length' is used instead of '(0, 5)' since it always has the same size as the array. 
                string[] enemyNames = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                string enemyName = enemyNames[generator.Next(enemyNames.Length)];
                Console.WriteLine();

                //The enemies health is set to 40 every time the fight is over, until this has repeated 5 times.
                //By using 'GameHealth.enemyHealth = GameHealth.enemyMediumHealth;' instead of 'GameHealth.enemyMediumHealth; = 40', the code takes up less space. 
                GameHealth.enemyHealth = GameHealth.enemyMediumHealth;

                while(GameHealth.playerHealth > 0 && GameHealth.enemyHealth > 0) //This while-loop will run as long as the player and the enemy haven't reached 0 hp. Once the enemy reaches 0 hp, the while-loop will repeat until the for-loop it is in has looped as many times as it should. If the player reaches 0 hp, the game will end.
                {
                    //This part of the code displays the health of both the player and the enemy. 
                    //It does this by taking the class 'GameHealth' and putting '.playerHealth' and '.enemy...Health' at the end of it, as seen in the name display in the code underneath. 'Easy', 'Medium' and 'Hard' are put in the space where the dots are depending on the difficulty.
                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight(); //This code is a method. This method allows the player to choose if they want to attack by typing 'a', or defend by typing 'd'.

                    if(battleChoice == "a")
                    {
                        Console.WriteLine($"\n You attack {enemyName} with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage); //'generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);' randomizes the damage the player deals to the enemies. This will randomize a number between 1 and 16.
                        GameHealth.enemyHealth -= playerDamage; //This line of code subtracts the amount of damage the player dealt with the enemy's health.
                        GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth);' will not return 0, but 'GameHealth.enemyHealth', which is larger of the two numbers.
                        Console.WriteLine($"{playerName} hit {enemyName} with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n {enemyName} attacks {playerName}!");
                        int enemyMediumDamage = generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage); //'generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage);' randomizes the damage the medium enemies deals to the player. This will randomize a number between 2 and 12.
                        GameHealth.playerHealth -= enemyMediumDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyMediumDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"\n {playerName} blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"{enemyName} attacks {playerName}");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock); //'generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);' randomizes the amount of damage the player blocks. This will randomize a number between 1 and 11.
                        int enemyMediumDamage = generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage) - playerBlock; //'generator.Next(GameDamage.enemyMediumMinDamage, GameDamage.enemyMediumMaxDamage)' randomizes the damage the medium enemies deals to the player. This will randomize a number between 2 and 12. This is then subtracted with the amount of damage the player blocks.
                        enemyMediumDamage = Math.Max(enemyMediumDamage, 0);
                        GameHealth.playerHealth -= enemyMediumDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyMediumDamage} damage!");
                    }
                }
            }
        }
        else //If the player writes 'hard', this if-statement will run.
        {
            Console.WriteLine("\n Good choice for someone looking for a challenge! You will be given the standard equipment that all participants recieve, as well as a weapon you get to choose yourself!");

            //This Console.WriteLine shows the player what they can choose as weapons.
            Console.WriteLine("\n You have 4 choices. Dagger [a] / Greatsword [b] / Bow [c] / Sword [d] \n (This is case sensitive. Please use lowercase letters when choosing your weapon.");

            string weaponChoice = PlayerWeaponChoice.WeaponChoice(); //This code is a method. This method allows the player to choose which weapon they want to fight with.

            Console.WriteLine("\n With that done, let the games begin! In Hard, you are going to face six enemies. Good luck!");
            
            for(int i = 0; i < 6; i++) //This for-loop will run 6 times. This means that everything in this for-loop will run 6 times.
            {
                //This string-array randomizes the name of the enemy, with 5 possible names being chosen. 'enemyNames.Length' is used instead of '(0, 5)' since it always has the same size as the array. 
                string[] enemyNames = {"Slime", "Goblin", "Wolf", "Zombie", "Skeleton"};
                string enemyName = enemyNames[generator.Next(enemyNames.Length)];
                Console.WriteLine();

                //The enemies health is set to 60 every time the fight is over, until this has repeated 6 times.
                //By using 'GameHealth.enemyHealth = GameHealth.enemyHardHealth;' instead of 'GameHealth.enemyHardHealth; = 60', the code takes up less space. 
                GameHealth.enemyHealth = GameHealth.enemyHardHealth;

                while(GameHealth.playerHealth > 0 && GameHealth.enemyHealth > 0) //This while-loop will run as long as the player and the enemy haven't reached 0 hp. Once the enemy reaches 0 hp, the while-loop will repeat until the for-loop it is in has looped as many times as it should. If the player reaches 0 hp, the game will end.
                {
                    //This part of the code displays the health of both the player and the enemy. 
                    //It does this by taking the class 'GameHealth' and putting '.playerHealth' and '.enemy...Health' at the end of it, as seen in the name display in the code underneath. 'Easy', 'Medium' and 'Hard' are put in the space where the dots are depending on the difficulty.
                    Console.WriteLine($"\n Health [{playerName}]: {GameHealth.playerHealth} hp");
                    Console.WriteLine($"Health [{enemyName}]: {GameHealth.enemyHealth} hp");
                
                    Console.WriteLine("\n You are given two options. Type 'a' to attack, and 'd' to defend.");
                    Console.WriteLine("\n Tip: Keep in mind that defending will only reduce the amount of damage received by the enemy, not completely remove it.");

                    Console.WriteLine("\n\n It is now your turn to attack!");
                    Console.WriteLine("\n What is your next move?  ['a' - attack // 'd' - defend]");

                    string battleChoice = GameFight.Fight(); //This code is a method. This method allows the player to choose if they want to attack by typing 'a', or defend by typing 'd'.

                    if(battleChoice == "a")
                    {
                        Console.WriteLine($"\n You attack {enemyName} with your {weaponChoice}!");
                        int playerDamage = generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage); //'generator.Next(GameDamage.playerWeaponMinDamage, GameDamage.playerWeaponMaxDamage);' randomizes the damage the player deals to the enemies. This will randomize a number between 1 and 16.
                        GameHealth.enemyHealth -= playerDamage; //This line of code subtracts the amount of damage the player dealt with the enemy's health.
                        GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.enemyHealth = Math.Max(0, GameHealth.enemyHealth);' will not return 0, but 'GameHealth.enemyHealth', which is larger of the two numbers.
                        Console.WriteLine($"{playerName} hit {enemyName} with their {weaponChoice}, dealing {playerDamage} damage!");

                        Console.WriteLine($"\n {enemyName} attacks {playerName}!");
                        int enemyHardDamage = generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage); //'generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage);' randomizes the damage the hard enemies deals to the player. This will randomize a number between 3 and 16.
                        GameHealth.playerHealth -= enemyHardDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyHardDamage} damage!");
                    }
                    else
                    {
                        Console.WriteLine($"\n {playerName} blocks the incoming attack with their {weaponChoice}!");
                        Console.WriteLine($"{enemyName} attacks {playerName}");
                        int playerBlock = generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock); //'generator.Next(GameBlock.playerMinBlock, GameBlock.playerMaxBlock);' randomizes the amount of damage the player blocks. This will randomize a number between 1 and 11.
                        int enemyHardDamage = generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage) - playerBlock; //'generator.Next(GameDamage.enemyHardMinDamage, GameDamage.enemyHardMaxDamage)' randomizes the damage the hard enemies deals to the player. This will randomize a number between 3 and 16. This is then subtracted with the amount of damage the player blocks.
                        enemyHardDamage = Math.Max(enemyHardDamage, 0);
                        GameHealth.playerHealth -= enemyHardDamage; //This line of code subtracts the amount of damage the enemies dealt, with the player's health.
                        GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth); //'Math.Max' is a Math class method used to return the larger of two specified numbers. Here, 'GameHealth.playerHealth = Math.Max(0, GameHealth.playerHealth);' will not return 0, but 'GameHealth.playerHealth', which is larger of the two numbers.
                        Console.WriteLine($"{enemyName} hit {playerName}, dealing {enemyHardDamage} damage!");
                    }
                }
            }
        }

        if(GameHealth.playerHealth == 0) //This if-statement makes it so that if the hp of the player reaches 0, the game is over.
        {
            Console.WriteLine("\n\n You has been defeated!");
            Console.WriteLine("\n Oooooh, what a shame. You did good. Better luck next time friend!");
        }
        else if(GameHealth.enemyEasyHealth == 0) //This if-statement makes it so that if the hp of all the easy enemies reaches 0, the player wins the game.
        {
            Console.WriteLine("\n\n The enemies have been defeated.");
            Console.WriteLine("\n Would you look at that! Even when you are new to this, you managed to win! Here is your prize, now off you go!");
        }
        else if(GameHealth.enemyMediumHealth == 0) //This if-statement makes it so that if the hp of all the medium enemies reaches 0, the player wins the game.
        {
            Console.WriteLine("\n\n The enemies have been defeated.");
            Console.WriteLine("\n Speldid! I can see that you are experienced at this! Here is your prize, now off you go!");
        }
        else //This if-statement makes it so that if the hp of all the hard enemies reaches 0, the player wins the game.
        {
            Console.WriteLine("\n\n The enemies have been defeated.");
            Console.WriteLine("\n I can see that you have mastered this! Here is your prize, now off you go!");
        }
        

    }

    Console.WriteLine("\n Do you wish to play again? [y/n]"); // This is the end of the while-loop. This Console.WriteLine will give you the option to choose whether you want to restart the game or not. If 'y' is pressed, you start again. If you press 'n', you will exit the game.
    restartGame = Console.ReadLine();
}
Console.ReadLine();

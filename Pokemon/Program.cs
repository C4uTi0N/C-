using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main()
        {
            // INITIALIZE YOUR THREE POKEMONS HERE

            // Charmander
            Move ember = new Move("Ember");
            Move fireBlast = new Move("Fire Blast");

            List<Move> charmanderMoves = new List<Move>();
            charmanderMoves.Add(ember);
            charmanderMoves.Add(fireBlast);
            Pokemon charmander = new Pokemon("Charmander", 3, 52, 43, 39, Elements.Fire, charmanderMoves);

            // Squirtle
            Move bubble = new Move("Bubble");
            Move bite = new Move("Bite");

            List<Move> squirtleMoves = new List<Move>();
            squirtleMoves.Add(bubble);
            squirtleMoves.Add(bite);
            Pokemon squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, squirtleMoves);

            // Bulbasaur
            Move cut = new Move("Cut");
            Move megaDrain = new Move("Mega Drain");
            Move razorLeaf = new Move("Razor Leaf");

            List<Move> bulbasaurMoves = new List<Move>();
            bulbasaurMoves.Add(cut);
            bulbasaurMoves.Add(megaDrain);
            bulbasaurMoves.Add(razorLeaf);
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, bulbasaurMoves);

            List<Pokemon> roster = new List<Pokemon>();
            roster.Add(charmander);
            roster.Add(squirtle);
            roster.Add(bulbasaur);



            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        foreach (Pokemon pokemon in roster)
                        {
                            Console.WriteLine(pokemon.Name);
                        }
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.WriteLine("Choose who should fight: ");

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        
                        Pokemon player = null;
                        int playerPokemonTrue = 0;

                        do
                        {
                            playerPokemonTrue = 0;
                            Console.Write("Your Pokemon: ");
                            string inputPlayer = Console.ReadLine();

                            foreach (Pokemon pokemon in roster)
                            {
                                if (inputPlayer == pokemon.Name)
                                {
                                    player = pokemon;
                                    playerPokemonTrue++;
                                }
                            }

                            if (playerPokemonTrue == 0)
                            {
                                Console.WriteLine("That Pokemon doesnt exist");
                            }
                        } while (playerPokemonTrue == 0);
                        

                        Pokemon enemy = null;
                        int enemyPokemonTrue = 0;

                        do
                        {
                            enemyPokemonTrue = 0;
                            Console.Write("Oppenent Pokemon: ");
                            string inputEnemy = Console.ReadLine();

                            foreach (Pokemon pokemon in roster)
                            {
                                if (inputEnemy == pokemon.Name)
                                {
                                    enemy = pokemon;
                                    enemyPokemonTrue++;
                                }
                            }

                            if (enemyPokemonTrue == 0)
                            {
                                Console.WriteLine("That Pokemon doesnt exist");
                            }
                        } while (enemyPokemonTrue == 0);

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.WriteLine("What move should we use? -> ");

                                foreach (Move moves in player.Moves)
                                {
                                    Console.WriteLine(moves.Name);
                                }


                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int move = -1;
                                int moveTrue = 0;

                                do
                                {
                                    Console.Write("What move should we use? -> ");
                                    moveTrue = 0;

                                    string moveInput = Console.ReadLine();
                                    foreach (Move moves in player.Moves)
                                    {
                                        if (moveInput == moves.Name)
                                        {
                                            moveTrue++;
                                        }
                                    }

                                    if (moveTrue == 0)
                                    {
                                        Console.WriteLine("That Move doesn't exist");
                                    }
                                } while (moveTrue == 0);


                                //CALCULATE AND APPLY DAMAGE
                                int damage = -1;

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    int enemyMove = -1;
                                    int enemyDamage = -1;

                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                }
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER

                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Made by Peter Frandsen

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

            Pokemon player = null;
            Pokemon enemy = null;

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
                        
                        
                        bool playerPokemon = false;

                        do
                        {
                            playerPokemon = false;
                            Console.Write("Your Pokemon: ");
                            string inputPlayer = Console.ReadLine();

                            foreach (Pokemon pokemon in roster)
                            {
                                if (inputPlayer == pokemon.Name)
                                {
                                    player = pokemon;
                                    playerPokemon = true;
                                }
                            }

                            if (!playerPokemon)
                            {
                                Console.WriteLine("That Pokemon doesnt exist");
                                player = null;
                            }
                        } while (!playerPokemon);
                        

                        
                        bool enemyPokemon = false;

                        do
                        {
                            enemyPokemon = false;
                            Console.Write("Oppenent Pokemon: ");
                            string inputEnemy = Console.ReadLine();

                            foreach (Pokemon pokemon in roster)
                            {
                                if (inputEnemy == pokemon.Name)
                                {
                                    enemy = pokemon;
                                    enemyPokemon = true;
                                }
                            }

                            if (!enemyPokemon)
                            {
                                Console.WriteLine("That Pokemon doesnt exist");
                                enemy = null;
                            }
                        } while (!enemyPokemon);

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("\nA wild " + enemy.Name + " appears!");
                            Console.WriteLine(player.Name + " I choose you! ");
                            Console.WriteLine("\n" + player.Name + "'s Moves:");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                int move = -1;

                                //PRINT POSSIBLE MOVES
                                foreach (Move moves in player.Moves)
                                {
                                    move++;
                                    Console.WriteLine(move + ": " + moves.Name);
                                }


                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                bool moveTrue = false;

                                do
                                {
                                    Console.WriteLine("What move should we use? -> ");
                                    move = int.Parse(Console.ReadLine());
                                    moveTrue = false;

                                    if (!moveTrue)
                                    {
                                        Console.WriteLine("That move number doesn't exist");
                                    }
                                } while (!moveTrue);


                                //CALCULATE AND APPLY DAMAGE
                                int damage = -1;

                                damage = player.Attack(enemy);

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                Console.ReadLine();
                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    int enemyMove = -1;
                                    int enemyDamage = -1;

                                    Random rand = new Random();
                                    enemyMove = rand.Next(0, enemy.Moves.Count);
                                    enemyDamage = enemy.Attack(player);

                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */                                

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

                        player.Restore();
                        enemy.Restore();

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

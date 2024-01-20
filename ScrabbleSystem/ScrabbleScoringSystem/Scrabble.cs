using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrabbleScoringSystem{
    public class Scrabble{
        public Scrabble(){
            System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            int countOfPlayer = playerArrangement(); 
            Player[] playersSelected = playerInformationSettings(countOfPlayer);

            mainLoop(playersSelected);
        }

        // This where the game loop processes
        // This method manipulates player's score
        private void mainLoop(Player[] playersSelected){

            Console.WriteLine("\n\n\n\t\t\t\tGame is starting...");

            bool runner = true;
            while(runner){
                bool isIdFound = false;

                System.Console.Write("ID: ");
                string id = Console.ReadLine();

                if(id.ToLower().Equals("exit")){
                    runner = false;
                    continue;
                }

                for(int i = 0; i < playersSelected.Length; i++){
                    if(id.Equals(playersSelected[i].PlayerId)){
                        System.Console.Write($"Score for {playersSelected[i].Name}: ");

                        int score = 0;
                        try {
                            score = Convert.ToInt32(Console.ReadLine());
                        } catch(FormatException e){
                            Console.WriteLine(e.Message);
                            i -= 1;
                            continue;
                        }
                        playersSelected[i].Score = score;
                        isIdFound = true;
                        break;
                    }
                }
                if(!isIdFound){
                    Console.WriteLine("\n");
                    System.Console.WriteLine($"No player has an id of {id}");
                }
            }

            System.Console.WriteLine("\n\n\n\t\t\t\tGame Over");

            // Display scores of each player
            foreach(var scoreOfEachPlayer in playersSelected){
                System.Console.WriteLine($"{scoreOfEachPlayer.Name} : {scoreOfEachPlayer.Score}");
            }
        }

        // Arrangement for the number of players will play
        private int playerArrangement(){
            int countOfPlayer = 0;
            bool hasItCount;
            do{
                try{
                    Console.Write("\n\nHow many players will play the Scrabble: ");
                    countOfPlayer = Convert.ToInt32(Console.ReadLine());
                    hasItCount = true;
                }
                catch (FormatException){
                    System.Console.WriteLine("Text and Symbols are not allowed. Please Try again!");
                    hasItCount = false;
                }finally{
                    if(countOfPlayer > 4){
                        Console.WriteLine($"\nYou can't enter {countOfPlayer} players");
                        Console.WriteLine("The maximum players that you can only enter is 4. Please Try again!");
                        Console.WriteLine();
                        countOfPlayer = 0;
                        hasItCount = false;
                    }else if(countOfPlayer < 0) {
                        Console.WriteLine("\nYou can't enter negative numbers of players. Please Try again!");
                        Console.WriteLine();
                        countOfPlayer = 0;
                        hasItCount = false;
                    } else if(countOfPlayer == 0) {
                        Console.WriteLine($"\n{countOfPlayer} number of player is not allowed. Please Try again!");
                        Console.WriteLine();
                        countOfPlayer = 0;
                        hasItCount = false;
                    }
                }
            } while (!hasItCount);

            Console.WriteLine($"\n{countOfPlayer} players have settled with their respective chairs\n");

            return countOfPlayer;
        }
        
        // Handles player's submissions (id, name)
        private Player[] playerInformationSettings(int countOfPlayer){
            Player[] players = new Player[countOfPlayer];

            for(int i = 0; i < players.Length; i++){
                System.Console.Write($"Enter player #{i+1}'s id: ");
                string playerId = Console.ReadLine();

                System.Console.Write($"Enter player #{i+1}'s name: ");
                string playerName = Console.ReadLine();
                
                try{
                    players[i] = new Player(playerId, playerName);
                }catch(ArgumentException e){
                    System.Console.WriteLine(e.Message);
                    i -= 1;
                    continue;
                }
            }
            System.Console.WriteLine("\n\n\n==========> List of Selected Players <==========");
            for(int i = 0; i < players.Length; i++){
                System.Console.WriteLine($"Player name : {players[i].Name}, Player id : {players[i].PlayerId}");
            }

            return players;
        }
        
    }
}
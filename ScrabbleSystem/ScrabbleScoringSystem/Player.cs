using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrabbleScoringSystem{
    public class Player{
        private string name, playerId;
        private int score;

        public string Name{
            get { return name; }
            private set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentException(nameof(Name), "Name cannot be empty");
                }
                name = value;
            }
        }

        public string PlayerId{
            get { return playerId; }
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentException(nameof(PlayerId),"Id cannot be empty");
                }
                playerId = value;
            }
        }

        public int Score{
            get { return score; }
            set{
                if(!(value < 0))
                    score += value;
                else
                    score += 0;
            }
        }

        public Player(string playerId, string name){
            PlayerId = playerId;
            Name = name;
        }
    }
}
using System;
using System.Collections.Generic;


namespace Assets.Scripts
{
    //luu tru thong tin game
    [Serializable]
    public class GameData
    {
        public int score = 0;
        public string timePlayed;
    }

    [Serializable]
    public class GameDataPlayed
    {
        public List<GameData> plays;
    }
}

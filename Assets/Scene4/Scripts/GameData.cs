using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scene4.Scripts
{
    [Serializable] 
    // lưu trữ thông tin
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

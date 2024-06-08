using System;
using System.Collections.Generic;
<<<<<<< HEAD:Assets/Scene4/Scripts/GameData.cs
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scene4.Scripts
{
    [Serializable] 
    // lưu trữ thông tin
=======


namespace Assets.Scripts
{
    //luu tru thong tin game
    [Serializable]
>>>>>>> main:Assets/Scripts/GameData.cs
    public class GameData
    {
        public int score = 0;
        public string timePlayed;
    }
<<<<<<< HEAD:Assets/Scene4/Scripts/GameData.cs
=======

>>>>>>> main:Assets/Scripts/GameData.cs
    [Serializable]
    public class GameDataPlayed
    {
        public List<GameData> plays;
    }
}

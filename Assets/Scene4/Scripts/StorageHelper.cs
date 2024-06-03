﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scene4.Scripts
{
    using System.IO;
    using UnityEngine;

    public class StorageHelper
    {
        private readonly string filename = "game_data.txt";
        public GameDataPlayed played;

        public void LoadData()
        {
            played = new GameDataPlayed()
            {
                plays = new List<GameData>()
                {

                }
            };
            // đọc file
            string dataAsJson = StorageManager.LoadFromFile(filename);
            if (dataAsJson != null)
            {
                played = JsonUtility.FromJson<GameDataPlayed>(dataAsJson);
            }
        }
        public void SaveData()
        {
            string dataAsJson = JsonUtility.ToJson(played);
            StorageManager.SaveToFile(filename, dataAsJson);
        }
    }
}

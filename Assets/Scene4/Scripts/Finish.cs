using Assets.Scene4.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject infoCanvas;
    [SerializeField] GameObject finishCanvas;
    private StorageHelper storageHelper;
    private GameDataPlayed played;
    private void Start()
    {
        storageHelper = new StorageHelper();
        storageHelper.LoadData();
        played = storageHelper.played;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            infoCanvas.SetActive(false);
            var score = FindObjectOfType<GameCotroller>().GetScore();
            // Lưu thành tích của người chơi
            var gameData = new GameData()
            {
                score = score,
                timePlayed = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            played.plays.Add(gameData);
            storageHelper.SaveData();
            // tải dữ liệu trong file hiện thị lên thành tích

            finishCanvas.SetActive(true);
        }
    }
}

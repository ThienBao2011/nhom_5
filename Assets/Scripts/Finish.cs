using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject information;
    [SerializeField] GameObject finish;

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
            information.SetActive(false);
            var score = FindObjectOfType<GameController>().GetScore();
            // Luu lai thanh tich nguoi choi
            var gameData = new GameData()
            {
                score = score,
                timePlayed = DateTime.Now.ToString("yyyy-MM-dd")
            };
            played.plays.Add(gameData);
            storageHelper.SaveData();
            //tai du lieu trong file hien thi len  bang thanh tich
            storageHelper.LoadData();
            played = storageHelper.played;
            Debug.Log("Count: " + played.plays.Count);
            finish.SetActive(true);
        }
    }
}

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

    [SerializeField] GameObject row;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
            // sap xep giam dan theo diem
            //lay top 5
            played.plays.Sort((x, y) => y.score.CompareTo(x.score));
            var plays = played.plays.GetRange(0, Math.Min(5, played.plays.Count));

            //hien thi len giao dien
            for (int i = 0; i < plays.Count; i++)
            {
                var rowInstance = Instantiate(row, row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].score.ToString();
                rowInstance.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].timePlayed;
                rowInstance.SetActive(true);
            }
            //hien thi giao dien ket thuc
            finish.SetActive(true);
        }
    }
}

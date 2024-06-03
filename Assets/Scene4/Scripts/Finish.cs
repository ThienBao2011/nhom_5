using Assets.Scene4.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject infoCanvas;
    [SerializeField] GameObject finishCanvas;
    private StorageHelper storageHelper;
    private GameDataPlayed played;
    [SerializeField] GameObject row;
    // Start is called before the first frame update
    void Start()
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
            var gameData = new GameData()
            {
                score = score,
                timePlayed = DateTime.Now.ToString("yyyy-MM-dd")
            };
            played.plays.Add(gameData);
            storageHelper.SaveData();

            storageHelper.LoadData();
            played = storageHelper.played;
            Debug.Log("Count: " + played.plays.Count);

            played.plays.Sort((x, y) => y.score.CompareTo(x.score));
            played.plays = played.plays.GetRange(0, Math.Min(5, played.plays.Count));
            for (int i = 0; i < played.plays.Count; i++)
            {
                var rowInstance = Instantiate(row, row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = played.plays[i].score.ToString();
                rowInstance.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = played.plays[i].timePlayed;
                rowInstance.SetActive(true);
            }
            finishCanvas.SetActive(true);
        }
    }
}

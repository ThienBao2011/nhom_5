<<<<<<< HEAD:Assets/Scene4/Scripts/Coin.cs
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> main:Assets/Scripts/Coin.cs
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
<<<<<<< HEAD:Assets/Scene4/Scripts/Coin.cs
    [SerializeField] AudioClip coinPickup;

    private bool isCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
=======
    [SerializeField] AudioClip Coin_flip;

    public GameObject CoinEffect;

    //Dong xu da duoc nhat chua
    private bool isCollected = false;

    public void OnTriggerEnter2D(Collider2D other)
>>>>>>> main:Assets/Scripts/Coin.cs
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
<<<<<<< HEAD:Assets/Scene4/Scripts/Coin.cs
            // Tăng điểm
            FindAnyObjectByType<GameCotroller>().AddCore((int)coinValue);
            AudioSource.PlayClipAtPoint(coinPickup, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
=======
            //tang diem
            FindObjectOfType<GameController>().AddScore((int)coinValue);
            AudioSource.PlayClipAtPoint(Coin_flip, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);

            GameObject hieuung = Instantiate(CoinEffect, transform.position, transform.localRotation );

            Destroy(hieuung, 3);
        }
    }

>>>>>>> main:Assets/Scripts/Coin.cs
}

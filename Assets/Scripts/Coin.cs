using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip Coin_flip;

    public GameObject CoinEffect;

    //Dong xu da duoc nhat chua
    private bool isCollected = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            //tang diem
            FindObjectOfType<GameController>().AddScore((int)coinValue);
            AudioSource.PlayClipAtPoint(Coin_flip, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);

            GameObject hieuung = Instantiate(CoinEffect, transform.position, transform.localRotation );

            Destroy(hieuung, 3);
        }
    }

}

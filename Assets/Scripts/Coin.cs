using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip Coin_flip;

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
        }
    }

}

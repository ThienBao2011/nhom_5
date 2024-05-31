using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip Coin_flip;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(Coin_flip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}

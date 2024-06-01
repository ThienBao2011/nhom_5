using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject information;
    [SerializeField] GameObject finish;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            information.SetActive(false);
            finish.SetActive(true);
        }
    }
}

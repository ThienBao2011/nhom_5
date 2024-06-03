using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Vector3 offset;
    private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        healthSlider.maxValue = enemyHealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = enemyHealth.currentHealth;
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}

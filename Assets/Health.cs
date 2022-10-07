using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float bulletDamage;

    private float currentHealth;

    public Slider healthBar;

 
    void Start()
    {
        currentHealth = maxHealth ;
    }

   
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = Mathf.Clamp(currentHealth, 0, maxHealth) / maxHealth;

        if (currentHealth <= 0)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Bullet"))
        {
            TakeDamage(bulletDamage);
        }
    }
}

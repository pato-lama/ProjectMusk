using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour {
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;
    public RectTransform healthBar;

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
       
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
                Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }
        }
        if (!destroyOnDeath)
            onChangeHealth(currentHealth);
    }

    void onChangeHealth (int currentHealth)
    {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    void RpcRespawn()
    {
            // move back to zero location
        transform.position = Vector3.zero;
        
    }
}


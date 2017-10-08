using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;

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
    }

    void RpcRespawn()
    {
            // move back to zero location
        transform.position = Vector3.zero;
        
    }
}

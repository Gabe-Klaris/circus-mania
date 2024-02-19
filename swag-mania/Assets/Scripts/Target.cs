using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
   private float health = 10000f;

   public void TakeDamage(float damage)
   {
        health -= damage;
        Debug.Log("Object Health is:" + health);
        if (health <= 0) {
            Destroy(gameObject);
        }
   }
}

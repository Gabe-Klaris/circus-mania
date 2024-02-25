using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tshirt_bullet : MonoBehaviour{ 

      // public int damage = 1;
      // public GameObject hitEffectAnim;
      public float SelfDestructTime = 2.0f;
      public float SelfDestructVFX = 0.5f; 
      // public SpriteRenderer projectileArt;

      void Start(){
           // projectileArt = GetComponentInChildren<SpriteRenderer>();
           selfDestruct();
      }

      //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
      void OnTriggerEnter(Collider other){
            
           if (other.gameObject.tag != "Player") {
                  // GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
                  // projectileArt.enabled = false;
                  // Destroy (animEffect, 0.5);
                  StartCoroutine(selfDestructHit());
            }
      }

      IEnumerator selfDestructHit(){
            yield return new WaitForSeconds(SelfDestructVFX);
            //Destroy (VFX);
            Destroy (gameObject);
      }

      IEnumerator selfDestruct(){
            yield return new WaitForSeconds(SelfDestructTime);
            Destroy (gameObject);
      }
}
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour{ 

      //public Animator animator;
      public Transform firePoint;
      public GameObject projectilePrefab; 
      public float projectileSpeed = 10f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f; 

      public AudioClip fireSound; 

      private AudioSource m_audiosource;


      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
           // source = GetComponent<AudioSource>();
      }

      void Update(){
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        playerFire();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
            }
      }

      void playerFire(){
            m_audiosource = GetComponent<AudioSource>();
            m_audiosource.clip = fireSound;
            m_audiosource.Play();
            //animator.SetTrigger ("Fire"); 
            Vector3 fwd = (firePoint.position - this.transform.position).normalized; 
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity); 
            projectile.GetComponent<Rigidbody>().AddForce(fwd * projectileSpeed, ForceMode.Impulse); 
            Debug.Log("Sound?");
      } 
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;

    float timeSinceLastShot;

    private void Start(){
        PlayerShoot.shootInput += Shoot;
    }

    // private bool CanShoot () => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    // public void StartReload();


    public void Shoot()
    {
        if (gunData.currentAmmo > 0) {
            //if (CanShoot()) {
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Shirts.ShootShirt();
                    Debug.Log("hit?");
                    Debug.Log(hitInfo.transform.name);

                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                // Add new function for effects later: OnGunShot()
            //}

        Debug.Log("shoot!");
        }

    }

    private void Update(){
        timeSinceLastShot += Time.deltaTime;

        // Debug.Log("Line?");
        Debug.DrawRay(muzzle.position, muzzle.forward, Color.green);

    }
}

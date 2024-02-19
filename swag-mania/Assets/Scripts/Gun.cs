using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;

    float timeSinceLastShot;

    private void Start(){
        PlayerShoot.shootInput += Shoot;
    }

    // private bool CanShoot () => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (gunData.currentAmmo > 0) {
            //if (CanShoot()) {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                // Add new function for effects later: OnGunShot()
            //}
        }

    }

    private void Update(){
        timeSinceLastShot += Time.deltaTime;
    }
}

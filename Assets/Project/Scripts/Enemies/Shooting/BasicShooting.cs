using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float damage = 10;
    public float timeBtwFullShootingRound = 1.0f;
    public float bulletForce = 20;
    public Transform[] shootingPoints;
    public float waitBtwBullets = 0f;

    private bool isShooting = false;

    private void Update() {
        if(!Utils.instance.CheckIfOutOfBounds(transform) && !isShooting) StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        isShooting = true;
        foreach(var shootingPoint in shootingPoints) {
            GameObject bulletPrefab = Instantiate(this.bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            Rigidbody2D bulletRB = bulletPrefab.GetComponent<Rigidbody2D>();
            Bullet bullet = bulletPrefab.GetComponent<Bullet>();
            bullet.SetDamage(damage);
            bulletRB.AddForce(shootingPoint.up * bulletForce, ForceMode2D.Impulse);

            if(waitBtwBullets > 0) yield return new WaitForSeconds(waitBtwBullets);
        }
        yield return new WaitForSeconds(timeBtwFullShootingRound);

        isShooting = false;

    }
}

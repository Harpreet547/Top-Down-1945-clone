using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    // TODO: Check if this is the best place for bullet damage
    public float damage = 10;
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    void Start() {
        
    }

    void Update() {
        bool isFiring = GameManager.instance.inputManager.isFiring;
        if(isFiring) Shoot();
    }

    private void Shoot() {
        foreach(var point in firePoints) ShootFromPoint(point);
    }

    private void ShootFromPoint(Transform point) {
        GameObject bulletPrefab = Instantiate(this.bulletPrefab, point.position, point.rotation);
        Rigidbody2D bulletRB = bulletPrefab.GetComponent<Rigidbody2D>();
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.SetDamage(damage);
        bulletRB.AddForce(point.up * bulletForce, ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

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
        GameObject bullet = Instantiate(bulletPrefab, point.position, point.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(point.up * bulletForce, ForceMode2D.Impulse);
    }
}

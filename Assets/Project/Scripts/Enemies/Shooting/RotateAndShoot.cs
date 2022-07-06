using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndShoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public float damage = 10;
    public float timeBtwShoots = 1.0f;
    public float bulletForce = 5;
    public Transform[] shootingPoints;
    public Transform shootingPointCenter;
    public float rotationSpeed = 5;
    public bool isAntiClockRotation = false;
    public float invertRotationAfter = 0;

    private bool isShooting = false;
    private bool isWaitingToInvertRotation = false;

    private void Update() {
        if(!Utils.instance.CheckIfOutOfBounds(transform) && !isShooting) StartCoroutine(Shoot());

        shootingPointCenter.Rotate(0, 0, Time.deltaTime * rotationSpeed * (isAntiClockRotation ? -1 : 1));

        if(invertRotationAfter > 0 && !isWaitingToInvertRotation) StartCoroutine(InvertRotation()); 
    }

    IEnumerator Shoot() {
        isShooting = true;
        foreach(var shootingPoint in shootingPoints) {
            GameObject bulletPrefab = Instantiate(this.bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            Rigidbody2D bulletRB = bulletPrefab.GetComponent<Rigidbody2D>();
            Bullet bullet = bulletPrefab.GetComponent<Bullet>();
            bullet.SetDamage(damage);
            bulletRB.AddForce(shootingPoint.up * bulletForce, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(timeBtwShoots);

        isShooting = false;
    }

    IEnumerator InvertRotation() {
        isWaitingToInvertRotation = true;
        isAntiClockRotation = !isAntiClockRotation;
        yield return new WaitForSeconds(invertRotationAfter);

        isWaitingToInvertRotation = false;
    }
}

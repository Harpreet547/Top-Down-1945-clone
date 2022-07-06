using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveForwardEnemy : MonoBehaviour, IPlayerDamage, Killable {

    public float speed = 2;
    public float _playerDamageOnCollision = 10f;

    [HideInInspector]
    public bool isRotationUpdated = false;


    public float _health = 10;

    [HideInInspector]
    public float playerDamageOnCollision { get => _playerDamageOnCollision; }
    [HideInInspector]
    public float health { get => _health; set { _health = value; } }

    private Rigidbody2D rb;

    void Start() {
        if(!isRotationUpdated) SetRotation();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    public void SetRotation() {
        GameObject player = GameManager.instance.GetPlayer();
        transform.rotation = Utils.instance.GetRotationAngleTowardsTarget(transform.position, player.transform.position);
    }

    public void CheckIfKilled() {
        if(health <= 0) {
            // TODO: Death animation
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        if(Utils.instance.CheckIfOutOfBounds(transform)) return;

        health -= damage;
        CheckIfKilled();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Utils.instance.playerTag)) {
            other.gameObject.GetComponent<Killable>().TakeDamage(playerDamageOnCollision);
        }
    }
}

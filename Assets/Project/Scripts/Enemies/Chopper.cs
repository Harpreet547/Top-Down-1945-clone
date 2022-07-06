using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Chopper : FollowWaypoints, IPlayerDamage, Killable {

    public float speed = 2;

    public float _playerDamageOnCollision = 15f;

    private Rigidbody2D rb;

    public float playerDamageOnCollision { get => _playerDamageOnCollision; }
    public float _health = 10;
    [HideInInspector]
    public float health { get => _health; set { _health = value; } }

    private new void Awake() {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    new void Update() {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 0.1f);   
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

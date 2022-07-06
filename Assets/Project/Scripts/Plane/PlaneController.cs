using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour, Killable {

    [Header("Movement")]
    public float speedX = 50;
    public float speedY = 50;
    public float _health = 10;

    [HideInInspector]
    public float health { get => _health; set { _health = value; } }
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Movement();
    }

    private void Movement() {
        Vector2 inputVector = GameManager.instance.inputManager.inputVector;
        // Force method
        // rb.AddForce(new Vector2(
        //     speedX * inputVector.x * Time.deltaTime,
        //     speedY * inputVector.y * Time.deltaTime
        // ));
        // Move position method
        // rb.MovePosition(rb.position + inputVector * speedX * Time.deltaTime);
        // Velocity method
        rb.velocity = rb.velocity + new Vector2(
            speedX * inputVector.x * Time.deltaTime,
            speedY * inputVector.y * Time.deltaTime
        );
    }

    public void CheckIfKilled() {
        if(health <= 0) {
            // TODO: Death animation
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        CheckIfKilled();
    }

}

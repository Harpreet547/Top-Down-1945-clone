using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveForwardEnemy : MonoBehaviour, IPlayerDamage {

    public float speed = 2;
    public float _playerDamageOnCollision = 10f;

    [HideInInspector]
    public bool isRotationUpdated = false;

    private Rigidbody2D rb;

    [HideInInspector]
    public float playerDamageOnCollision { get => _playerDamageOnCollision; }

    void Start() {
        if(!isRotationUpdated) SetRotation();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    public void SetRotation() {
        GameObject player = GameManager.instance.GetPlayer();
        transform.rotation = Utils.instance.GetRotationAngleTowardsTarget(transform.position, player.transform.position);
    }
}

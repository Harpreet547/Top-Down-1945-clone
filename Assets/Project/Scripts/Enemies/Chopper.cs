using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Chopper : FollowWaypoints, IPlayerDamage {

    public float speed = 2;

    public float _playerDamageOnCollision = 15f;

    private Rigidbody2D rb;

    public float playerDamageOnCollision { get => _playerDamageOnCollision; }

    private new void Awake() {
        base.Awake();
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    new void Update() {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 0.1f);
    }

}

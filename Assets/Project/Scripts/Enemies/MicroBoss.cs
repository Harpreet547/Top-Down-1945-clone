using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroBoss : FollowWaypoints {
    public float speed = 2;

    void Start() {
        
    }

    new void Update() {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 0.1f); 
    }
}

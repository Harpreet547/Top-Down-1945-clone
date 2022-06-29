using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour {

    private Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if(target == null) return;

        Vector2 position = transform.position;
        float x = target.position.x - position.x;
        float y = target.position.y - position.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static Utils instance;
    public string playerTag = "Player";
    private void Awake() {
        instance = this;
        playerTag = "Player";
    }
    public Quaternion GetRotationAngleTowardsTarget(Vector2 position, Vector2 targetPosition) {
        float x = targetPosition.x - position.x;
        float y = targetPosition.y - position.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}

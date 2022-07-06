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

    public bool CheckIfOutOfBounds(Transform target) {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint (target.position);
        if ((screenPosition.x > Screen.width) || (screenPosition.x < 0 - Screen.width)  || (screenPosition.y > Screen.height) || (screenPosition.y < 0 - Screen.height)) {
            return true;
        } else {
            return false;
        }
    }
}

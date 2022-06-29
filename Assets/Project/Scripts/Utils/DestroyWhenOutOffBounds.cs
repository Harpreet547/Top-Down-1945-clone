using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOffBounds : MonoBehaviour {

    [Header("Set to true if your object spawns outside bounds")]
    public bool toggle = false;

    private bool shouldDestroy = true;
    private void Start() {
        if(toggle) shouldDestroy = false;
    }

    void Update() {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
        // destroys object if it goes beyond bounds + 10% of bounds
        if ((screenPosition.x > Screen.width * 1.1f) || (screenPosition.x < 0 - Screen.width * 0.1f)  || (screenPosition.y > Screen.height * 1.1f) || (screenPosition.y < 0 - Screen.height * 0.1f)) {
            if(shouldDestroy) Destroy (gameObject);
        } else {
            if(toggle) shouldDestroy = true;
        }
    }
}

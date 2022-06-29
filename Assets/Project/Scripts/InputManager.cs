using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Vector2 inputVector { get; private set; }
    public bool isFiring { get; private set; }
    void Start() {
        
    }

    void Update() {
        inputVector = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        if(Input.GetButtonDown("Fire1")) {
            isFiring = true;
        } else {
            isFiring = false;
        }
    }
}

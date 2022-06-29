using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }
    public InputManager inputManager { get; private set; }
    private void Awake() {
        instance = this;
        inputManager = GetComponentInChildren<InputManager>();
    }

    public GameObject GetPlayer() {
        return GameObject.FindGameObjectWithTag("Player");
    }
}

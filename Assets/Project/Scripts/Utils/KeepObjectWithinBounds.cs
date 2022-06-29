using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjectWithinBounds : MonoBehaviour {
    
    public Renderer spriteRenderer;

    private Vector2 screenBounds;
    private Bounds bounds;
    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bounds = spriteRenderer.bounds;
    }
    private void Update() {
        Vector2 viewPos = transform.position;

        if(viewPos.x > screenBounds.x - (bounds.size.x / 2)) {
            viewPos.x = screenBounds.x - (bounds.size.x) / 2;
        } else if(viewPos.x < (screenBounds.x * -1) + (bounds.size.x / 2)) {
            viewPos.x = (screenBounds.x * -1) + (bounds.size.x / 2);
        }

        if(viewPos.y > screenBounds.y - (bounds.size.y / 2)) {
            viewPos.y = screenBounds.y - (bounds.size.y / 2);
        } else if(viewPos.y < (screenBounds.y * -1) + (bounds.size.y / 2)) {
            viewPos.y = (screenBounds.y * -1) + (bounds.size.y / 2);
        }

        transform.position = viewPos;
    }
}

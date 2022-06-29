using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemyMovementOnCollision : MonoBehaviour {

    private Rigidbody2D rb;
    private IPlayerDamage playerDamage;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerDamage = GetComponent<IPlayerDamage>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Utils.instance.playerTag)) {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            // TODO: Damage Player
            // TODO: Explosion effect
            Destroy(gameObject);
        }
    }

    // private void OnCollisionExit2D(Collision2D other) {
    //     if(rb == null) return;
    //     if(other.gameObject.CompareTag(Utils.instance.playerTag)) {
    //         rb.isKinematic = false;
    //         rb.velocity = Vector2.zero;
    //     }
    // }
}

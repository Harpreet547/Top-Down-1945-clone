using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private float damage = 10f;

    private void OnTriggerEnter2D(Collider2D other) {
        // TODO: Damage on collision;
        // TODO: Explosion effect;
        Destroy(gameObject);
        Killable killable = other.gameObject.GetComponent<Killable>();
        if(killable != null) {
            killable.TakeDamage(damage);
        }
    }

    public void SetDamage(float damageVal) {
        damage = damageVal;
    }
}

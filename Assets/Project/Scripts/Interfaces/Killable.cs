using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Killable {
    public float health { get; set; }
    public void CheckIfKilled();
    public void TakeDamage(float damage);
   
}

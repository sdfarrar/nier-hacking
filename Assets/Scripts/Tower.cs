using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDamageable {

    public int Health = 4;

    public void TakeDamage(DamageDealer damageDealer) {
        Health -= damageDealer.DamageAmount;
        if(Health<=0) {
            KillSelf();
        }
    }

    private void KillSelf() {
        Destroy(this.gameObject);
    }

}

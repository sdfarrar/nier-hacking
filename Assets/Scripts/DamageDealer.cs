﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    public LayerMask Damageables;
    public int DamageAmount;

    private void OnTriggerEnter(Collider other) {
        if(!CanDamage(other)){ return; }
        if(!Damage(other)){ return; }
        KillSelf();
    }

    private bool CanDamage(Collider other){
        int layer = other.gameObject.layer;
        return Damageables == (Damageables | (1 << layer));
    }

    private bool Damage(Collider other) {
        IDamageable obj = other.GetComponent<IDamageable>();
        if(obj==null){ return false; }
        obj.TakeDamage(this);
        return true;
    }

    private void KillSelf() {
        Destroy(this.gameObject);
    }

}

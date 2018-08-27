using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    public LayerMask Damageables;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("DO I KILL?");
        if(!CanDamage(other)){ return; }
        Debug.Log("YES");
    }

    private bool CanDamage(Collider other){
        int layer = other.gameObject.layer;
        Debug.Log(LayerMask.LayerToName(layer));
        return Damageables == (Damageables | (1 << layer));
    }
}

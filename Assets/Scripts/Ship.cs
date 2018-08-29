using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable {

    public int Health = 3;
    public Transform LeftWing;
    public Transform RightWing;
    public Turret turret;

	void Start() {
		
	}
	
	void Update() {
		
	}

    public void TakeDamage(DamageDealer damageDealer) {
        Health -= damageDealer.DamageAmount;
        RightWing.gameObject.SetActive(Health>2);
        LeftWing.gameObject.SetActive(Health>1);
        if(Health<=0){ KillSelf(); }
    }

    private void KillSelf() {
        Destroy(this.gameObject);
    }

}

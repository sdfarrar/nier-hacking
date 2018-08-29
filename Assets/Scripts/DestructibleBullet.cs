using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBullet : Bullet, IDamageable {

	public int Health = 2;

	public void TakeDamage(DamageDealer damageDealer) { 
		Health -= damageDealer.DamageAmount;
		if(Health<=0){ KillSelf(); }
	}

	private void KillSelf() {
		Destroy(this.gameObject);
	}

}

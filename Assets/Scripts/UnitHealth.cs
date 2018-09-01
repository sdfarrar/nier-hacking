using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour, IDamageable {

	public int Health;
	public float InvulnerabilityTime = 0.5f;
	public UnityEvent OnDeathEvent;
	//public UnityEvent<int> OnDamageEvent;
	public IntegerEvent OnDamageEvent;

    public void TakeDamage(DamageDealer damageDealer){
		Debug.Log(Health + " - " + damageDealer.DamageAmount);
        Health -= damageDealer.DamageAmount;
		if(Health<=0){
			OnDeathEvent.Invoke();
			Destroy(this.gameObject);
			return;
		}

		OnDamageEvent.Invoke(Health);
		//TODO iframes
    }

}

[System.Serializable]
public class IntegerEvent : UnityEvent<int> {}
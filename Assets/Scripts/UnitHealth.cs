using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour, IDamageable {

	public IntegerReference StartingHealth;
	public IntegerReference Health;
	public float InvulnerabilityTime = 0.5f;
	public UnityEvent OnDeathEvent;
	public IntegerEvent OnDamageEvent;

	void Start(){
		Health.Value = StartingHealth.Value;
	}

    public void TakeDamage(DamageDealer damageDealer){
		Health.Value -= damageDealer.DamageAmount;
		if(Health.Value<=0){
			OnDeathEvent.Invoke();
			Destroy(this.gameObject);
			return;
		}

		OnDamageEvent.Invoke(Health.Value);
		//TODO iframes
    }

}

[System.Serializable]
public class IntegerEvent : UnityEvent<int> {}
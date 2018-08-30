using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable {

    public int Health = 3;
    public Transform LeftWing;
    public Transform RightWing;
    public Turret turret;

    //TODO move all input stuff to an input class
    private bool rtPressed;
    private bool rtHeld;

	void Start() {
		
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Mouse0) || GetRightTriggerDown()){
            turret.Fire();
        }
	}

    private bool GetRightTriggerDown(){
        float rtInput = Input.GetAxis("XboxRightTrigger");
        if(rtHeld && rtPressed){ rtPressed = false; }
        if(!rtHeld && rtInput > 0.5f){ rtPressed = rtHeld = true; }
        if(rtInput==0){ rtPressed = rtHeld = false; }
        return rtPressed;
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

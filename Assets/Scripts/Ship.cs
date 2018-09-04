using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Transform LeftWing;
    public Transform RightWing;
    public Turret turret;

    //TODO move all input stuff to an input class
    private bool rtPressed;
    private bool rtHeld;

	void Start() {
		
	}
	
	void Update() {
		//if(Input.GetKeyDown(KeyCode.Mouse0) || GetRightTriggerDown()){
		if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetAxis("XboxRightTrigger")!=0){
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

    public void DamageTaken(int currentHealth){
        RightWing.gameObject.SetActive(currentHealth>2);
        LeftWing.gameObject.SetActive(currentHealth>1);
    }

    public void Kill() {
        Destroy(this.gameObject);
    }

}

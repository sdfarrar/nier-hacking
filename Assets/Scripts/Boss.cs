using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public Transform LeftBounds;
	public Transform RightBounds;
	public float Speed = 50;
	
	private bool movingRight = true;
    private UnitHealth hp;

	void Awake() {
		hp = GetComponent<UnitHealth>();
	}

    void Start(){
        if(hp.Invulnerable){
            Debug.Log("Enable particles");
        }
    }

	void Update() {
		if(movingRight){
			MoveTowards(RightBounds);
			if(transform.position == RightBounds.position){ movingRight = false; }
		}else{
			MoveTowards(LeftBounds);
			if(transform.position == LeftBounds.position){ movingRight = true; }
		}
		
	}

    private void MoveTowards(Transform target) {
		transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

}

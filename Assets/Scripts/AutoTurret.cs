using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : Turret {

	void Start(){
		InvokeRepeating("Fire", 0, FireDelay);
	}

	public override bool CanFire(){
		return true;
	}
}

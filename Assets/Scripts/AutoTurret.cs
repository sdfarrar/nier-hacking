using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : Turret {

	void Awake(){
		InvokeRepeating("Fire", 0, FireDelay);
	}

	public override bool CanFire(){
		return true;
	}
}

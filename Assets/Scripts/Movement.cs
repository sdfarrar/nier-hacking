using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 10f;

	void Awake() {
	}
	
	void Update() {
		Move();
		Rotate1();
		//Rotate2();
	}

	private void Move(){
		Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0, Input.GetAxis("LeftStickVertical"));
		transform.position += moveDirection * Speed * Time.deltaTime;
	}

	private void Rotate1(){
		float rx = Input.GetAxis("RightStickHorizontal");
		float ry = Input.GetAxis("RightStickVertical")*-1;
		float angle = Mathf.Atan2(rx, ry) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, angle, 0);
		//Debug.Log("x: " + rx + " | y: " + ry + " | angle: " + angle);

	}

	private void Rotate2(){
		Vector3 lookDirection = Vector3.right * Input.GetAxis("RightStickHorizontal") + Vector3.forward * Input.GetAxis("RightStickVertical") * -1;
		if(lookDirection.sqrMagnitude>0){
			//Debug.Log(lookDirection);
			transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
		}

	}
}

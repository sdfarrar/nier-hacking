using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 10f;
	public float maxRotationSpeed = 720;

	void Awake() {
	}
	
	void Update() {
		Move();
		Rotate();
	}

	private void Move(){
		Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0, Input.GetAxis("LeftStickVertical"));
		transform.position += moveDirection * Speed * Time.deltaTime;
	}

	//private void Rotate(){
	//	float rx = Input.GetAxis("RightStickHorizontal");
	//	float ry = -Input.GetAxis("RightStickVertical");
	//	float angle = Mathf.Atan2(rx, ry) * Mathf.Rad2Deg;
	//	transform.rotation = Quaternion.Euler(0, angle, 0);
	//}

	private void Rotate(){
		Vector3 moveDirection = Vector3.forward * -Input.GetAxis("LeftStickHorizontal") + Vector3.right * Input.GetAxis("LeftStickVertical");
		Vector3 lookDirection = Vector3.right * Input.GetAxis("RightStickHorizontal") + Vector3.forward * -Input.GetAxis("RightStickVertical");
		if(lookDirection.sqrMagnitude>0){
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection*Time.deltaTime,Vector3.up), maxRotationSpeed*Time.deltaTime);
		}else if(moveDirection.sqrMagnitude>0){
			transform.rotation = Quaternion.LookRotation(moveDirection*Time.deltaTime,Vector3.up);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update() {
        //TODO Test inputs with controller
		Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0, Input.GetAxis("LeftStickVertical"));
		Vector3 lookDirection = new Vector3(Input.GetAxis("RightStickHorizontal"), 0, Input.GetAxis("RightStickVertical"));

        transform.rotation = Quaternion.Euler(lookDirection);
        rb.MovePosition(moveDirection);

        //rb.velocity = moveDirection * speed * Time.deltaTime;
        //transform.LookAt(transform.position + lookDirecation, /*-Vector3.forward*/);
	}
}

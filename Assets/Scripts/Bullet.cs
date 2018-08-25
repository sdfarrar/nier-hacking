using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private Vector3 velocity;
    private Rigidbody rb;

	void Start() {
        rb = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
	}

    public void Initialize(Vector3 direction, float speed){
        this.velocity = direction * speed;
        transform.rotation = Quaternion.LookRotation(this.velocity, Vector3.up);
        //Debug.Log("Vel: " + direction + " | Rot: " + transform.rotation.eulerAngles);
    }
	
	void Update() {
		rb.velocity = velocity;
	}

}

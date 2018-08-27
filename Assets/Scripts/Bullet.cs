using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private Vector3 velocity;
    private Rigidbody rb;

	void Awake() {
        rb = GetComponent<Rigidbody>();
	}

    public void Initialize(Vector3 direction, float speed){
        this.velocity = direction * speed;
        transform.rotation = Quaternion.LookRotation(this.velocity, Vector3.forward + Vector3.right);
    }
	
	void Update() {
		rb.velocity = velocity;
	}

}

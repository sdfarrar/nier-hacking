using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Bullet BulletPrefab;
    public float BulletSpeed;
    public Transform FireDirection;
    public bool InvertDirection;
    public float FireDelay;

    private float nextFire;

	void Start() {
	}
	
	void Update() {
	}

    public bool CanFire() {
		return Time.time>=nextFire;
    }

    public void Fire(){
        if(!CanFire()){ return; }
        nextFire = Time.time + FireDelay;

        Vector3 direction = ComputeFireDirection();
        Bullet bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);
        bullet.Initialize(direction, BulletSpeed);
    }

    private Vector3 ComputeFireDirection() {
        Vector3 dir = (transform.position - FireDirection.position).normalized;
        return (InvertDirection) ? -dir : dir;
    }

}

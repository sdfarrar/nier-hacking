using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Bullet BulletPrefab;
    public float BulletSpeed;
    public Transform FireDirection;
    public bool InvertDirection;
    public float FireRate;

    private float timeSinceLastFire;

	void Start() {
		timeSinceLastFire = FireRate; // so we can fire immediately
	}
	
	void Update() {
        timeSinceLastFire += Time.deltaTime;
		if(timeSinceLastFire>=FireRate){
            Fire();
            timeSinceLastFire = 0;
        }
	}

    private Vector3 ComputeFireDirection() {
        Vector3 dir = (transform.position - FireDirection.position).normalized;
        return (InvertDirection) ? -dir : dir;
    }

    private void Fire(){
        Vector3 direction = ComputeFireDirection();
        // Determine rotation
        Bullet bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);
        bullet.Initialize(direction, BulletSpeed);
    }
}

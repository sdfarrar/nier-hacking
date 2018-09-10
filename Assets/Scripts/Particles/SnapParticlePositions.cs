using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SnapParticlePositions : MonoBehaviour {

    public Transform target;

    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

	void Awake() {
		ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
	}
	
	void LateUpdate() {
        int alive = ps.GetParticles(particles);
        Debug.Log("alive: " + alive);
        for(int i=0; i<alive; ++i){
            particles[i].position = particles[i].position.With(x:target.position.x, z:target.position.z);
        }
        ps.SetParticles(particles, alive);
	}
}

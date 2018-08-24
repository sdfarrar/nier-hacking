using UnityEngine;

public class Orbiter : MonoBehaviour {

    public Transform Target;
    public float OrbitDegreesPerSec = 180.0f;

	void LateUpdate() {
        Orbit();
	}

    private void Orbit(){
        if(Target==null){ return; }
        transform.RotateAround(Target.position, Vector3.up, OrbitDegreesPerSec * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform Target;
    public Vector3 Offset;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

	void LateUpdate () {
        if(Target==null){ return; }
        Vector3 targetPosition = Target.position.With(y:transform.position.y) + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}

}

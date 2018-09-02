using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float Speed = 10f;
	public float MaxRotationSpeed = 720;
    public bool UseController;

	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		Vector3 velocity = Vector3.zero;
		Quaternion rotation = transform.rotation;
        if(UseController){
            velocity = MoveController();
            rotation = RotateController();
        }else{
            velocity = MoveKeyboard();
            rotation = RotateMouse();
        }
		rb.velocity = velocity;
		rb.rotation = rotation;
	}

    private Vector3 MoveKeyboard() {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
		//transform.position += moveDirection * Speed * Time.deltaTime;
		return moveDirection * Speed;// * Time.deltaTime;
    }

    private Quaternion RotateMouse() {
        Vector3 mousePos = Input.mousePosition;                                  //get mouse position                                     
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);  //Get object position and put it "on the screen" (same as mouse)                
        Vector3 offset = mousePos - screenPos;                                   //Check where the mouse is relative to the object 

        float angle = Mathf.Atan2(offset.y, -offset.x) * Mathf.Rad2Deg;          //Turn that into an angle and convert to degrees
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);            //Set the object's rotation to be of the angle over +Y
        return Quaternion.AngleAxis(angle, Vector3.up);            //Set the object's rotation to be of the angle over +Y
    }

	private Vector3 MoveController(){
		Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0, -Input.GetAxis("LeftStickVertical")).normalized;
		//transform.position += moveDirection * Speed * Time.deltaTime;
		return moveDirection * Speed;// * Time.deltaTime;
	}

	//private void Rotate(){
	//	float rx = Input.GetAxis("RightStickHorizontal");
	//	float ry = -Input.GetAxis("RightStickVertical");
	//	float angle = Mathf.Atan2(rx, ry) * Mathf.Rad2Deg;
	//	transform.rotation = Quaternion.Euler(0, angle, 0);
	//}

	private Quaternion RotateController(){
		Vector3 moveDirection = Vector3.forward * -Input.GetAxis("LeftStickHorizontal") + Vector3.right * -Input.GetAxis("LeftStickVertical");
		Vector3 lookDirection = Vector3.right * -Input.GetAxis("RightStickHorizontal") + Vector3.forward * Input.GetAxis("RightStickVertical");
		if(lookDirection.sqrMagnitude>0){
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection*Time.deltaTime,Vector3.up), MaxRotationSpeed*Time.deltaTime);
			return Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection*Time.deltaTime,Vector3.up), MaxRotationSpeed*Time.deltaTime);
		}else if(moveDirection.sqrMagnitude>0){
			transform.rotation = Quaternion.LookRotation(moveDirection*Time.deltaTime,Vector3.up);
			return Quaternion.LookRotation(moveDirection*Time.deltaTime,Vector3.up);
		}
		return transform.rotation;

	}
}

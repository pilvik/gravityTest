using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalGravity : MonoBehaviour {
	void FixedUpdate(){
		Physics.gravity = 60 * Input.acceleration.normalized;
	}



    

}

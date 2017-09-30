using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public AudioClip clip;
	[Tooltip ("If set, music will stop playing after set second(s)")]
	public float timer;
	[Tooltip ("Time before music can be picked up again")]
	public float coolDownTime = 3;
	public Color color;
	[HideInInspector]
	public bool canPickup = true;

	public IEnumerator PickUp() {
		if (canPickup) {
			canPickup = false;
			print ("Picked up music");
			yield return new WaitForSeconds (coolDownTime);
			canPickup = true;
		}
	}
}

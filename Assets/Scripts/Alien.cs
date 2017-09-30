using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

	Player player;
	Transform playerObject;
	Animator animator;
	float distanceFromPlayer;
	public AudioClip correctMusic;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		playerObject = player.transform;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distanceFromPlayer = Vector3.Distance (transform.position, playerObject.position);
		if (distanceFromPlayer < player.volume && player.isPlaying) {
			if (player.currentMusic == correctMusic)
				animator.SetBool ("Dancing", true);
			else
				print ("Un Happy"); //TODO: Doesn't like music animation
		} else {
			animator.SetBool ("Dancing", false);
		}
	}	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

	Player player;
	Transform playerObject;
	float distanceFromPlayer;
	float hearingDistance = 3;
	public AudioClip correctMusic;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		playerObject = player.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distanceFromPlayer = Vector3.Distance (transform.position, playerObject.position);
		if (distanceFromPlayer < player.volume && player.isPlaying) {
			if (player.currentMusic == correctMusic)
				print ("Dance:"+distanceFromPlayer); //TODO: Dance Animation
			else
				print ("Un Happy"); //TODO: Doesn't like music animation
		}
	}	
}

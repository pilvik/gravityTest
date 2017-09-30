using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public AudioClip currentMusic;
	public float volume = 2;
	public bool isPlaying;
	bool gameOver = false;
	bool timingOut;
	AudioSource speaker;
	Light playerLight;
	Animator animator;
	ParticleSystem particles;

	void Awake() {
		playerLight = GetComponent<Light> ();
		speaker = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		particles = GetComponent<ParticleSystem> ();
	}

	//Player movent relative to gravity
	void FixedUpdate(){
		Physics.gravity = 90 * Input.acceleration.normalized;
	}

	//Collision
	void OnTriggerEnter(Collider collision) {
		print (collision.name);
		GameObject hit = collision.gameObject;
		//Hit music, pick it up and switch to it
		if (hit.GetComponent<Music> () && hit.GetComponent<Music> ().canPickup) {
			StartCoroutine(hit.GetComponent<Music> ().PickUp());
			SwitchMusic (hit.GetComponent<Music> ());		
		}
	}

	//Set & play the new music, if it is timed then start a timer
	void SwitchMusic(Music music) {
		currentMusic = music.clip;
		PlayMusic (music, true);
	}



	void PlayMusic(Music music, bool play = true) {
		isPlaying = true;
		//Update Light and Animator
		animator.SetBool ("Playing", play);
		LightOn (music.color, play);
		particles.Play ();
		if (!play) {
			speaker.Stop ();
			return;
		}
		//Play currentMusic, initiate any timers
		speaker.clip = currentMusic;
		StopCoroutine (MusicTimeout ());
		speaker.Play ();
		if (music.timer > 0 && !timingOut)
			StartCoroutine (MusicTimeout (music.timer));
	}

	void StopMusic() {
		isPlaying = false;
		speaker.Stop ();
		particles.Stop ();
		animator.SetBool ("Playing", false);
		LightOn (Color.white, false);
	}

	void LightOn(Color color, bool On = true) {
		playerLight.enabled = On;
		playerLight.color = color;
		if (On)
			playerLight.intensity = 15;
	}


	IEnumerator MusicTimeout(float time = 0) {
		timingOut = true;
		for (float i = 0; i <= time*4; i++) {
			yield return new WaitForSeconds (0.25f);
			print (1 - (i / 4) / time);
			playerLight.intensity = (1 - (i / 4) / time)*15;
			if (i >= time * 4)
				StopMusic ();
		}
	}
}

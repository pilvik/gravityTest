using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public AudioClip currentMusic;
	public float volume = 2;
	public bool isPlaying;
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
		Physics.gravity = 60 * Input.acceleration.normalized;
	}

	//Collision
	void OnCollisionEnter(Collision collision) {
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
		if (music.timer > 0)
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
	}


	IEnumerator MusicTimeout(float time = 0) {
		yield return new WaitForSeconds (time);
		StopMusic ();
	}
}

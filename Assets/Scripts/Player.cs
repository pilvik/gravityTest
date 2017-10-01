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
	public int score;
    public int yellowAlienPoint;
    public int blueAlienPoint;
	AudioSource speaker;
	Light playerLight;
	Animator animator;
	ParticleSystem particles;
	Mesh mesh;
	public int AlienCount;
	Alien[] aliens;
	float time;
	public bool gameEnded;
	Image gameOut;

	void Awake() {
		gameOut = GameObject.Find ("BlackOut").GetComponent<Image> ();
		aliens = FindObjectsOfType<Alien> ();
		AlienCount = aliens.Length;
		playerLight = GetComponent<Light> ();
		speaker = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		particles = GetComponent<ParticleSystem> ();
		mesh = transform.Find ("Body").GetComponent<Mesh>();
		gameOut.CrossFadeAlpha (0, 0, false);
	}

	//Player movent relative to gravity
	void FixedUpdate(){
		Physics.gravity = 30 * Input.acceleration.normalized;
		if (score >= AlienCount && !gameEnded)
			GameOver ();
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

	public void StopMusic() {
		timingOut = false;
		isPlaying = false;
		speaker.Stop ();
		particles.Stop ();
		animator.SetBool ("Playing", false);
		LightOn (Color.white, false);
	}

	void LightOn(Color color, bool On = true) {
		playerLight.enabled = On;
		playerLight.color = color;
		if (On) {
			playerLight.intensity = 15;
			speaker.volume = 1;
		}
	}

	void GameOver() {
		print ("GameOver");
		gameEnded = true;
		gameOut.CrossFadeAlpha (1, 1, true);
		gameOut.transform.GetChild (0).GetComponent<Text> ().text = "Level Completed in " + Time.timeSinceLevelLoad + " seconds!";
		Time.timeScale = 0;
	}

	IEnumerator MusicTimeout(float time = 0) {
		timingOut = true;
		for (float i = 0; i <= time*4; i++) {
			yield return new WaitForSeconds (0.25f);
			playerLight.intensity = (1 - (i / 4) / time)*15;
			speaker.volume = 1-((i / 4) / time);
			if (i >= time * 4)
				StopMusic ();
		}
	}
}

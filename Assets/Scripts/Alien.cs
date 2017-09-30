using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour {

	Player player;
	Transform playerObject;
	Animator animator;
	float distanceFromPlayer;
	Image timeIcon;
	public AudioClip correctMusic;
	private float danceTimer;
	public float timeUntilDancing;
	bool isDancing;
	bool hearingGoodMusic;
	bool delayingDance;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		playerObject = player.transform;
		animator = GetComponent<Animator> ();
		timeIcon = transform.GetChild (0).GetComponent<Image> ();
		if (timeUntilDancing == 0)
			timeIcon.gameObject.SetActive (false); //Disable timer if it's not a timed alien
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDancing) {
			distanceFromPlayer = Vector3.Distance (transform.position, playerObject.position);
			if (distanceFromPlayer < player.volume && player.isPlaying) {
				if (player.currentMusic == correctMusic) { 
					//Playing the right type of music
					hearingGoodMusic = true;
					if (timeUntilDancing > 0 && !delayingDance) {
						StartCoroutine (TimedStart (timeUntilDancing));
						return;
					} else if (timeUntilDancing == 0)
						StartDancing ();
				} else { //Wrong Music
					ResetTimedStart ();
					hearingGoodMusic = false;
					StopDancing ();
					animator.SetBool ("Mad", true);
					animator.SetBool ("Idle", false);
				}

			} else { //Out of range
				StopDancing ();
				hearingGoodMusic = false;
				ResetTimedStart ();
			}
		} else {
			distanceFromPlayer = Vector3.Distance (transform.position, playerObject.position);
			if (distanceFromPlayer > player.volume) {
				print ("Out of Range");
				hearingGoodMusic = false;
			}
		}
	}

	void StartDancing() {
		timeIcon.GetComponent<Animator> ().SetBool ("Completed", true);
		isDancing = true;
		animator.SetBool ("Dancing", isDancing);
		animator.SetBool ("Idle", !isDancing);
		animator.SetBool ("Mad", false);
		player.score++;
	}

	void StopDancing() {
		isDancing = false;
		timeIcon.GetComponent<Animator> ().SetBool ("Completed", false);
		animator.SetBool ("Dancing", isDancing);
		animator.SetBool ("Idle", !isDancing);
		animator.SetBool ("Mad", false);
	}

	void ResetTimedStart() {
		StopCoroutine (TimedStart (0));
		delayingDance = false;
		timeIcon.fillAmount = 0;
	}

	IEnumerator TimedStart(float time) {
		delayingDance = true;
		for (float i = 0; i <= time*4; i++) {
			if (hearingGoodMusic) {
				yield return new WaitForSeconds (0.25f);
				timeIcon.fillAmount = (i / 4) / time;
				if (i >= time * 4)
					StartDancing ();
			}
		}
	}

}

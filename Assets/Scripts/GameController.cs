using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private Data data;
    private ControllHooker c;
	float gameTime;
	public Text time;

    private void Awake()
    {
        data = GameObject.FindGameObjectWithTag("data").GetComponent<Data>();
        c = GameObject.FindGameObjectWithTag("controllerHooker").GetComponent<ControllHooker>();
    }

    private void Start()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //c.levelSelect.Level1();
        c.pauseC.PauseGame();
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        data.countDownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        {
            data.countDownText.text = "2";
        }
        yield return new WaitForSecondsRealtime(1f);
        {
            data.countDownText.text = "1";
        }
        yield return new WaitForSecondsRealtime(1f);
        {
            data.countDownText.text = "";
            c.pauseC.ContinueGame();
        }
    }

	void Update() {
		YellowPointCountUI ();
		BluePointCountUI ();
		time.text = Time.timeSinceLevelLoad.ToString ();
	}

	public void YellowPointCountUI()
	{
		int points = data.playerGO.GetComponent<Player>().yellowAlienPoint;
		if (points <=0)
		{
			data.yellowGO1.SetActive(false);
			data.yellowGO2.SetActive(false);
			data.yellowGO3.SetActive(false);
		}
		if (points == 1)
		{
			data.yellowGO1.SetActive(true);
			data.yellowGO2.SetActive(false);
			data.yellowGO3.SetActive(false);
		}
		if (points == 2)
		{
			data.yellowGO1.SetActive(true);
			data.yellowGO2.SetActive(true);
			data.yellowGO3.SetActive(false);
		}
		if (points == 3)
		{
			data.yellowGO1.SetActive(true);
			data.yellowGO2.SetActive(true);
			data.yellowGO3.SetActive(true);
		}

	}
	public void BluePointCountUI()
	{
		int points = data.playerGO.GetComponent<Player>().blueAlienPoint;
		if (points <= 0)
		{
			data.blueGO1.SetActive(false);
			data.blueGO2.SetActive(false);
			data.blueGO3.SetActive(false);
		}
		if (points == 1)
		{
			data.blueGO1.SetActive(true);
			data.blueGO2.SetActive(false);
			data.blueGO3.SetActive(false);
		}
		if (points == 2)
		{
			data.blueGO1.SetActive(true);
			data.blueGO2.SetActive(true);
			data.blueGO3.SetActive(false);
		}
		if (points == 3)
		{
			data.blueGO1.SetActive(true);
			data.blueGO2.SetActive(true);
			data.blueGO3.SetActive(true);
		}

	}

	public void ResetGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Data data;
    private ControllHooker c;

    private void Awake()
    {

        data = GameObject.FindGameObjectWithTag("data").GetComponent<Data>();
        c = GameObject.FindGameObjectWithTag("controllerHooker").GetComponent<ControllHooker>();
    }

    private void Start()
    {
        c.levelSelect.Level1();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
	
    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game paused.");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        Debug.Log("Game Unpaused.");
    }
}

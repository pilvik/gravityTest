using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {

    
    private Data data;
    private ControllHooker c;

    private void Awake()
    {
        
        data = GameObject.FindGameObjectWithTag("data").GetComponent<Data>();
        c = GameObject.FindGameObjectWithTag("controllerHooker").GetComponent<ControllHooker>();
    }


    public void Level0()
    {
        data.playerGO.transform.localPosition = data.startingPosition;
        data.levelGO1.SetActive(false);
        data.levelGO2.SetActive(false);
        data.levelText.text = "level 0";
    }
    public void Level1()
    {
        data.playerGO.transform.localPosition = data.startingPosition;
        data.levelGO1.SetActive(true);
        data.levelGO2.SetActive(false);
        data.levelText.text = "level 1";
    }
    public void Level2()
    {
        data.playerGO.transform.localPosition = data.startingPosition;
        data.levelGO1.SetActive(false);
        data.levelGO2.SetActive(true);
        data.levelText.text = "level 2";
    }
}

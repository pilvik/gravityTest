using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject playerGO;
    public Vector3 startingPosition;
    [Header("Levels")]
    public GameObject levelGO1;
    public GameObject levelGO2;
    public GameObject levelGO3;

    [Header("UI")]
    public Text countDownText;

    [Header("Scoreboard")]
    public GameObject yellowGO1;
    public GameObject yellowGO2;
    public GameObject yellowGO3;

    public GameObject blueGO1;
    public GameObject blueGO2;
    public GameObject blueGO3;

    [Header("TestUi")]
    public Text levelText;
}

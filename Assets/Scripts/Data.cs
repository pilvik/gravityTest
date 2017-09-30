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

    [Header("TestUi")]
    public Text levelText;
}

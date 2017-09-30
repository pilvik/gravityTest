using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Animator testAnimator;
    

    private Music music;
    private Data data;
    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("music").GetComponent<Music>();
        data = GameObject.FindGameObjectWithTag("data").GetComponent<Data>();
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (!music.canPickup)
        {
            testAnimator.SetTrigger("startAnim");
            Debug.Log("Heh!" + other);
        }
        else
        {
            Debug.Log("bleh");
        }

        data.playerGO.transform.localPosition = data.startingPosition;
        data.levelGO1.SetActive(true);

    }

}

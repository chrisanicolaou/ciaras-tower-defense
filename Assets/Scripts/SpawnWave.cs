using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWave : MonoBehaviour
{

    public GameObject basicZombie, zombie2;
    public Transform startPos;

    public GameObject playButton, speedUpButton, slowDownButton;

    void Start()
    {
        speedUpButton.SetActive(false);
        slowDownButton.SetActive(false);
    }

    void Update()
    {

        if(GameObject.FindWithTag("Enemy") == null) {
            Globals.isMidRound = false;
            playButton.SetActive(true);
            speedUpButton.SetActive(false);
            slowDownButton.SetActive(false);
        }
    }

    public void SpawnNewWave()
    {
        if (!Globals.isMidRound) {
            Globals.isMidRound = true;
            playButton.SetActive(false);
            Debug.Log("Disabling play button...");
            if (Globals.isGoingFast) {
                slowDownButton.SetActive(true);
            } else {
                Debug.Log("Enabling speed up button..");
                speedUpButton.SetActive(true);
            }
            Globals.waveNum++;
            StartCoroutine("SpawnZombies");
        }
    }

    public void SpeedUp()
    {
        Time.timeScale = 2.0f;
        Globals.isGoingFast = true;
        speedUpButton.SetActive(false);
        slowDownButton.SetActive(true);
    }

    public void SlowDown()
    {
        Time.timeScale = 1.0f;
        Globals.isGoingFast = false;
        speedUpButton.SetActive(true);
        slowDownButton.SetActive(false);
    }


    IEnumerator SpawnZombies () 
    {
        if (Globals.waveNum < 5) {
            for (int i = 0; i < Globals.waveNum + 5; i++)
            {
                Instantiate(basicZombie, startPos.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
        } else {
            for (int i = 0; i < Globals.waveNum * 2; i++)
            {
                if (i % 3 == 0) {
                    Instantiate(zombie2, startPos.position, Quaternion.identity);
                } else {
                    Instantiate(basicZombie, startPos.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}

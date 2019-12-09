using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToBase : MonoBehaviour
{
    private bool playerOnTrigger = false;
    public GameObject NextText;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            NextText.SetActive(true);
            playerOnTrigger = true;
        }



    }
    void Update()
    {
        if (playerOnTrigger == true)
        {
            if (Input.GetButtonDown("Select"))
            {
                CheckScene();
                SceneManager.LoadScene(GetNextScene());
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        NextText.SetActive(false);
        playerOnTrigger = false;

    }

    void CheckScene()
    {
        if (SceneManager.GetActiveScene().name == "TrainingLvl")
        {
            Data.newGame = false;
            Data.lvl1 = true;
        }
        if (SceneManager.GetActiveScene().name == "AlienBoss")
        {
            Data.lvl2 = true;
        }
    }

    private string GetNextScene()
    {
        string nextScene = "";
        if (SceneManager.GetActiveScene().name == "TrainingLvl")
        {
            nextScene = "Base";
        }
        else if (SceneManager.GetActiveScene().name == "AlienBoss")
        {
            nextScene = "CutScene";
        }
        else if (SceneManager.GetActiveScene().name == "SkeletonBoss")
        {
            nextScene = "FinalCutscene";
        }

        return nextScene;
    }
}

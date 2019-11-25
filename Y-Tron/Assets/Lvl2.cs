using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2 : MonoBehaviour
{
    private bool playerOnTrigger = false;
    public GameObject NextText;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (Data.lvl2 == true)
        {


            if (col.CompareTag("Player"))
            {
                NextText.SetActive(true);
                playerOnTrigger = true;
            }
        }


    }
    void Update()
    {
        if (playerOnTrigger == true && Data.lvl2 == true)
        {
            if (Input.GetButtonDown("Select"))
            {
                SceneManager.LoadScene("AlienBoss");
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (Data.lvl2 == true)
        {
            NextText.SetActive(false);
            playerOnTrigger = false;
        }
    }
}

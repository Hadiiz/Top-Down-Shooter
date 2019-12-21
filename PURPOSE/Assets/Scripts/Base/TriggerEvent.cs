using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject DialogueManager;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            Data.move = false;
            Dialogue.SetActive(true);
            DialogueManager.GetComponent<Dialogue>().StartDialogue();

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Data.newGame == true)
            {
                Data.move = false;
                Dialogue.SetActive(true);
                DialogueManager.GetComponent<Dialogue>().StartDialogue();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject DialoguePanel;
    public GameObject continueButton;
    public GameObject BrainXImg;
    public GameObject PlayerImg;

    public void StartDialogue()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            setImg();
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            DialoguePanel.SetActive(false);
            Data.move = true;

        }
    }

    public void setImg()
    {
        if (index == 1 || index == 7 || index == 10 || index == 18 || index == 19)
        {
            BrainXImg.SetActive(false);
            PlayerImg.SetActive(true);
        }
        else
        {
            BrainXImg.SetActive(true);
            PlayerImg.SetActive(false);
        }
    }
}

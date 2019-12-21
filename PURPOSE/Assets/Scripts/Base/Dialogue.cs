using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public int[] playerTurn;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] sentencesLvl1;
    public string[] sentencesLvl2;

    private string[] _sentences;

    private int index;
    public float typingSpeed;

    public GameObject DialoguePanel;
    public GameObject continueButton;
    public GameObject BrainXImg;
    public GameObject PlayerImg;

    void Start()
    {
        GetSentences();
    }
    public void GetSentences()
    {
        if (Data.newGame == true)
        {
            _sentences = sentences;
        }
        if (Data.lvl1 == true)
        {
            _sentences = sentencesLvl1;
        }
        if (Data.lvl2 == true)
        {
            _sentences = sentencesLvl2;
        }
    }
    public void StartDialogue()
    {

        if (_sentences.Length == 1)
        {
            Data.teleport = true;
        }
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == _sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in _sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);

        if (index < _sentences.Length - 1)
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
        if (_sentences == sentences)
        {
            bool found = false;
            for (int i = 0; i < playerTurn.Length; i++)
            {
                if (index == playerTurn[i])
                {
                    found = true;
                }
            }
            if (found)
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
        else
        {
            BrainXImg.SetActive(true);
            PlayerImg.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        if (SceneManager.GetActiveScene().name == "Cutscene")
        {
            yield return new WaitForSeconds(37);
            SceneManager.LoadScene("Base");

        }
        else if (SceneManager.GetActiveScene().name == "FinalCutscene")
        {
            yield return new WaitForSeconds(7.2f);
            SceneManager.LoadScene("ThankYou");

        }
    }
}

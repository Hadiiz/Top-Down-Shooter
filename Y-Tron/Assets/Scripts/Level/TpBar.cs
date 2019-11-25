using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TpBar : MonoBehaviour
{
    Image tpBar;
    private float maxTpTime = Data.tpTime;

    float timeLeft;
    bool clicked = false;
    void Start()
    {
        tpBar = GetComponent<Image>();
        timeLeft = maxTpTime;
    }

    public IEnumerator StartTp()
    {

        while (timeLeft > 0)
        {
            Debug.Log("->" + clicked);
            if (clicked == true)
            {
                break;

            }
            else
            {
                timeLeft -= Time.deltaTime;
                transform.localScale = new Vector3(timeLeft / maxTpTime, 1);
                yield return null;
            }
        }
        if (timeLeft < 0)
            timeLeft = 0;

    }

    public void SetClicked(bool clicked)
    {
        this.clicked = clicked;
    }

    public bool GetClicked()
    {
        return clicked;
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }


}

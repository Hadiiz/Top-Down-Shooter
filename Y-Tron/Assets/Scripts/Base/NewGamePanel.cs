using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGamePanel : MonoBehaviour
{

    public CanvasGroup uiElement;
    public Animator animator;

    void Start()
    {
        animator.SetBool("NewGamePanel", Data.newGame);
        FadeIn();
    }


    public void FadeIn()
    {
        if (Data.newGame == true)
        {
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
        }
        else
        {
            uiElement.alpha = 0;
        }
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float lerpTime = 1f)
    {
        yield return new WaitForSeconds(3);
        float _timeStartedLerping = Time.time;
        float timeStartedLerping = Time.time - _timeStartedLerping;
        float percentageComplete = timeStartedLerping / lerpTime;
        while (true)
        {
            timeStartedLerping = Time.time - _timeStartedLerping;
            percentageComplete = timeStartedLerping / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            canvasGroup.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        animator.SetBool("NewGamePanel", false);


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public HealthBar healthBar;

    public GameObject gameOverPanel;

    public GameObject player;

    public GameObject boss;

    public void Adsclick()
    {
        Debug.Log("clicked");
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Base");
    }

    void Update()
    {
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (healthBar.GetHealth() <= 0f)
        {
            gameOverPanel.SetActive(true);
            Cursor.visible = true;
            Destroy(player);
            Destroy(boss);
        }
    }


}



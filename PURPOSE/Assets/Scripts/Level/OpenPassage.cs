using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPassage : MonoBehaviour
{
    public GameObject passage;
    public GameObject player;

    void Update()
    {
        if (player.GetComponent<PlayerInLvl>().enemiesKilled >= 6)
        {
            Destroy(passage, 0.0f);
        }
    }
}

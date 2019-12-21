using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonData : MonoBehaviour
{
    public GameObject player;
    public GameObject demon;
    public float health = 100f;
    void Start()
    {
        // GetComponent<Pathfinding.AIPath>().maxSpeed = Random.Range(0.1f, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(demon, 0.0f);
            player.GetComponent<PlayerInLvl>().enemiesKilled++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemons : MonoBehaviour
{
    public GameObject spawnTrigger;
    public GameObject demonPrefab;

    public GameObject player;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            StartCoroutine(Spawn());

            GetComponent<Collider2D>().enabled = false;

        }
    }

    Vector3 GetRandomPos()
    {
        float minX = 7.0f;
        float maxX = 14.0f;
        float minY = -2.0f;
        float maxY = 3.0f;

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector3(x, y, 0.0f);
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            demonPrefab.GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
            demonPrefab.GetComponent<DemonData>().player = player;
            Instantiate(demonPrefab, GetRandomPos(), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}

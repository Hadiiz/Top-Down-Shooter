using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    public GameObject alienBulletRed;
    public GameObject player;
    public void SpawnSingleBullet(float bulletSpeed)
    {
        Vector3 playerDirection = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        GameObject bullet = Instantiate(alienBulletRed, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = (playerDirection - transform.position).normalized * bulletSpeed;

        Destroy(bullet, 5F);
    }

    public IEnumerator SpawnBullets(int numberOfBullets, float bulletSpeed)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            Vector3 playerDirection = new Vector3(player.transform.position.x, player.transform.position.y, 0);

            GameObject bullet = Instantiate(alienBulletRed, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (playerDirection - transform.position).normalized * bulletSpeed;

            Destroy(bullet, 5F);
            yield return new WaitForSeconds(0.2f);
        }
    }
}

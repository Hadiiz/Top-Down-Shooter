using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadicalBullet : MonoBehaviour
{
    public GameObject alienBulletRed;
    public GameObject player;
    private const float radius = 1F;


    public void SpawnProjectile(int numberOfBullets, Vector2 position, float bulletSpeed)
    {
        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        Vector3 startPoint = position;

        for (int i = 0; i < numberOfBullets; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * bulletSpeed;

            // Create game objects.
            GameObject bullet = Instantiate(alienBulletRed, startPoint, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            // Destory the gameobject after 10 seconds.
            Destroy(bullet, 5F);

            angle += angleStep;
        }
    }
}

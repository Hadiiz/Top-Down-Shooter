using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBullet : MonoBehaviour
{

    public GameObject bossBulletRed;
    private const float radius = 1F;

    private int numberOfTimesRepeated = 50;


    private void Start()
    {
        // StartCoroutine(SpawnProjectile(20, transform.position, 5f));
    }


    public IEnumerator SpawnProjectile(float numberOfBullets, Vector2 position, float bulletSpeed)
    {
        float angleStep = 86.72f;
        float angle = 0f;

        Vector3 startPoint = position;

        while (angle <= 360f * numberOfTimesRepeated)
        {
            // Direction calculations.
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * bulletSpeed;

            // Create game objects.
            GameObject bullet = Instantiate(bossBulletRed, startPoint, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            // Destory the gameobject after 10 seconds.
            Destroy(bullet, 7F);



            angle += angleStep;
            yield return new WaitForSeconds(0.01f);
        }

    }
}

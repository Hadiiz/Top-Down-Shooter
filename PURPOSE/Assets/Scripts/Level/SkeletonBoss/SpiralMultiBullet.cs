using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMultiBullet : MonoBehaviour
{

    public GameObject bossBulletRed;
    private const float radius = 1F;

    private float[] clockWiseBullets;

    private float[] counterClockWiseBullets;

    private int numberOfTimesRepeated = 50;

    private float seconds;

    private float wait = 0.1f;


    private void Start()
    {
        clockWiseBullets = new float[4];
        counterClockWiseBullets = new float[4];
        GenerateArrays();
        // StartCoroutine(SpawnSpiralMultiProjectile(transform.position, 7f));
    }

    private void GenerateArrays()
    {
        float angleStep = 360f / 4;
        float angle = 0f;
        float counterAngle = 0f;

        for (int i = 0; i < 4; i++)
        {
            clockWiseBullets[i] = angle;
            counterClockWiseBullets[i] = counterAngle;
            angle += angleStep;
            counterAngle -= angleStep;
        }
    }
    private void UpdateArrays(float angleStep)
    {
        for (int i = 0; i < 4; i++)
        {
            clockWiseBullets[i] += angleStep;
            counterClockWiseBullets[i] -= angleStep;
        }
    }
    public IEnumerator SpawnSpiralMultiProjectile(Vector2 position, float bulletSpeed)
    {
        float angle = 0f;
        float counterAngle = 0f;

        seconds = 0.0f;

        Vector3 startPoint = position;
        while (seconds < 6)
        {
            for (int i = 0; i < 4; i++)
            {
                angle = clockWiseBullets[i];
                counterAngle = counterClockWiseBullets[i];
                // Direction calculations.
                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
                float projectileDirXPositionC = startPoint.x + Mathf.Sin((counterAngle * Mathf.PI) / 180) * radius;
                float projectileDirYPositionC = startPoint.y + Mathf.Cos((counterAngle * Mathf.PI) / 180) * radius;

                // Create vectors.
                Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
                Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * bulletSpeed;
                Vector3 projectileVectorC = new Vector3(projectileDirXPositionC, projectileDirYPositionC, 0);
                Vector3 projectileMoveDirectionC = (projectileVectorC - startPoint).normalized * bulletSpeed;

                // Create game objects.
                GameObject bullet = Instantiate(bossBulletRed, startPoint, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
                GameObject bulletC = Instantiate(bossBulletRed, startPoint, Quaternion.identity);
                bulletC.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirectionC.x, projectileMoveDirectionC.y);

                // Destory the gameobject after 10 seconds.
                Destroy(bullet, 3F);
                Destroy(bulletC, 3F);


            }
            UpdateArrays(5f);
            yield return new WaitForSeconds(wait);
            seconds += wait;

        }
    }



}

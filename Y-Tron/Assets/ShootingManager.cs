using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject alienBulletRed;
    public GameObject player;
    public GameObject leftGun;
    public GameObject RightGun;

    private StraightBullet straightBullet;
    private RadicalBullet radicalBullet;
    private int state = 1;
    void Start()
    {
        straightBullet = GetComponent<StraightBullet>();
        radicalBullet = GetComponent<RadicalBullet>();
        StartCoroutine(Shoot());
        // radicalBullet.SpawnProjectile(50, 7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        while (state == 0)
        {
            straightBullet.SpawnSingleBullet(7f);
            yield return new WaitForSeconds(2);
        }
        while (state == 1)
        {
            StartCoroutine(straightBullet.SpawnBullets(10, 7f));
            yield return new WaitForSeconds(5);
        }
    }

    public void LaserGunShoot()
    {
        radicalBullet.SpawnProjectile(50, leftGun.transform.position, 7f);
        radicalBullet.SpawnProjectile(50, RightGun.transform.position, 7f);
    }
}

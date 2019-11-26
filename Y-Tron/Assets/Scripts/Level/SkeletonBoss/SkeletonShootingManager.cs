using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShootingManager : MonoBehaviour
{
    public GameObject player;

    private StraightBullet straightBullet;
    private RadicalBullet radicalBullet;

    private SpiralBullet spiralBullet;

    private SpiralMultiBullet spiralMultiBullet;

    private SkeletonBossHealthBar skeletonBossHealthBar;
    private int state = 0;
    void Start()
    {

        straightBullet = GetComponent<StraightBullet>();
        radicalBullet = GetComponent<RadicalBullet>();
        spiralBullet = GetComponent<SpiralBullet>();
        spiralMultiBullet = GetComponent<SpiralMultiBullet>();
        skeletonBossHealthBar = GetComponent<SkeletonBossHealthBar>();


        // radicalBullet.SpawnProjectile(50, 7f);*/
    }

    public void StartBattle()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();

    }

    IEnumerator Shoot()
    {

        while (state == 0)
        {
            radicalBullet.SpawnProjectile(50, transform.position, 7f);
            yield return new WaitForSeconds(2);
        }
        while (state == 1)
        {
            StartCoroutine(straightBullet.SpawnBullets(10, 7f));
            yield return new WaitForSeconds(2);
        }
        while (state == 2)
        {
            StartCoroutine(spiralBullet.SpawnProjectile(10, transform.position, 7f));
            yield return new WaitForSeconds(7);
        }
        while (state == 3)
        {
            StartCoroutine(spiralMultiBullet.SpawnSpiralMultiProjectile(transform.position, 7f));
            yield return new WaitForSeconds(7);
        }
        /*
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
                while (state == 2)
                {
                    StartCoroutine(straightBullet.SpawnBullets(10, 7f));
                    animator.SetBool("Shoot", true);
                    yield return new WaitForSeconds(3);
                    animator.SetBool("Shoot", false);
                    yield return new WaitForSeconds(3);
                }
        */
    }

    public void LaserGunShoot()
    {
        /*
        radicalBullet.SpawnProjectile(50, leftGun.transform.position, 7f);
        radicalBullet.SpawnProjectile(50, RightGun.transform.position, 7f);
        */
    }

    public void CheckState()
    {
        if (skeletonBossHealthBar.GetHealthPercent() * 100f <= 100f && skeletonBossHealthBar.GetHealthPercent() * 100f > 75)
        {
            state = 0;
        }
        else if (skeletonBossHealthBar.GetHealthPercent() * 100f <= 75f && skeletonBossHealthBar.GetHealthPercent() * 100f > 50f)
        {
            state = 1;
        }
        else if (skeletonBossHealthBar.GetHealthPercent() * 100f <= 50f && skeletonBossHealthBar.GetHealthPercent() * 100f > 25f)
        {
            state = 2;
        }
        else if (skeletonBossHealthBar.GetHealthPercent() * 100f <= 25f)
        {
            state = 3;
        }
    }

    void DestroyBoss()
    {
        Destroy(this.gameObject);
    }
}

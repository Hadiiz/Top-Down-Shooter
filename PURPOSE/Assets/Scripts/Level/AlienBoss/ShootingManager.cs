using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject alienBulletRed;
    public GameObject player;
    public GameObject leftGun;
    public GameObject RightGun;

    public Animator animator;
    private StraightBullet straightBullet;
    private RadicalBullet radicalBullet;

    private AlienBossHealthBar alienBossHealthBar;
    private int state = 0;
    void Start()
    {
        straightBullet = GetComponent<StraightBullet>();
        radicalBullet = GetComponent<RadicalBullet>();
        alienBossHealthBar = GetComponent<AlienBossHealthBar>();
        StartCoroutine(Shoot());
        // radicalBullet.SpawnProjectile(50, 7f);
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

    }

    public void LaserGunShoot()
    {
        radicalBullet.SpawnProjectile(50, leftGun.transform.position, 7f);
        radicalBullet.SpawnProjectile(50, RightGun.transform.position, 7f);
    }

    public void CheckState()
    {
        if (alienBossHealthBar.GetHealthPercent() * 100f <= 75f && alienBossHealthBar.GetHealthPercent() * 100f >= 50f)
        {
            state = 1;
        }
        else if (alienBossHealthBar.GetHealthPercent() * 100f <= 50f && alienBossHealthBar.GetHealthPercent() * 100f >= 0f)
        {
            state = 2;
        }
    }

    void DestroyBoss()
    {
        Destroy(this.gameObject);
    }
}

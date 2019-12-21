using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Crosshair;
    private Vector3 aim;

    public GameObject bulletPrefab;

    public float bulletSpeed;

    public float bulletDestrTime;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RotateArroundPlayer();
        CheckInput();
    }

    void RotateArroundPlayer()
    {
        Vector3 mousePosition = new Vector3(Crosshair.transform.localPosition.x, Crosshair.transform.localPosition.y, 0.0f);
        // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aim = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
        aim.Normalize();
        this.transform.position = Player.transform.position + aim;
    }

    void CheckInput()
    {
        /*Vector2 shootingDirection = new Vector2(Crosshair.transform.localPosition.x, Crosshair.transform.localPosition.y);
        shootingDirection.Normalize();
        if (Input.GetButtonDown("Fire"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().velocity = shootingDirection * bulletSpeed;
            Destroy(bullet, bulletDestrTime);
        }*/
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletPos = new Vector2(transform.position.x, transform.position.y);

        if (Input.GetButtonDown("Fire"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().velocity = (mousePos - bulletPos).normalized * bulletSpeed;
            Destroy(bullet, bulletDestrTime);
        }
    }
}

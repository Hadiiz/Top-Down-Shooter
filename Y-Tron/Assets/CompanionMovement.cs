using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Crosshair;
    private Vector3 aim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateArroundPlayer();
    }

    void RotateArroundPlayer()
    {
        Vector3 mousePosition = new Vector3(Crosshair.transform.localPosition.x, Crosshair.transform.localPosition.y, 0.0f);
        // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        aim = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
        aim.Normalize();
        this.transform.position = Player.transform.position + aim;
    }
}

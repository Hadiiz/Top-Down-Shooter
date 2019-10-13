using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLvl : MonoBehaviour
{
    private const float TELEPORT_TIME = 0.6f;
    public Animator animator;
    public Rigidbody2D rb;
    private float IdleValue;
    private Vector3 movement;

    public float speed;


    void Start()
    {
        IdleValue = animator.GetFloat("IdleValue");
    }

    void Update()
    {

        Animate();
        Move();


    }

    private void Animate()
    {

        StartCoroutine(waitForTp());

        if (animator.GetBool("Teleported") == true)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, 0.0f);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);


            SetIdleState();
        }

    }


    private void Move()
    {
        if (Data.move == true)
            rb.velocity = new Vector2(movement.x, movement.y);
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    private void SetIdleState()
    {
        float horizontal = animator.GetFloat("Horizontal");
        float vertical = animator.GetFloat("Vertical");

        horizontal = horizontal >= 0 ? Mathf.Ceil(horizontal) : Mathf.Floor(horizontal);
        vertical = vertical >= 0 ? Mathf.Ceil(vertical) : Mathf.Floor(vertical);

        //Right
        if ((horizontal == 1 && vertical == 0) || (horizontal == 1 && vertical == 1))
        {
            IdleValue = 0;
        }
        //Up
        else if (horizontal == 0 && vertical == 1)
        {
            IdleValue = 3;
        }
        //Left
        else if ((horizontal == -1 && vertical == 1) || (horizontal == -1 && vertical == 0))
        {
            IdleValue = 1;
        }
        //Down
        else if (horizontal == 0 && vertical == -1)
        {
            IdleValue = 2;
        }

        animator.SetFloat("IdleValue", IdleValue);
    }

    IEnumerator waitForTp()
    {

        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Teleported", true);

    }
}

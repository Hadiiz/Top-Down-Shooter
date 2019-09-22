using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    private float IdleValue;
    private Vector3 movement;
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
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);


        SetIdleState();
    }

    private void Move()
    {
        rb.velocity = new Vector2(movement.x, movement.y);
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
}

/* private void ProcessInputs() {
		if (useController) {
			movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
			aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);
			aim.Normalize();
			isAiming = player.GetButton("Fire");
			endOfAiming = player.GetButtonUp("Fire");
		} else {
			movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
			Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
			aim = aim + mouseMovement;
			if (aim.magnitude > 1.0f) {
				aim.Normalize();
			}
			isAiming = Input.GetButton("Fire1");
			endOfAiming = Input.GetButtonUp("Fire1");
		}

		if (movement.magnitude > 1.0f) {
			movement.Normalize();
		}
}*/

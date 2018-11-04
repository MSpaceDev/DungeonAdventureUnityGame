using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float maxSpeed;

    [HideInInspector]
    public bool isFlipped;

    Rigidbody2D rb;
    Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        int inputX = (int) Input.GetAxisRaw("Horizontal");
        int inputY = (int) Input.GetAxisRaw("Vertical");

        SetAnimation(inputX, inputY);

        if (inputX != 0)
            FlipPlayer(inputX);

        rb.velocity = new Vector2(inputX, inputY).normalized * movementSpeed * Time.deltaTime;
    }

    void SetAnimation(int inputX, int inputY)
    {
        if (inputX != 0)
        {
            anim.SetBool("MoveHorizontal", true);
            anim.SetBool("MoveVertical", false);
        }
        else if (inputY != 0 && inputX == 0)
        {
            anim.SetBool("MoveHorizontal", false);
            anim.SetBool("MoveVertical", true);
        }
        else
        {
            anim.SetBool("MoveHorizontal", false);
            anim.SetBool("MoveVertical", false);
        }
    }

    void FlipPlayer(int inputX)
    {
        if (inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFlipped = true;
        }
        else if (inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFlipped = false;
        }
        else
        {
            isFlipped = false;
        }
    }
}

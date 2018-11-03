using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float maxSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        int inputX = (int) Input.GetAxisRaw("Horizontal");
        int inputY = (int) Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(inputX, inputY).normalized * movementSpeed * Time.deltaTime;
    }
}

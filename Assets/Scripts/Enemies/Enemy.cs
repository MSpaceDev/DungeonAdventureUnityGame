using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float movementSpeed = 100.0f;
    public float attackTimeInSeconds = 1.0f;

    float attackTimer;

    Rigidbody2D rb;
    Player player;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Player.instance;
    }

    // Update is called once per frame
    protected virtual void Update () {
        MoveToPlayer();
	}

    protected virtual void MoveToPlayer()
    {
        float distanceToPlayer = (transform.position - player.transform.position).magnitude;

        if (distanceToPlayer > player.transform.localScale.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackTimeInSeconds)
            {
                player.health--;
                attackTimer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            // Enemy death here
            Destroy(gameObject);
        }
    }
}

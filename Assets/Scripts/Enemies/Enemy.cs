using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float movementSpeed = 100.0f;
    public float attackTimeInSeconds = 1.0f;
    public GameObject[] splats;
    public GameObject deathPS;

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
        PlayerWeapon playerWeapon = collision.gameObject.GetComponentInParent<PlayerWeapon>();

        if (!playerWeapon || !playerWeapon.isWeaponMoving)
            return;

        GameObject splatPS = Instantiate(deathPS, transform.position, Random.rotation);
        
        for (int i = 0; i <= 3; i++)
        {
            Vector2 spawnPos = new Vector2(
                    transform.position.x + Random.Range(-0.2f, 0.2f),
                    transform.position.y + Random.Range(-0.2f, 0.2f)
                );

            GameObject splat = Instantiate(splats[Random.Range(0, splats.Length)], spawnPos, Random.rotation);
            splat.transform.rotation = Quaternion.Euler(0, 0, splat.transform.rotation.z);
        }

        Destroy(splatPS, 3.0f);
        Destroy(gameObject);
    }
}

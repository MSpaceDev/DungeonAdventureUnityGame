using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    public PlayerMovement PlayerMovement { get; set; }
    public PlayerAttack PlayerAttack { get; set; }
    public PlayerWeapon PlayerWeapon { get; set; }

    public int health = 6;

    int coins;
    Vector2 position;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        PlayerAttack = GetComponent<PlayerAttack>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerWeapon = GetComponent<PlayerWeapon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveLoadManager.instance.Save(transform.position, coins);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoadManager.instance.Load(out position, out coins);
            transform.position = position;
        }
    }
}

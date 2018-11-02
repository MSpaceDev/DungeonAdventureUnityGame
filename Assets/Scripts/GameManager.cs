using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Vector2 position;
    public int coins;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
            SaveLoadManager.instance.Save(position, coins);
        else if (Input.GetKeyDown(KeyCode.L))
            SaveLoadManager.instance.Load(out position, out coins);
    }
}

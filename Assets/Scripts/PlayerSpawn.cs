using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerPrefab;
	
    public GameObject SpawnPlayer()
    {
        return this.playerPrefab;
    }
}

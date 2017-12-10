using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject playerPrefab;
    private GameObject playerGO;
    private PlayerController player;
    public GameObject enemyPrefab;
    private UIController UI;
    private GameObject hand;
    private CameraFollow mainCamera;
    private WorldDisplay worldDisplay;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitGame();
    }
    
    private void InitGame(){
        UI = FindObjectOfType<Canvas>().GetComponent<UIController>();
        mainCamera = Camera.main.GetComponent<CameraFollow>();
        worldDisplay = new WorldDisplay();
        for (int i = 0; i < 3; i++)
        {
            UI.hand.DrawCard();
        }

        playerGO = SpawnPlayer();
        player = playerGO.GetComponent<PlayerController>();
        mainCamera.SetTarget(playerGO.transform);
        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.right * 7, Quaternion.identity);
	}

    private void Update()
    {
        
    }

    public UIController GetUI()
    {
        return this.UI;
    }

    public GameObject GetPlayer ()
    {
        return this.playerGO;
    }

	GameObject SpawnPlayer(){
        Vector2Int randChunk = new Vector2Int(Random.Range(0, worldDisplay.chunksWide - 1), Random.Range(0, worldDisplay.chunksHigh - 1));
        //print(randChunk);
        Vector2 playerSpawn = new Vector2(worldDisplay.chunkSize / 2 + (16 * randChunk.x), worldDisplay.chunkSize / 2 + (16 * randChunk.y));
        //print(playerSpawn);
		return (GameObject) Instantiate(playerPrefab, playerSpawn, Quaternion.identity);
    }

}

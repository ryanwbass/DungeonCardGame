using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public  float moveSpeed;
    private PlayerController controller;

	private int maxMana;
	private float currentMana;
	private float manaRegen;

	Rigidbody2D rb;

	public enum PlayerState { Alive, Dead }
	public PlayerState playerState = PlayerState.Alive;

	public Vector2 lookFacing;
    public Vector2 respawnPoint;
	public bool dead = false;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        controller.Initalize();
        maxMana = 10;
		SetMana(0);
		manaRegen = 1;
		//InvokeRepeating("UpdateEverySecond", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        //HandleMana();
        if (currentMana < maxMana)
        {
            SetMana(currentMana + manaRegen * Time.deltaTime);
        }
        

        if (playerState == PlayerState.Dead){
			rb.velocity = Vector2.zero;
			return;
		}
        /*
		Vector3 tryMove = Vector3.zero;
		
		if (Input.GetKey(KeyCode.D)){
			tryMove += Vector3Int.right;
		}	
		if (Input.GetKey(KeyCode.A)){
			tryMove += Vector3Int.left;
		}
		if (Input.GetKey(KeyCode.W)){
			tryMove += Vector3Int.up;
		}
		if (Input.GetKey(KeyCode.S)){
			tryMove += Vector3Int.down;
		}

		rb.velocity = Vector3.ClampMagnitude(tryMove, 1f) * MoveSpeed;
        */
	}

    public float GetCurrentMana()
    {
        return this.currentMana;
    }

    public void SpendMana(int manaSpent)
    {
        SetMana(currentMana - manaSpent);
    }

    public int GetMaxMana()
    {
        return this.maxMana;
    }
    private void SetMana(float newMana)
    {
        this.currentMana = newMana;
    }
}

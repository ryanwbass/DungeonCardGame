using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(HealthPool))]
public class ActorController : MonoBehaviour {

    private CapsuleCollider2D capsuleCollider;
    private CircleCollider2D circleCollider;
    private GameObject actor;
    public LayerMask mask;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private HealthPool healthPool;

    public Vector2 currentPosition;
    public Vector2Int currentChunk;

    private const int IsometricRangePerYUnit = 16;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        circleCollider = gameObject.transform.Find("ActorBase").GetComponent<CircleCollider2D>();
        actor = gameObject;
        healthPool = actor.GetComponent<HealthPool>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        currentChunk = new Vector2Int(Mathf.FloorToInt(transform.position.x / 16), Mathf.FloorToInt(transform.position.y / 16));
        print("Current Chunk: " + currentChunk);
        if(healthPool.currentHealth <= 0)
        {
            actor.SetActive(false);
        }
    }

    public void Move(Vector2 movement)
    {
        spriteRenderer.sortingOrder = -(int)(transform.position.y /** (IsometricRangePerYUnit - 1)*/);
        float frame = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer")).normalizedTime;
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            if(movement.x > 0)
            {
                animator.Play("Right", animator.GetLayerIndex("Base Layer"), frame);
                animator.SetFloat("offset", frame % 1);
                animator.SetBool("movingRight", true);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
                
            }
            else
            {
                animator.Play("Left", animator.GetLayerIndex("Base Layer"), frame);
                animator.SetFloat("offset", frame % 1);
                animator.SetBool("movingRight", false);
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
                
            }
        }
        else
        {
            if (movement.y > 0)
            {
                animator.Play("Up", animator.GetLayerIndex("Base Layer"), frame);
                animator.SetFloat("offset", frame % 1);
                animator.SetBool("movingRight", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingUp", true);
                animator.SetBool("movingDown", false);
                
            }
            else
            {
                animator.Play("Down", animator.GetLayerIndex("Base Layer"), frame);
                animator.SetFloat("offset", frame % 1);
                animator.SetBool("movingRight", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", true);
                
            }
        }

        Vector2 refinedMove = new Vector2();
        refinedMove = movement;

        if (GoodMove(movement))
        {
            AdjustTiles(GameManager.instance.GetGrid());
            gameObject.transform.position = (Vector2)gameObject.transform.position + refinedMove;
            return;
        }
          
        if (movement.x != 0)
        {
            if(!GoodMove(new Vector2(movement.x, 0)))
            {
                refinedMove.x = 0;
            }
        }

        if (movement.y != 0)
        {
            if (!GoodMove(new Vector2(0, movement.y)))
            {
                refinedMove.y = 0;
            }
        }
        AdjustTiles(GameManager.instance.GetGrid());
        gameObject.transform.position = (Vector2)gameObject.transform.position + refinedMove;
    }

    private void AdjustTiles(GameObject grid)
    {
        Tilemap groundLayer = grid.transform.GetChild(0).GetComponent<Tilemap>();
        Tilemap midLayer = grid.transform.GetChild(1).GetComponent<Tilemap>();
        Tilemap FrontLayer = grid.transform.GetChild(2).GetComponent<Tilemap>();
        for (int i = -2; i < 2; i++)
        {
            for (int j = -2; j < 2; j++)
            {
                Vector3Int currentTilePos = new Vector3Int((int)actor.transform.position.x + i, (int)actor.transform.position.y + j, 0);
                if (midLayer.GetComponent<Tilemap>().GetSprite(currentTilePos) != null)
                {
                    if(j < -1 && grid.transform.GetChild(2).GetComponent<Tilemap>().GetSprite(currentTilePos) == null)
                    {
                        FrontLayer.SetTile(currentTilePos, midLayer.GetComponent<Tilemap>().GetTile(currentTilePos));
                    }
                }
            }
            //}
        }
    }

    private bool GoodMove(Vector2 movement)
    {
        RaycastHit2D circleResult;
        gameObject.transform.Find("ActorBase").gameObject.layer = 2;
        circleResult = Physics2D.CircleCast((Vector2)transform.position + circleCollider.offset + movement, circleCollider.radius * .9f, Vector2.left, Mathf.Epsilon, mask, -Mathf.Infinity, Mathf.Infinity);
        gameObject.transform.Find("ActorBase").gameObject.layer = 8;
        if (circleResult.collider == null)
        {
            return true;
        }
        return false;
    }

    
}


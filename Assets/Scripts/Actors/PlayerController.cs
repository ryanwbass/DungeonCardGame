using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorController))]
public class PlayerController : MonoBehaviour {

    ActorController controller;
    Player player;
    private float moveSpeed;

    

    public void Initalize ()
    {
        controller = GetComponent<ActorController>();
        player = GetComponent<Player>();
        moveSpeed = player.MoveSpeed;
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .1f || Mathf.Abs(Input.GetAxis("Vertical")) > .1f)
        {
            movement = movement * moveSpeed * Time.deltaTime;
            controller.Move(movement);
        }

        //if (Input.GetKey = "Q") ;
    }
}

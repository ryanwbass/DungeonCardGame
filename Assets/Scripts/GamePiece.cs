using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePiece : MonoBehaviour {

    public string pieceType = "New Piece";
    public Sprite pieceSprite;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

}


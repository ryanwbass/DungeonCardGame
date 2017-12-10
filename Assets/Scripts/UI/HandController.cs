using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public GameObject cardPrefab;


    public void DrawCard()
    {
        GameObject newCard = (GameObject)Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        newCard.transform.SetParent(this.transform);
    }
}

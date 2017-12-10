using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public HandController hand;
    public ManaPoolController manaPool;

	// Use this for initialization
	void Awake () {
        hand = transform.Find("PlayerHand").gameObject.GetComponent<HandController>();
        manaPool = transform.Find("ManaPool").gameObject.GetComponent<ManaPoolController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

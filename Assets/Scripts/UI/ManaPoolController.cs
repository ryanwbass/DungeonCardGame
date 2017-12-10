using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPoolController : MonoBehaviour {

    Player player;
    Image currentMana;
    Text manaText;

	// Use this for initialization
	void Start () {
        player = GameManager.instance.GetPlayer().GetComponent<Player>();
        currentMana = transform.Find("CurrentMana").GetComponent<Image>();
        manaText = transform.Find("ManaText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        currentMana.fillAmount = player.GetCurrentMana() / player.GetMaxMana();
        manaText.text = (int)player.GetCurrentMana() + "/" + player.GetMaxMana();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public Text cardText;
    public Image cardImage;
    [SerializeField] private Ability ability;
    private int manaCost;
    private GameObject player;


    private void Start ()
    {
        Initialize(ability);
    }

    private void Update()
    {
        
    }

    public void Initialize (Ability selectedAbility)
    {
        player = GameManager.instance.GetPlayer();
        ability = selectedAbility;
        cardImage.sprite = ability.abilitySprite;
        cardText.text = ability.abilityName;
        manaCost = ability.abilityManaCost;
        ability.Initialize(player);
    }

    public int GetManaCost ()
    {
        return this.manaCost;
    }

    public void PlayCard (Vector3 target)
    {
        player.GetComponent<Player>().SpendMana(this.manaCost);
        ability.TriggerAbility();
    }


}

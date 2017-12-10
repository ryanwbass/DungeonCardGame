using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string abilityName = "New Ability";
    public Sprite abilitySprite;
    public AudioClip abilitySound;
    public int abilityManaCost;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

}

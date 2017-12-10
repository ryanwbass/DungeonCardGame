using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SkillShotTargetedAbility")]
public class SkillShotTargetedAbility : Ability {

    public int spellDamage = 1;
    public float projectileForce = 1f;
    public GameObject projectile;

    private SkillShotTargetedAbilityTriggerable skillShot;

    public override void Initialize(GameObject obj)
    {
        skillShot = obj.GetComponent<SkillShotTargetedAbilityTriggerable>();
        skillShot.projectileForce = projectileForce;
        skillShot.projectileDamage = spellDamage;
        skillShot.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        skillShot.Cast();
    }
}

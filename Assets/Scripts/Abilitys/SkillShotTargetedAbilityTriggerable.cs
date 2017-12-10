using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShotTargetedAbilityTriggerable : MonoBehaviour {

    [HideInInspector] public GameObject projectile;
    [HideInInspector] public float projectileForce = 50f;
    [HideInInspector] public int projectileDamage = 0;

    public void Cast()
    {
        Vector3 skillTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = skillTarget - transform.position;
        float rotationZ = -(90.0f - Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);
        Vector3 dir = difference.normalized;
        GameObject clonedProjectile = Instantiate(projectile, this.transform.position + new Vector3(0f, .5f, 0f), Quaternion.AngleAxis(rotationZ, Vector3.forward)) as GameObject;
        clonedProjectile.GetComponent<Projectile>().Init(projectileForce, projectileDamage);
    }
}

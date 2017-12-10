using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float projectileForce;
    private int projectileDamage;

    private void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameManager.instance.GetPlayer().GetComponent<CapsuleCollider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameManager.instance.GetPlayer().transform.Find("ActorBase").GetComponent<CircleCollider2D>());
    }

    public void Init(float projectileForce, int projectileDamage)
    {
        this.projectileForce = projectileForce;
        GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * this.projectileForce);
        this.projectileDamage = projectileDamage;
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<HealthPool>().currentHealth = collision.gameObject.GetComponent<HealthPool>().currentHealth - projectileDamage;
        }
        Destroy(this.gameObject);
    }
}

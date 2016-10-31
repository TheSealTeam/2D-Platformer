using UnityEngine;
using System.Collections;

public class rocketHit : MonoBehaviour {

    public float weaponDamage = 10;

    projectileController myPC;

    public GameObject explosionEffect;

    // Awake start when object comes to life
    void Awake ()
    {
        myPC = GetComponentInParent<projectileController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // If you hit a Shootable object, remove the forces from the missle and destroy it
    void OnTriggerEnter2D (Collider2D other) {
        //if we hit ground or Shootable the rocket explodes
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") || other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            myPC.removeForce(); //Remove the force of the rocket
            Instantiate(explosionEffect, transform.position, transform.rotation); //add explotionEffect
            Destroy(gameObject); //destroy the gameObject
            // if the target is an enemy remove health from it
            if (other.tag == "Enemy")
            { 
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>(); // get the enemies health
                hurtEnemy.addDamage(weaponDamage); // call addDamage
            }
        }
    }
}

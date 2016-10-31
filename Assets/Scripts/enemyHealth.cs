using UnityEngine;
using System.Collections;
using System;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth; // max health of enemy

    float currentHealth; // 

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth; // set the enemys health to max from start
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage) {
        currentHealth -= damage; // remove health if we are taking damage
        if(currentHealth <= 0) {
            makeDead(); // if our health is less then 0 or 0 then call makeDead
        }
    }

    void makeDead() {
        Destroy(gameObject); // delete our enemy
    }
}

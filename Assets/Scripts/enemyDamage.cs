using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other) {
        // if tag is player and the nextDamage limiter is less the the current time
        if(other.tag == "Player" && nextDamage < Time.time) {
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); // get the players health
            thePlayerHealth.addDamage(damage); // add damage to the player
            nextDamage = Time.time + damageRate; // add a time when the next damage can be done, as fastest

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject) {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}

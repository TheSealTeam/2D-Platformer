using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

    public float aliveTime;

    // Awake start when object comes to life
    void Awake () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

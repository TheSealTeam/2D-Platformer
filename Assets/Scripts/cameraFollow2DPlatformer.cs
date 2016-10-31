using UnityEngine;
using System.Collections;

public class cameraFollow2DPlatformer : MonoBehaviour {

    public Transform target; // what camera is following
    public float smoothing; // dampening effect

    Vector3 offset; // The diffrence between character and camera location

    float lowY; // lowest the camera can go

    // Use this for initialization
    void Start() {
        offset = transform.position - target.position; // implement an offset

        lowY = transform.position.y; // set lowY to where y is at start?

    }

    // FixedUpdate is called once per time t
    void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset; // unclear why i had to make it like this isnt this just (transform.position)?

        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime); // implements smoothing with use of deltaTime

        if (transform.position.y < lowY)  transform.position = new Vector3(transform.position.x, lowY, transform.position.z); // stops camera from falling down in the y plane when character does.
    }
}

using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    // movement variables
    public float maxSpeed;

    // jumping variables
    bool grounded = false;
    float groundCheckRadius = 02f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    // for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>(); //RB = Rigidbody
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}

    // Update is called once per frame
    void Update() {
        if(grounded && Input.GetAxis("Jump") > 0) {
            grounded = false; // we are gonna jump, we are not on the ground anymore
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        // player shooting, GetAxisRaw only takes a value of -1, 0 or 1
        if (Input.GetAxisRaw("Fire1") > 0) fireRocket();
    }


    // FixedUpdate is called every t sec
    void FixedUpdate () {

        // check if we are grounded if no, then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //if we are intersecting the ground it will be true else false
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal"); // returns a value between 1 and -1, gets from pressing a or d
        myAnim.SetFloat("speed", Mathf.Abs(move)); // use abs value of move to not get negative speed, seign as animation uses idle < 0.1 < running

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        //pressing the d key while facing left, flip character
        if(move > 0 && !facingRight) {
            flip();
        }
        //pressing the a key while facing right, flip character
        else if (move < 0 && facingRight) {
            flip();
        }
	}

    void flip() {
        facingRight = !facingRight; 
        //put x,y,z (2,2,1) from character scale
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //multiply x with -1 to change current facingDirection
        transform.localScale = theScale; // put the changed value back into scale we use
    }

    void fireRocket() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            if (facingRight) {
                // What we are gonna instantiate, where and rotation of obect
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}

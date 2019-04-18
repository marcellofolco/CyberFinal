using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float movespeed;
    private Rigidbody2D myRigidbody;
    public float jumpSpeed;
    public float jumpTime;
    public float jumpTimeCounter;

    public bool stoppedJumping;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatsIsGround;
    public bool isGrounded;
    public bool isFloating;

    //private Animator myAnim;

    public Vector3 respawnPosition;
    public Vector3 teleportPosition;

    public LevelManager theLevelManager;

    public Sprite pinkPlayer;
    public Sprite greenPlayer;
    public bool isPink;

    private SpriteRenderer theSpriteRenderer;

    GameObject[] greenTiles;
    GameObject[] pinkTiles;

    // Use this for initialization
    void Start () {

        teleportPosition = new Vector3(56.24f, 2.14f, 0);
        respawnPosition = new Vector3(45.66f, 22.015f, 0);

        myRigidbody = GetComponent<Rigidbody2D>();

        //myAnim = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        theLevelManager = FindObjectOfType<LevelManager>();
        theSpriteRenderer = GetComponent<SpriteRenderer>();

        greenTiles = GameObject.FindGameObjectsWithTag("GreenTile");
        pinkTiles = GameObject.FindGameObjectsWithTag("PinkTile");
        
    }
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatsIsGround);

        if (isGrounded)
        {
            jumpTimeCounter = jumpTime;
        }


        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(movespeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-movespeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            stoppedJumping = false;
            myRigidbody.drag = 0;
        }

        if (Input.GetButton("Jump") && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (Input.GetButton("Fire1") && !isGrounded)
        {
            myRigidbody.drag = 12;
            isFloating = true;
        }

        if (Input.GetButton("Fire1") && isFloating && isGrounded)
        {
            myRigidbody.drag = 0;
            isFloating = false;
        }

        if (Input.GetButtonUp("Fire1") && !isGrounded)
        {
            myRigidbody.drag = 0;
            isFloating = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            theSpriteRenderer.sprite = pinkPlayer;
            isPink = true;
        }

        if (Input.GetButtonDown("Fire3"))
        {
            theSpriteRenderer.sprite = greenPlayer;
            isPink = false;
		}

		//if (Input.GetButtonDown("XBOX_Start")) 
		//{
			//SceneManager.LoadScene (0);
		//}

        if (isPink == true)
        {
            foreach (GameObject go in greenTiles)
            {
                go.SetActive(false);
            }

            foreach (GameObject go in pinkTiles)
            {
                go.SetActive(true);
            }

        }
        else if (isPink == false)
        {
            foreach (GameObject go in greenTiles)
            {
                go.SetActive(true);
            }

            foreach (GameObject go in pinkTiles)
            {
                go.SetActive(false);
            }
        }




        //myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        //myAnim.SetBool("Grounded", isGrounded);
        //myAnim.SetBool("Floating", isFloating);
        //myAnim.SetBool("Pink", isPink);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillPlane")
        {
            theLevelManager.Respawn();
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPosition = collision.transform.position;
        }

        if (collision.tag == "TeleportPost")
        {
            gameObject.transform.localPosition = teleportPosition;
        }

        if (theLevelManager.scrollCount == 5 && collision.tag == "Finish")
        {
            SceneManager.LoadScene("FinalCutscene");
        }
    }
}

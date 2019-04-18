using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCollector : MonoBehaviour {

    private LevelManager theLevelManager;
    private CircleCollider2D theCircleCollider2D;



    public Sprite scrollSprite;
    public Sprite emptyScrollSprite;

    public int scrollValue;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        theCircleCollider2D = GetComponent<CircleCollider2D>();
    

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && gameObject == GameObject.FindGameObjectWithTag("Scroll1"))
        {
            theLevelManager.AddScrolls(scrollValue);

            gameObject.transform.localPosition = new Vector3(-49.33638f, 4.803049f, 50.2f);

            theCircleCollider2D.enabled = false;

        }

        else if (collision.tag == "Player" && gameObject == GameObject.FindGameObjectWithTag("Scroll2"))
        {
            theLevelManager.AddScrolls(scrollValue);

            gameObject.transform.localPosition = new Vector3(51.036f, 1.22f, -0.3f);

            theCircleCollider2D.enabled = false;

        }

        else if (collision.tag == "Player" && gameObject == GameObject.FindGameObjectWithTag("Scroll3"))
        {
            theLevelManager.AddScrolls(scrollValue);

            gameObject.transform.localPosition = new Vector3(51.37f, -1.067f, -0.3f);

            theCircleCollider2D.enabled = false;
        }

        else if (collision.tag == "Player" && gameObject == GameObject.FindGameObjectWithTag("Scroll4"))
        {
            theLevelManager.AddScrolls(scrollValue);

            gameObject.transform.localPosition = new Vector3(44.7f, -1.07f, -0.3f);

            theCircleCollider2D.enabled = false;

        }

        else if (collision.tag == "Player" && gameObject == GameObject.FindGameObjectWithTag("Scroll5"))
        {
            theLevelManager.AddScrolls(scrollValue);

            gameObject.transform.localPosition = new Vector3(44.752f,1.242f,-1.43f);

            theCircleCollider2D.enabled = false;

        }

    }
}


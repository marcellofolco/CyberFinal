using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    private PlayerController thePlayer;
    private SpriteRenderer theSpriteRenderer;

    public GameObject deathSplosion;
    public GameObject deathSplosion2;


    public int scrollCount;

    public AudioSource levelMusic;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        if (thePlayer.isPink == false)
        {


            thePlayer.gameObject.SetActive(false);

            Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);

        } else if (thePlayer.isPink == true)
        {
            thePlayer.gameObject.SetActive(false);

            Instantiate(deathSplosion2, thePlayer.transform.position, thePlayer.transform.rotation);
        }

        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddScrolls(int scrollsToAdd)
    {
        scrollCount += scrollsToAdd; 


    }


}

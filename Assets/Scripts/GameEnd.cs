using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {

    private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {

        theLevelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggernEnter2D(Collider2D collision)
    {
        if (theLevelManager.scrollCount == 5)
        {
            if(collision.tag == "Player")
            {
                SceneManager.LoadScene("FinalCutscene");
            }
        }


    }

}

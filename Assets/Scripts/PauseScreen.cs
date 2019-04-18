using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public GameObject thePauseScreen;

    private PlayerController thePlayer;

    private LevelManager theLevelManager;
    

	// Use this for initialization
	void Start () {

        thePauseScreen.SetActive(false);
        thePlayer = FindObjectOfType<PlayerController>();
        theLevelManager = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }

        }
 
	}

    public void PauseGame()
    {
        Time.timeScale = 0;

        thePauseScreen.SetActive(true);
        thePlayer.gameObject.SetActive(false);
        theLevelManager.levelMusic.Pause();
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theLevelManager.levelMusic.Play();

        Time.timeScale = 1f;
            
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

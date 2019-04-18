using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(JumpToScene());
	}

    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Level");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

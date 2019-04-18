using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutscene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(JumpToScene());
    }

    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

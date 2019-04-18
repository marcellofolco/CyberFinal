using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUI : MonoBehaviour {

	public Text scrollText;

	private int count;


	void Start () {
	
		count = 0;
		Counter ();
	}


	//void OnCollisionEnter2D()... when player will touche item with tag scroll


	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			count = count + 1;
			scrollText.text = count.ToString ();
		}
	}

	void Counter(){
		scrollText.text = count.ToString ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlTrigger : MonoBehaviour {

    GameObject buttonControl;
	// Use this for initialization
	void Start () {
        buttonControl = GameObject.FindGameObjectWithTag("ButtonKontrol");
      //  buttonControl.GetComponent<ButtonControl>().YeniSceneSerp();
	}
	
	
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("enter") || Input.GetKeyDown("space")) {
            Debug.Log("key was pressed");
            SceneManager.LoadScene("RollABall");
        }
	}
}

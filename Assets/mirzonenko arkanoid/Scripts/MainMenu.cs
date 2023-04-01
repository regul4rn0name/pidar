﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void OnStartClick()
    {
        SceneManager.LoadScene("FirstLevelScene", LoadSceneMode.Single);
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}

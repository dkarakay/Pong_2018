using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Buttons : MonoBehaviour {
    public GameObject restartButton, exitButton, resumeButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0f;
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            resumeButton.SetActive(true);
        }
	}

    public void RestartButton(){
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton(){
        Application.Quit();
    }
    public void ResumeButton(){
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }
}

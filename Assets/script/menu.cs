using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSettingClick()
    {

    }

    public void OnContinune()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void newGameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quiteGame()
    {
        Application.Quit();
    }
}

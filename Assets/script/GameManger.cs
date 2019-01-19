using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour {
    CarController carController;
    public Text timerText;
    private float startTimer;
	// Use this for initialization
	void Start () {
        startTimer = Time.time;
        //carController = GetComponent<CarController>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();

            SceneManager.LoadScene("Menu 3D");
        }
        float t = Time.time - startTimer;

        string minutes = ((int)t / 60).ToString();
        string second = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + second;
	}

    public void speedUpCar()
    {
       // CarController.MaxSpeed = CarController.MaxSpeed + 100;

        //Debug.Log("test" + CarController.MaxSpeed);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine (LoadMenuScene());
	}

	IEnumerator LoadMenuScene(){
		yield return new WaitForSeconds (3.5f);
		SceneManager.LoadScene ("SampleScene");
	}		
}

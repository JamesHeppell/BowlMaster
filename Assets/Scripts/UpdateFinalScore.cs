using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateFinalScore : MonoBehaviour {

	private Text gameScore;
	// Use this for initialization
	void Start () {
		gameScore = GetComponent<Text>();
		gameScore.text = PlayerPrefsManager.GetCurrentScore().ToString();
	}
	

}

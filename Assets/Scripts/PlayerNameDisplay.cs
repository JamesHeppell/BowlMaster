using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerNameDisplay : MonoBehaviour {

	private Text playerName;
	// Use this for initialization
	void Start () {
		playerName = GetComponent<Text>();
		playerName.text = PlayerPrefsManager.GetPlayerName();
	}

}

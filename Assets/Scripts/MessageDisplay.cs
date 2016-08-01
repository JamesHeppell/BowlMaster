using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageDisplay : MonoBehaviour {

	private Image image;
	private Text message;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		message = GetComponentInChildren<Text>();

		image.enabled = false;
		message.enabled = false;
	}

	public void OnDisplayMessage(string action){
		image.enabled= true;
		message.text = action;
		message.enabled = true;
	}

	public void OnRemoveMessage(){
		image.enabled= false;
		message.enabled = false;
	}

}
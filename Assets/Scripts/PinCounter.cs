using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManger;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;

	// Use this for initialization
	void Start () {
		gameManger = GameObject.FindObjectOfType<GameManager>();
	}

	public void Reset(){
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider collider) {
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.name == "Ball"){
			ballOutOfPlay=true;
		}

    }

	int CountStanding(){
		int standing = 0 ;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standing++;
			}
		}
		return standing;
	}

	void UpdateStandingCountandSettle (){
    	//Update the lastStandingCount
    	int currentStanding = CountStanding();

    	if (currentStanding != lastStandingCount){
    		lastChangeTime = Time.time;
    		lastStandingCount = currentStanding;
    		return;
    	}

    	float settleTime = 3f; //How long to wait if pin settles

    	if ((Time.time - lastChangeTime) > settleTime){
			PinsHaveSettled();
    	}
		
    }

    void PinsHaveSettled (){
		
    	int standing = CountStanding();
    	int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManger.Bowl (pinFall);

    	lastStandingCount = -1; //Indicats pins have settled, and ball not in box
		standingDisplay.color = Color.green;
		ballOutOfPlay = false;
    }


	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();

		if (ballOutOfPlay){
			standingDisplay.color = Color.red;
			UpdateStandingCountandSettle();
		}
	}
}

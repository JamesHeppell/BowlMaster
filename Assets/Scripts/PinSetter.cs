using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;

	private Animator animator;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		pinCounter=GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponentInParent<Animator>();

	}

	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIFStanding();
		}
    }

    public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
    }

    public void RenewPins(){
		Instantiate(pinSet, new Vector3(0, 60, 1829),Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
		
	}

	public void PerformAction (ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		}else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		}else if (action == ActionMaster.Action.EndGame){
			//throw new UnityException ("Dont know how to end game yet");
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();

		}else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		}

	}

}

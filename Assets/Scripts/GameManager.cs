using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int> ();
	private Ball ball;
	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;
	private LevelManager levelManager;
	private MessageDisplay messageDisplay;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		messageDisplay = GameObject.FindObjectOfType<MessageDisplay>();

		PlayerPrefsManager.SetCurrentScore(0);
	}


	public void Bowl (int pinFall){
		try {
			rolls.Add(pinFall);
			ball.Reset();
		}catch{
			Debug.LogWarning ("Something went wrong in Bowl()");
		}

		try{
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
			scoreDisplay.FillRoll(rolls);
		} catch {
			Debug.LogWarning ("Something went wrong when calling FillRollCard");
		}

		//display message if strike or spare
		string currentMessage = scoreDisplay.IsStrikeOrSpare(rolls);
		if (currentMessage != "Null"){
			messageDisplay.OnDisplayMessage(currentMessage);
			messageDisplay.Invoke("OnRemoveMessage",4f);
		}


		ActionMaster.Action currentAction = ActionMaster.NextAction (rolls);
		pinSetter.PerformAction (currentAction);

		//Updating the current high score of the game for ending purposes
		if (ScoreMaster.ScoreCumulative(rolls).Count>=1){
			int currentScore = ScoreMaster.ScoreCumulative(rolls)[ScoreMaster.ScoreCumulative(rolls).Count -1];
			PlayerPrefsManager.SetCurrentScore(currentScore);

			if (PlayerPrefsManager.GetHighScore()<currentScore){
				PlayerPrefsManager.SetHighScore(currentScore);
			}
			//ending the game and updating the highest score if necessary
			if (currentAction == ActionMaster.Action.EndGame){
				Debug.Log("I'm being called to end game");
				levelManager.Invoke("LoadNextLevel",2f);
			}
		}


	}

}

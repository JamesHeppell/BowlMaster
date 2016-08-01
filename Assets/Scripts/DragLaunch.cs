using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;
	private GameObject floor;
	private float floorwidth;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
		floor = GameObject.Find("Lane/Floor");
		floorwidth = floor.transform.localScale.x;

	}

	public void MoveStart (float amount){
		if (ball.inPlay == false){
			float ballposition = ball.transform.position.x;
			if (amount>0){
				// moving right
				if (ballposition < (floorwidth/2 - ball.transform.localScale.x)){
					ball.transform.Translate(new Vector3 (amount, 0 , 0));
				}
			} else if (amount <0){
				//moving left
				if (ballposition > (-floorwidth/2 + ball.transform.localScale.x)){
					ball.transform.Translate(new Vector3 (amount, 0 , 0));
				}
			}
		}
		//Debug.Log("ball moved" + amount);
	}

	public void DragStart(){
		if (ball.inPlay == false){
			// Capture time & position of drag start
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}

	}

	public void DragEnd(){
		if (ball.inPlay == false){
			// Launch the ball
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
			ball.Launch(launchVelocity);
		}

	}
}

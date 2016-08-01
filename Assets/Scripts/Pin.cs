using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;
	public float distanceToRaise = 80f;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	public bool IsStanding(){
		Vector3 roationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - roationInEuler.x);
		//float tiltInZ = Mathf.Abs(roationInEuler.z);

		if ( (tiltInX < standingThreshold  || tiltInX > 360 - standingThreshold) ){
			return true;
		}else{
			return false;
		}

	}

	public void RaiseIFStanding(){
		if (IsStanding()){
			rigidBody.useGravity=false;
			rigidBody.angularVelocity = new Vector3 (0f, 0f, 0f);
			rigidBody.velocity = new Vector3 (0f, 0f, 0f);
			transform.Translate(new Vector3 (0, distanceToRaise , 0),Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0);
		}

    }

    public void Lower(){
		if (IsStanding()){
			transform.Translate(new Vector3 (0, -distanceToRaise , 0),Space.World);
			rigidBody.useGravity=true;
		}
    }

	// Update is called once per frame
	void Update () {
		//print (name + " " + IsStanding());

	}
}

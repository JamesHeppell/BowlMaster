using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool inPlay=false;
	public Vector3 launchVelocity;

	private Rigidbody rigidBody;
	private AudioSource	audioSource;
	private Vector3 ballStartPosition;


	// Use this for initialization
	void Start () {
		rigidBody=GetComponent<Rigidbody>();
		rigidBody.useGravity=false;
		ballStartPosition = transform.position;


	}

	public void Launch (Vector3 velocity)
	{
		inPlay=true;
		rigidBody.useGravity=true;
		rigidBody.velocity = velocity;
		audioSource=GetComponent<AudioSource>();
		audioSource.Play ();

	}

	public void Reset(){
		inPlay=false;
		rigidBody.useGravity=false;
		transform.position = ballStartPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = new Vector3 (0f, 0f, 0f);
		rigidBody.angularVelocity = Vector3.zero;

	}
	// Update is called once per frame
	void Update () {
	
	}
}

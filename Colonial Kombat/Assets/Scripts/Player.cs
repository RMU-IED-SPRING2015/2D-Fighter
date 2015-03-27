using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Character CharacterRef;


	// Use this for initialization
	void Start () {
		if (CharacterRef == null)
			Debug.LogError ("You need to set the character in the Unity Editor.");

	}
	
	// Update is called once per frame
	void Update () {

		if (CharacterRef != null) {
			CharacterRef.WalkTo( CharacterRef.transform.position.x + Input.GetAxis( "horizontal" ) );
		}
	}


}


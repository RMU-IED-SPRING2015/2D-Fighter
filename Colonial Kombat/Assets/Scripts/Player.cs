using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject CharacterRef;
	public Transform SpawnPoint;

	public PlayerType Type;
	public KeyCode Right = KeyCode.D;
	public KeyCode Left = KeyCode.A;
	public KeyCode Up = KeyCode.W;
	public KeyCode Down = KeyCode.S;
	public float Speed = 1.0f;


	private GameObject _character;

	// Use this for initialization
	void Start () {
		if (CharacterRef == null)
			Debug.LogError ("You need to set the character in the Unity Editor.");
		else
			_character = Instantiate (CharacterRef,SpawnPoint.position,Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (_character != null) {
			_character.GetComponent<Character>().WalkTo( 
			                                            new Vector2( 
			            _character.transform.position.x + (Input.GetKey( Right )?Speed:0.0f) - (Input.GetKey ( Left )?Speed:0.0f), 
			            _character.transform.position.y ) );

			if ( Input.GetKey(Up) )
				_character.GetComponent<Character>().Jump();



		}
	}


}

public enum PlayerType
{
	Human,
	Net,
	Computer
}
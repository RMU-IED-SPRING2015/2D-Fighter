using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject TrackPlayer;

	// Use this for initialization
	void Start () {
		if (TrackPlayer == null)
			Debug.LogError ("You need to set the track player object in the Unity Editor.");

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = TrackPlayer.transform.position;

		Camera.main.transform.LookAt ( new Vector3 (pos.x, pos.y, 0.0f) );
			//transform.position.Set ( pos.x, pos.y, Camera.main.transform.position.z );
	}
}

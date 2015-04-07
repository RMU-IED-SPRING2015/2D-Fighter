using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//public GameObject TrackPlayer;

	// Use this for initialization
	void Start () {
		//if (TrackPlayer == null)
			//Debug.LogError ("You need to set the track player object in the Unity Editor.");

	}
	
	// Update is called once per frame
	void Update () {
		//Vector.2 pos = TrackPlayer.transform.position;
		float dist = 0.0f;

		Vector2 difference = Vector2.zero; 
	

		Character[] chars = GameObject.FindObjectsOfType<Character>();

		foreach (Character c1 in chars)
			foreach (Character c2 in chars)
				if (!(c1 == c2)) {
					difference = c1.GetComponentInParent<Transform> ().position
								- c2.GetComponentInParent<Transform> ().position;

					dist = Mathf.Max (new float [] { dist,
						difference.magnitude });
				}

		dist = Mathf.Clamp(dist,6.0f,20.0f);
		Camera.main.orthographicSize = dist * .5f;
		transform.position = new Vector3( 
		//Vector3 p = (difference / 2.0f);
		//Vector3 delta = camera.ViewportToWorldPoint ();
		//transform.position = delta;
			//transform.position.Set ( pos.x, pos.y, Camera.main.transform.position.z );
	}
	
}

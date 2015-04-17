using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour 
{
	//Variables and stuff
	public GUIStyle play;
	public GUIStyle exit;
	// Use this for initialization
	void Start () 
	{
	
	}

	//Use this for GUI elements
	void OnGUI()
	{


 		const int playbuttonWidth = 200;
		const int playbuttonHeight = 68;
		const int exitbuttonWidth = 142;
		const int exitbuttonHeight = 76;


		//Determine button's placement
		//X = center of screen, y = center of screen
		Rect buttonRect = new Rect
		(
			Screen.width / 2 - (playbuttonWidth / 2),
			Screen.height / 2 - (playbuttonHeight / 4),
			playbuttonWidth, playbuttonHeight
		);
		//Get rid of gray default background of Unity

		//Draw button and load image from resources
		if(GUI.Button (buttonRect, "",play))
		{
			Debug.Log ("BUTTON SUCCESSFUL");
            
		}

		Rect exitbuttonRect = new Rect
		(
			Screen.width / 2 - (exitbuttonWidth / 2),
			Screen.height/ 2 + exitbuttonWidth /3 ,
			exitbuttonWidth, exitbuttonHeight
		);


		//Draw button and load image from resources
		if(GUI.Button (exitbuttonRect, "",exit))
		{
			Debug.Log ("EXIT BUTTON SUCCESSFUL");
            Application.Quit(); 
		}



	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}



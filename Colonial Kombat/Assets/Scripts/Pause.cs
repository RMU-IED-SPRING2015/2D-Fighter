using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    bool isPause = false;
    Rect MainMenu = new Rect(Screen.width/2 - 200, Screen.height/2 - 200, 400, 400);
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            //Debug.Log ("Escape hit.");

        }
    }
    void OnGUI()
    {

        if (isPause)
        {
            GUI.Window(0, MainMenu, TheMainMenu, "Pause Menu");
            //Debug.Log ("On GUI");
        }
    }

    void TheMainMenu(int i)
    {
        if (GUILayout.Button("Main Menu"))
        {
            Debug.Log("Main Menu");
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Restart"))
        {
            Debug.Log("Restart");
            Application.LoadLevel("Fight");
        }
        if (GUILayout.Button("QUIT"))
        {
            Application.Quit();
        }
    }
}

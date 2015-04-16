using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //public GameObject TrackPlayer;

    // Use this for initialization
    void Start()
    {
        //if (TrackPlayer == null)
        //Debug.LogError ("You need to set the track player object in the Unity Editor.");

        // Automagically make a pause Menu object for each scene.
        if (GameObject.Find("Pause") == null)
            GameObject.Instantiate( Resources.Load("Prefabs/Pause") ).name = "Pause";
    }

    // Update is called once per frame
    void Update()
    {
        //Vector.2 pos = TrackPlayer.transform.position;
        float dist = 0.0f;

        Vector3 difference = Vector3.zero;
        Vector3 c = Vector3.zero;

        Character[] chars = GameObject.FindObjectsOfType<Character>();

        foreach (Character c1 in chars)
            foreach (Character c2 in chars)
                if (!(c1 == c2))
                {
                    difference = c1.GetComponentInParent<Transform>().position
                                - c2.GetComponentInParent<Transform>().position;

                    c = c2.GetComponentInParent<Transform>().position;

                    dist = Mathf.Max(new float[] { dist,
                        difference.magnitude });
                }



        Vector3 p = (difference * 0.5f);

        //Debug.Log(camera.orthographicSize);

        //GameObject.Find("TEST").transform.position = ( c + p );
        Camera.main.transform.position = c + p - Vector3.forward * 20.0f;

        dist = Mathf.Clamp(dist, 30.0f, 2000.0f);
        camera.orthographicSize = dist * .5f;

    }

}
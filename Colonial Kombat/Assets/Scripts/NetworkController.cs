using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {

    public string IP_Address = "127.0.0.1";
    public int PortNumber = 48972;

    private bool _connected = false;

    public bool Connected
    {
        get { return _connected; }
    }

    void OnDisconnectedFromServer()
    {
        _connected = false;
    }

    void OnPlayerDisconnected()
    {
        //_connected = false;
    }

    void OnConnectedToServer() 
    {
        _connected = true;
    }

    void OnServerInitialized()
    {
        _connected = true;
    }

    private void OnGUI()
    {
        // Show the connection menu:
        if (!_connected)
        {
            IP_Address = GUILayout.TextField(IP_Address);
            int.TryParse(GUILayout.TextField(PortNumber.ToString()), out PortNumber);

            if (GUILayout.Button("Connect"))
                Network.Connect(IP_Address, PortNumber);

            if (GUILayout.Button("Host"))
                Network.InitializeServer( 32, PortNumber, !Network.HavePublicAddress() );
        }
        else
        {
            GUILayout.Label("Connections: " + Network.connections.Length.ToString());

            if (GUILayout.Button("Play")) 
            {
                Application.LoadLevel(2);
            }
        }
    }

}

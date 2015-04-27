using UnityEngine;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;


public class NetworkClient : MonoBehaviour {

    public string Host_IP_Address = "127.0.0.1";
    public string Multicast_IP_Address = "239.0.0.222";
    public static int MulticastPortNumber = 48970;
    public static int PortNumber = 48972;

    private bool _connected = false;
    private bool _listening = false;

    private string _local_IP = "";
    private StringCollection _log = new StringCollection();
    private UdpClient _client;

    private IPAddress _multicastIP_Address;
    private IPEndPoint _EP;
    Byte[] _buffer = null;

    void Awake()
    {
        // Start a UDP client.
        _client = new UdpClient();

        AsyncCallback _callback = new AsyncCallback(ProcessRequest);

        // make it a multicast client
        _multicastIP_Address = IPAddress.Parse(Multicast_IP_Address);
        _client.JoinMulticastGroup(_multicastIP_Address);
        

        // The endpoint will be 
        _EP = new IPEndPoint(_multicastIP_Address, MulticastPortNumber);

    }

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string IP_Address
    {
        get
        {
            if (_local_IP == "")
            {
                string HostName = System.Net.Dns.GetHostName();
                IPHostEntry IP_Entry = System.Net.Dns.GetHostEntry(HostName);
                IPAddress[] _IP_Address = IP_Entry.AddressList;
                _local_IP = _IP_Address[_IP_Address.Length - 1].ToString();
            }
            return _local_IP;
        }
    }

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
        if (!_connected)
        {
            Host_IP_Address = GUILayout.TextField(Host_IP_Address);
            int.TryParse(GUILayout.TextField(PortNumber.ToString()), out PortNumber);

            if (GUILayout.Button("Connect"))
                Network.Connect(IP_Address, PortNumber);

            if (GUILayout.Button("Scan"))
                Scan();

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
    
    private void Scan()
    {
        // make the message to broadcast
        _buffer = Encoding.Unicode.GetBytes(IP_Address + ":Lobby");
        // ask the Lobby Server for its IP.
        _client.Send(_buffer, _buffer.Length, _EP);

        AsyncReceive();

    }

    /// <summary>
    /// This function will set the listener to wait for a message on the multicast, and then pass that off to the callback.
    /// </summary>
    public void AsyncReceive()
    {
        if (!_listening)
        {
            _client.BeginReceive(new AsyncCallback(ProcessRequest), null);
            _listening = true;
        }
    }

    /// <summary>
    /// This is the Asycronous Callback to listen to the messages on the multicast. It will receive the message and process it and send it to the SwitchMessage() function.
    /// </summary>
    /// <param name="data">The message that is received will fill the data parameter.</param>
    private void ProcessRequest(IAsyncResult data)
    {
        byte[] received = _client.EndReceive(data, ref _EP);
        _listening = false;

        string strData = Encoding.Unicode.GetString(received);
        _log.Add("{type:received,time:" + DateTime.Now + ",data:" + strData + "}");

        int colon = strData.IndexOf(":");
        strData = strData.Substring(colon + 1);

        SwitchMessage(strData);
    }

    /// <summary>
    /// This function waits blocks the flow of the program until a message is heard over the multicast.  It will receive the message and process it and send it to the SwitchMessage() function. NOT RECOMMENDED
    /// </summary>
    public void BlockingReceive()
    {
        _buffer = _client.Receive(ref _EP);

        string strData = Encoding.Unicode.GetString(_buffer);
        _log.Add("{type:received,time:" + DateTime.Now + ",data:" + strData + "}");

        // Strip off the senders IP.
        int colon = strData.IndexOf(":");
        strData = strData.Substring(colon + 1);
        // send the string command to the message handler.
        SwitchMessage(strData);
    }

    /// <summary>
    /// This function determines the reaction to certain messages.
    /// </summary>
    /// <param name="strData">The processed message.</param>
    public void SwitchMessage(string strData)
    {
        switch (strData)
        {
            case "Lobby":
                
                break;
            case default(string):
                // Do nothing.
                break;
        }
    }
}

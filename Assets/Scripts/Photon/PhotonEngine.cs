using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TaidouCommon;

public class PhotonEngine : MonoBehaviour,IPhotonPeerListener {

    PhotonPeer peer;
    ConnectionProtocol protocol = ConnectionProtocol.Tcp;
     string serverAddress = "10.80.6.79:4530";
    public string ApplicationName = "TaidouServer";
    public delegate void OnConnectedToServerEvent();
    public event OnConnectedToServerEvent OnConnectedToServer;

    bool isConnected = false;
    Dictionary<byte, ControllerBase> controllers = new Dictionary<byte, ControllerBase>();
    private static PhotonEngine _instance;
    public static PhotonEngine Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
        peer = new PhotonPeer(this, protocol);
        peer.Connect(serverAddress, ApplicationName);
       
    }
    // Update is called once per frame
    void Update () {
        if (peer!=null) peer.Service();
	}
    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log(level + ":" + message);
    }

    public void OnEvent(EventData eventData)
    {
       
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        ControllerBase controller;
        controllers.TryGetValue(operationResponse.OperationCode, out controller);
        if (controller != null)
        {
            controller.OnOperationResponse(operationResponse);

        }
        else
        {
            Debug.LogWarning("Receive a unknown response . OperationCode :" + operationResponse.OperationCode);
        }
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log("ds:" + statusCode);
        switch (statusCode)
        {
            case StatusCode.Connect:
                isConnected = true;
                OnConnectedToServer();
                break;
            default:
                isConnected = false;
                break;
                
        }
    }
    public void RegisterController(OperationCode opCode,ControllerBase controller)
    {
        Debug.Log("sendrequest to server , opcode : " + opCode);
        controllers.Add((byte)opCode, controller);
    }
    public void UnRegisterController(OperationCode opCode)
    {
        controllers.Remove((byte)opCode);
    }
    public void SendRequest(OperationCode opCode,Dictionary<byte,object> parameters)
    {
        peer.OpCustom((byte)opCode, parameters, true);
    }
}

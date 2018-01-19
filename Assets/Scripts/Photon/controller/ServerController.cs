using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using TaidouCommon;
using TaidouCommon.Model;
using LitJson;
using UnityEngine.UI;

public class ServerController : ControllerBase {
    public GameObject ServerRed;
    public GameObject ServerGreen;
  
     GameObject UIStart;
    private void start()
    {
       
    }
    
    public override void OnOperationResponse(OperationResponse response)
    {
        Dictionary<byte, object> parameters = response.Parameters;
        object jsonObject = null;
        parameters.TryGetValue((byte)ParameterCode.ServerList, out jsonObject);
        List< TaidouCommon.Model.ServerProperty > serverList = JsonMapper.ToObject<List< TaidouCommon.Model.ServerProperty >>(jsonObject.ToString());
        int index = 0;
        ServerProperty spDefault = null;
        GameObject goDefault = null;
        UIStart = GameObject.Find("UIStart").gameObject;
        foreach (TaidouCommon.Model.ServerProperty spTemp in serverList)
        {
            string ip = spTemp.IP+":4530";
            string name = spTemp.Username;
            int count = spTemp.Count;
            GameObject go = null;
            
            if (count > 50)
            {  
                go = Instantiate(ServerRed, UIStart.transform.Find("StartBG/SelectSeverBG/Content/Panel"));
            }
            else
            {
                Debug.Log(ServerGreen);

                go = Instantiate(ServerGreen, UIStart.transform.Find("StartBG/SelectSeverBG/Content/Panel"));
            }

            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.ip = ip;
            sp.name = name;
            sp.count = count;
            if (index == 0)
            {
                spDefault = sp;
                goDefault = go;
            }
            
            index++;
        }
        GameObject selectedserver = UIStart.transform.Find("StartBG/TotalList/SelectSeverBtn").gameObject;
        selectedserver.transform.Find("Text").GetComponent<Text>().text = spDefault.transform.Find("SeverNameTxt").GetComponent<Text>().text;
        selectedserver.transform.Find("Text").GetComponent<Text>().color = spDefault.transform.Find("SeverNameTxt").GetComponent<Text>().color;
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        PhotonEngine.Instance.OnConnectedToServer += GetServerList;
    }


    public void GetServerList()
    {

        PhotonEngine.Instance.SendRequest(OperationCode.GetServer, new Dictionary<byte, object>());
    }

    // Update is called once per frame
    void Update () {
		
	}
    public override void OnDestroy()
    {
        base.OnDestroy();
        PhotonEngine.Instance.OnConnectedToServer -= GetServerList;
      

    }
    public override OperationCode OpCode
    {
        get
        {
            return OperationCode.GetServer;
        }
    }
    GameObject seleserver;
    void OnServerSelect(GameObject serverGo)
    {
        seleserver = UIStart.transform.Find("StartBG/TotalList/SelectSeverBtn").gameObject;
        seleserver.transform.Find("Text").GetComponent<Text>().text = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().text;
        seleserver.transform.Find("Text").GetComponent<Text>().color = serverGo.transform.Find("SeverNameTxt").GetComponent<Text>().color;
    }


}

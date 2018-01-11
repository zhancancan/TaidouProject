using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TaidouCommon;
using UnityEngine;
using LitJson;
using TaidouCommon.Model;

public class RegisterController : ControllerBase {
    UIRegister uigesiter;
    private void Awake()
    {
        uigesiter = GetComponent<UIRegister>();
    }
    public override OperationCode OpCode
    {
        get
        {
            return OperationCode.Register;
        }
    }

    public override void OnOperationResponse(OperationResponse response)
    {
        switch (response.ReturnCode)
        {
            case (short)ReturnCode.Success:

                uigesiter.Onclick();
                break;
            case (short)ReturnCode.Fail:
                MessageManager._instance.ShowMessage(response.DebugMessage);
                break;
        }
    }

    public void Register(string username, string password)
    {
      
        User user = new User() { Username = username, Password = password };
        string json = JsonMapper.ToJson(user);
        Dictionary<byte, object> parameters = new Dictionary<byte, object>();
        parameters.Add((byte)ParameterCode.User, json);
        PhotonEngine.Instance.SendRequest(OperationCode.Register, parameters);
    }

}

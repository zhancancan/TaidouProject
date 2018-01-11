using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using LitJson;
using TaidouCommon;
using TaidouCommon.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginController : ControllerBase {
    public override OperationCode OpCode
    {
        get { return OperationCode.Login; }
    }

    

    public void Login(string username, string password)
    {
       
        User user = new User() { Username = username, Password = password };
        string json = JsonMapper.ToJson(user);
        Dictionary<byte, object> parameters = new Dictionary<byte, object>();
        parameters.Add((byte)ParameterCode.User, json);
        PhotonEngine.Instance.SendRequest(OperationCode.Login, parameters);
    }
    public override void OnOperationResponse(OperationResponse response)
    {
        switch (response.ReturnCode)
        {
            case (short)ReturnCode.Success:
                //根据登录的用户  加载用户的角色信息
                SceneManager.LoadSceneAsync(ConstDates.SelectPlayerSceneIndex);
                break;
            case (short)ReturnCode.Fail:
                UILogin.Instance.Error();
                break;
        }
    }
}

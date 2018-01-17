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
    RoleController rolecontroller;
  
    public override OperationCode OpCode
    {
        get { return OperationCode.Login; }
    }
    public override void Start()
    {
        base.Start();
        rolecontroller = this.GetComponent<RoleController>();
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
                rolecontroller.GetRole();
                break;
            case (short)ReturnCode.Fail:
                UILogin.Instance.Error();
                break;
        }
    }
}

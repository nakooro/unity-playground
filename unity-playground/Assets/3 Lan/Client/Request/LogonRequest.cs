using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class LogonRequest : BaseRequest
{

    protected override void Awake()
    {
        base.Awake();
        GameFace.Instance.AddRequest(ActionCode.Logon, this);
    }
    public override void SendRequest(MainPack pack) {}
    public void Logon(string username, string password)
    {
        MainPack pack = new MainPack();
        LoginPack loginPack = new LoginPack();
        loginPack.Username = username;
        loginPack.Password = password;
        pack.Loginpack = loginPack;
        base.SendRequest(pack);
    }

}

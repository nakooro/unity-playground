using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class LogonRequest : BaseRequest
{
    protected override void Start()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Logon;

        base.Start();        
    }

    public void OnReponse(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Fail:
                print("OnReponse :: Fail");
                break;
            case ReturnCode.Success:
                print("OnReponse :: Success");
                break;
            default:
                print("OnReponse :: Default");
                break;
        }
        // base.OnResponse(pack);
    }
    public void SendRequest(string username, string password)
    {
        MainPack pack = new MainPack();
        pack.Requestcode = requestCode;
        pack.Actioncode = actionCode;
        LoginPack loginPack = new LoginPack();
        loginPack.Username = username;
        loginPack.Password = password;
        pack.Loginpack = loginPack;
        base.SendRequest(pack);
    }

}

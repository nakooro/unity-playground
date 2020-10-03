using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;
public class RequestManager : BaseManager
{
    Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();
    public RequestManager(GameFace face) : base(face) { }

    public override void OnInit()
    {
        base.OnInit();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void AddRequest(ActionCode action, BaseRequest request)
    {
        requestDict.Add(action, request);
    }
    public void RemoveRequest(ActionCode action)
    {
        requestDict.Remove(action);
    }
    public void Logon(string username, string password)
    {

        // requestDict[ActionCode.Logon].SenedRequest();
    }



}

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
        requestDict.Clear();
    }

    public void AddRequest(ActionCode action, BaseRequest request)
    {
        requestDict.Add(action, request);
    }
    public void RemoveRequest(ActionCode action)
    {
        requestDict.Remove(action);
    }
    public void HandleResponse(MainPack pack)
    {
        if (requestDict.TryGetValue(pack.Actioncode, out BaseRequest request))
        {
            request.OnResponse(pack);
        }
        else
        {
            Debug.Log("沒有 request 處理");
        }
    }
}

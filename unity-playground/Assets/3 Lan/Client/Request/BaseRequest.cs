using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class BaseRequest : MonoBehaviour
{
    protected RequestCode requestCode;
    protected ActionCode actionCode;

    protected virtual void Start()
    {        
        GameFace.Instance.AddRequest(this.actionCode, this);
    }
    protected virtual void OnDestroy()
    {
        GameFace.Instance.RemoveRequest(this.actionCode);
    }
    public virtual void OnResponse(MainPack pack)
    {
        // GameFace.Instance.HandleResponse(pack);
    }
    public virtual void SendRequest(MainPack pack)
    {
        GameFace.Instance.Send(pack);                   
    }


}

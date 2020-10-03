using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class BaseRequest : MonoBehaviour
{
    RequestCode requestCode;
    ActionCode actionCoded;

    protected virtual void Awake()
    {        
        GameFace.Instance.AddRequest(this.actionCoded, this);
    }
    public virtual void SendRequest(MainPack pack)
    {
        GameFace.Instance.Send(pack);                   
    }
 
    
}

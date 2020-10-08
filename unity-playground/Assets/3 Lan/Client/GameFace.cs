using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class GameFace : MonoBehaviour
{       
    ClientManager clientManager;
    RequestManager requestManager;
    private static GameFace face;
    public static GameFace Instance
    {
        get {return face; }
    }
    private void Awake()
    {
        face = this;

    }
    void Start()
    {
        
        clientManager = new ClientManager(this);
        clientManager.OnInit();

        requestManager = new RequestManager(this);
        requestManager.OnInit();
    }
    
    private void OnDestroy()
    {
        clientManager.OnDestroy();
        requestManager.OnDestroy();
    }

    public void Send(MainPack pack)
    {
        clientManager.Send(pack);
    }

    public void AddRequest(ActionCode action, BaseRequest request)
    {
        requestManager.AddRequest(action, request);
    }
    public void RemoveRequest(ActionCode action)
    {
        requestManager.RemoveRequest(action);
    }
    public void HandleResponse(MainPack pack)
    {
        requestManager.HandleResponse(pack);
    }
}

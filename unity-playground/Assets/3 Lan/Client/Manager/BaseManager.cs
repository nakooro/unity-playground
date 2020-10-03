using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager 
{
    GameFace face;
    public BaseManager(GameFace face)
    {
        this.face = face;
    }
    public virtual void OnInit() { }
    public virtual void OnDestroy() { }
}

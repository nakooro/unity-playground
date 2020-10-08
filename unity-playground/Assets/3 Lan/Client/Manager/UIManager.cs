using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PanelType
{
    Start,
    Login,
    Logon,
    Gameover,
    Pause
}

public class UIManager : BaseManager
{
    Dictionary<PanelType, BasePanel> panelDict = new Dictionary<PanelType, BasePanel>();
    public UIManager(GameFace face) : base(face) { }

    void Start()
    {
        
    }

    public override void OnInit()
    {

        base.OnInit();
    }
    BasePanel SpawnPanel(PanelType panel) { return null; }
    void PopPanel() { }
    void PushPanel() { }

}

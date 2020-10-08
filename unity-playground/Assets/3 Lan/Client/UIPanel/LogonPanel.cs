using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogonPanel : MonoBehaviour
{
    [SerializeField] LogonRequest logonRequest;
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Button logon;

    void Start()
    {
        logon?.onClick.AddListener(OnLogon);
    }
    void OnLogon()
    {
        if (username.text == "" || password.text == "")
            return;
        logonRequest?.SendRequest(username.text, password.text);     
    }
    
}

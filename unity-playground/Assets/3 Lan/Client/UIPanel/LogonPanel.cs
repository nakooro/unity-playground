using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogonPanel : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Button logon;

    void Start()
    {
        logon.onClick.AddListener(Logon);
    }
    void Logon()
    {
        GameFace.Instance.Logon(username.text, password.text);
    }
    
}

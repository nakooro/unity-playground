using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;




public class MultiThread : MonoBehaviour
{
    bool isRunning = false;
    List<UnityAction> actions = new List<UnityAction>();
        
    
    void Start()
    {                
        print("Start() :: Starting");
        Thread t = new Thread(SlowJob);
        t.Start();
        print("Start() :: Done");
    }

    
    void Update()
    {        
        if (isRunning)
            print("Update() :: Job is doing");

        if (actions.Count > 0)
        {
            actions[0]();
            actions.RemoveAt(0);
        }
    }

    void SlowJob()
    {
        isRunning = true;

        print("SlowJob() :: Doing 2 sec");

        Thread.Sleep(2000);


        UnityAction action = () =>
        {
            transform.position = Vector3.up;
            print("ShowJob() :: aciton=> :: Asigned action");
        };

        actions.Add(action);

        isRunning = false;
        print("SlowJob() :: Done");

        
    }
        
    
}

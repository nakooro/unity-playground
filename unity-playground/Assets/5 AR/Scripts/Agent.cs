using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR
{
    public class Agent : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private Transform target;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.localPosition = target.position;
            // transform.position = target.position;
        }
    }

}

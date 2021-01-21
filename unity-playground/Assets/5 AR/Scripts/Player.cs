using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR
{
    public interface IPlayerInput
    {
        void Move();
    }

    public class PlayerInput : IPlayerInput
    {     
        void IPlayerInput.Move()
        {
            throw new System.NotImplementedException();
        }
    }
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update
        IPlayerInput playerInput = new PlayerInput();
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                MoveLeft(playerInput);
            }
        }
        void MoveLeft(IPlayerInput input)
        {
            input.Move();
        }

        
    }

}

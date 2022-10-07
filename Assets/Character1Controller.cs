using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character1Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody Character;
    [SerializeField] private float walkingSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    [SerializeField] private int playerIndex;
    

    //private bool isAiming;




    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(transform.up * rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            }
        }

       

          if (Input.GetKeyDown(KeyCode.Space))
          {
            walkingSpeed = 10f / 2;
          }

          if (Input.GetKeyUp(KeyCode.Space))
          {
            walkingSpeed = 5 * 2;
          }
    }


}



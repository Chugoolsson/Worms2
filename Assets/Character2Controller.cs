using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;


public class Character2Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody Character;
    [SerializeField] private float walkingSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    [SerializeField] private int playerIndex;

    [SerializeField] private GameObject shieldWallPrefab;
    [SerializeField] private Transform shieldSpawningPoint;
 
    
    

    private bool touchingTheGround;
    void Start()
    {

    }


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

            if (Input.GetKeyDown(KeyCode.Space) && TouchingTheGround())
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && TurnManager.GetInstance().IsItPlayerTurn(2))
            {
                GameObject newShieldWall = Instantiate(shieldWallPrefab, shieldSpawningPoint.transform.position, shieldSpawningPoint.transform.rotation);

                newShieldWall.GetComponent<ShieldWall>().Initialize();
            }

        }

    }

    private bool TouchingTheGround()
    {
        RaycastHit hit;

        return Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
    }
   
    void Jump()
    {
        Character.AddForce(Vector3.up * 180f);
    }

   



}    


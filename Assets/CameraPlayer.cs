using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [Header("References")]
   
    public Transform Character1;
   
    public Rigidbody rb;

   

    public Transform combatView;

    public CameraStyle currentStyle;

    public GameObject cameraCombat;

    public GameObject cameraBasic;

    public GameObject cameraCharacterTwo;

    public enum CameraStyle
    {
        Basic,
        Combat,
        CharacterTwo
    }
 
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
       
    }

    void Update()
    {

        void SwitchCameraStyle(CameraStyle newStyle)
        {
            cameraCombat.SetActive(false);
            cameraBasic.SetActive(false);
            cameraCharacterTwo.SetActive(false);

            if (newStyle == CameraStyle.Basic) cameraBasic.SetActive(true);
            if (newStyle == CameraStyle.Combat) cameraCombat.SetActive(true);
            if (newStyle == CameraStyle.CharacterTwo) cameraCharacterTwo.SetActive(true);

            currentStyle = newStyle;
        }

        if (Input.GetKeyDown(KeyCode.Space) && TurnManager.GetInstance().IsItPlayerTurn(1)) SwitchCameraStyle(CameraStyle.Combat);

        if (Input.GetKeyUp(KeyCode.Space) && TurnManager.GetInstance().IsItPlayerTurn(1)) SwitchCameraStyle(CameraStyle.Basic);

        if (TurnManager.GetInstance().IsItPlayerTurn(2)) SwitchCameraStyle(CameraStyle.CharacterTwo);

        if (TurnManager.GetInstance().IsItPlayerTurn(1) && !Input.GetKey(KeyCode.Space)) SwitchCameraStyle(CameraStyle.Basic);





    }
}

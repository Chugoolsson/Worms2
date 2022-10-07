using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static CameraPlayer;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    [SerializeField] private Camera aimingCamera;
    private Vector3 cursorPosition;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,  Quaternion.LookRotation(bulletSpawnPoint.forward, Vector3.up));
           
          
        }
       */

        if (Input.GetKeyDown(KeyCode.Mouse0) && TurnManager.GetInstance().IsItPlayerTurn(1))
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
           
            newBullet.GetComponent<Bullet>().Initialize();
        }

      
       

       
    }

   
}

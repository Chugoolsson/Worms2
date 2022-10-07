using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private Rigidbody bulletRb;
    [SerializeField] private float damage;
    

    private bool isActive;

    private void Start()
    {
        bulletRb.AddForce(transform.forward * bulletSpeed);
    }

    public void Initialize()
    {
        isActive = true;
    }

    void Update()
    {
        if (isActive) 
        {
           Destroy(gameObject, bulletLifeTime);
        }
           
    }    



    void FixedUpdate()
    {
       // bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            Debug.Log("Hello!");
            Destroy(gameObject);
        }
        
    }
}

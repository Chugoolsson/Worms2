using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWall : MonoBehaviour
{

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize()
    {
        isActive = true;
    }

    public static void ShieldDestroyed(GameObject Shield)
    {
        Destroy(Shield);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

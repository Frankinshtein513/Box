using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speadRotation;
   
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speadRotation);
    }
    
    
        
   
}

    

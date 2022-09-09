using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyFlipper : MonoBehaviour
{
    public AIPath aip;
    Vector3 temp;
    
    void Update()
    {
        
        if(aip.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.05f, 0.05f, 1f);
           
        }
        else if (aip.desiredVelocity.x <= 0.01f)
        {
            
            transform.localScale = new Vector3(0.05f, 0.05f, 1f);            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSec : MonoBehaviour
{
    public float DestroyAfter;
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }

    
    
}

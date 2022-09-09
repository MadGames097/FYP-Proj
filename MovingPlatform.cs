using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public float Speed;
    public Transform StartPos;
    Vector3 NextPos;

    void Start()
    {
        NextPos = StartPos.position;
    }

    
    void Update()
    {
        if(transform.position == Pos1.position)
        {
            NextPos = Pos2.position;
        }
        if (transform.position == Pos2.position)
        {
            NextPos = Pos1.position;
        }


        transform.position = Vector3.MoveTowards(transform.position, NextPos, Speed * Time.deltaTime);
            //.MoveTowards(transform.position, NextPos, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

}

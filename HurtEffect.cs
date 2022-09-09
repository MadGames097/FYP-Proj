using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEffect : MonoBehaviour
{
    SpriteRenderer rend;
    Color c;
   // BoxCollider2D boxcol;
   // CircleCollider2D circol;
    void Start()
    {
       // boxcol = GetComponent<BoxCollider2D>();
       // circol = GetComponent<CircleCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Enemy" && PlayerAttribs.CurrHealth >= 0) 
        {
            StartCoroutine("Invulnerable");
        }
	}

    IEnumerator Invulnerable()
    {
        gameObject.layer = 12;
        //Physics2D.IgnoreLayerCollision(9,13,true);
        //boxcol.isTrigger = true;
        //circol.isTrigger = true;
        //boxcol.enabled = false;
        //circol.enabled = false;
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        //boxcol.enabled = true;
        //circol.enabled = true;
        //boxcol.isTrigger = true;
        //circol.isTrigger = true;
        //Physics2D.IgnoreLayerCollision(9, 13, false);
        c.a = 1f;
        rend.material.color = c;
        gameObject.layer = 13;
    }
}

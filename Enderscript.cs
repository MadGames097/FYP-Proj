using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enderscript : MonoBehaviour
{
    public GameObject Ending;
    public Level_changer LC;
    private void Start()
    {
        Ending.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            
            Ending.gameObject.SetActive(true);
            Invoke("BringNextLevel", 2);
        }
    }

    private void BringNextLevel()
    {
        LC.FadetoLevel();
    }


}

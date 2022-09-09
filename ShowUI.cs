using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUI : MonoBehaviour
{
    public GameObject UIObject;
    void Start()
    {
        UIObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UIObject.SetActive(true);
            StartCoroutine("WaitASec");
        }
    }

    private void OnTriggerExit(Collider player)
    {
            UIObject.SetActive(false);    
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UIObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

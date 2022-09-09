using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMang : MonoBehaviour
{
    public static LevelMang instance;

    public Transform RespawnPt;
    public GameObject PlayerPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(PlayerPrefab, RespawnPt.position, Quaternion.identity);
    }
}

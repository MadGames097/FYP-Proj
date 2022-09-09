using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebris : MonoBehaviour
{
    public List<GameObject> DebrisPrefabs = new List<GameObject>();
    public float TimeToSpawn;
    private float CurrTimeToSpawn;

    public bool isRandom;
    public Vector2 center;
    public Vector2 size;


    void Start()
    {
        CurrTimeToSpawn = TimeToSpawn;
    }

    void Update()
    {
        if(CurrTimeToSpawn > 0)
        {
            CurrTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnDebrisAtLoc();
            CurrTimeToSpawn = TimeToSpawn;
        }
    }

    public void SpawnDebrisAtLoc()
    {
        int index = isRandom ? Random.Range(0, DebrisPrefabs.Count) : 0;
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        if (DebrisPrefabs.Count > 0) 
        { 
        Instantiate(DebrisPrefabs[index], pos, DebrisPrefabs[index].transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(center, size);
    }
}

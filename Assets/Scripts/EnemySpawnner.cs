using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public float MinY = -4.2f;
    public float MaxY = 4.2f;


    public GameObject[] Meteor;
    public GameObject EnemyPre;

    public float Timer = 2f;

    void Start()
    {
        Invoke("SpawnEnemy", Timer);
    }

    void SpawnEnemy()
    {
        float posY = Random.Range(MinY, MaxY);
        Vector3 temp = transform.position;
        temp.y = posY;
        if(Random.Range(0,2)>0)
        {
            Instantiate(Meteor[Random.Range(0, Meteor.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(EnemyPre, temp, Quaternion.Euler(180f, 0f, 180f));
        }

        Invoke("SpawnEnemy", Timer);
    }
    
}

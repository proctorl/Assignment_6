using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Transform Tree;
    public Transform Rock;
    float posx;
    float posz;
    float posy;
    void Start()
    {
        for (int i = 0; i < 10; i ++)
        {
            posx = Random.Range(-20, 20);
            posz = Random.Range(-20, 20);

            Instantiate(Tree, new Vector3(posx, 1, posz), Quaternion.identity);
            
        }
        for (int i = 0; i < 10; i++)
        {
            posx = Random.Range(-20, 20);
            posz = Random.Range(-20, 20);
            posy = Random.Range(-180, 180);

            Instantiate(Rock, new Vector3(posx, 1.27f, posz), Quaternion.Euler(0, posy, 0));
        }

    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    public GameObject player;
    public GameObject turkey;
    public Transform parent;
    
    public float distance = 2f;
    bool carrying;
    public float height = 2f;


    void Update()
    {
        if (carrying)
            Carry(turkey);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pen")
        {
            DropObject();
            carrying = false;
        }
        if (other.gameObject.tag == "Player")
        {
            Carry(turkey);
            carrying = true;
        }

         



    }

    void Carry(GameObject o)
    {
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.GetComponent<Rigidbody>().useGravity = false;

        //o.transform.position = player.transform.position + player.transform.forward * distance + player.transform.up * height;
        //o.transform.rotation = player.transform.rotation * Quaternion.Euler(-90, 90, 0);

        o.transform.position = parent.position;
        o.transform.rotation = parent.rotation;
    }

   void DropObject()
    {
        turkey.GetComponent<Collider>().isTrigger = false;
        turkey.GetComponent<Rigidbody>().useGravity = true;
        turkey.GetComponent<Rigidbody>().isKinematic = false;
    }
}

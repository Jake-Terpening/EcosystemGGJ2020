using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    private Animal owner;

    private void Awake()
    {
        owner = GetComponentInParent<Animal>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision with " + collision.gameObject);
        GameObject go = collision.gameObject;
        if (owner.herbivoir)
        {
            if (go.GetComponent<Plant>())
            {
                Debug.Log("I smell a plant");
                owner.target = go;
            }
        }
        if (owner.carnivoir)
        {
            Debug.Log("I eat animals");
            if (go.GetComponent<Animal>())
            {
                Debug.Log("I found an animal");
                owner.target = go;
            }
        }
    }
}

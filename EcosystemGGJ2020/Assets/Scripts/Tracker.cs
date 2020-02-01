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
        if (owner.foodConsumed > owner.foodPerCycle)    //don't look for food if you are not hungry
            return;
        Debug.Log("collision with " + collision.gameObject);
        GameObject go = collision.gameObject;
        if (owner.herbivoir)
        {
            if (go.GetComponent<Plant>())
            {
                owner.target = go;
            }
        }
        if (owner.carnivoir)
        {
            if (go.GetComponent<Animal>())
            {
                Animal target = go.GetComponent<Animal>();
                if (owner.combatPower > target.combatPower)
                    owner.target = go;
            }
        }
    }
}

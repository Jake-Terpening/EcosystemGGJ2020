using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    private Animal owner;

    private void Awake()
    {
        owner = GetComponentInParent<Animal>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (owner.foodConsumed > owner.foodPerCycle)        //don't eat food if you are not hungry
            return;
        Debug.Log("collision with " + collision.gameObject);
        GameObject go = collision.gameObject;
        if (owner.herbivoir)
        {
            Debug.Log("I eat plants");
            if (go.GetComponent<Plant>())
            {
                Debug.Log("I found a plant");
                Plant target = go.GetComponent<Plant>();
                owner.EatFood(target);
            }
        }
        if (owner.carnivoir)
        {
            Debug.Log("I eat animals");
            if (go.GetComponent<Animal>())
            {
                Debug.Log("I found an animal");
                Animal target = go.GetComponent<Animal>();
                if (owner.combatPower > target.combatPower)
                    owner.EatFood(target);
                else
                    Debug.Log("It was too powerful...");
            }
        }
    }
}

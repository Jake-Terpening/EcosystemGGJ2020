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
    void EatFood(Consumable food)
    {
        print("yummy");
        owner.foodConsumed += food.consumptionReward;
        Destroy(food.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision with " + collision.gameObject);
        GameObject go = collision.gameObject;
        if (owner.herbivoir)
        {
            Debug.Log("I eat plants");
            if (go.GetComponent<Plant>())
            {
                Debug.Log("I found a plant");
                Plant target = go.GetComponent<Plant>();
                EatFood(target);
            }
        }
        if (owner.carnivoir)
        {
            if (go.GetComponent<Animal>())
            {
                Animal target = go.GetComponent<Animal>();
                if (owner.combatPower > target.combatPower)
                    EatFood(target);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Consumable
{
    public string name;

    public int foodPerCycle;
    public int combatPower;
    public float movePerCycle;


    public int foodConsumed;

    public bool herbivoir;
    public bool carnivoir;

    private Rigidbody2D rb2d;

    public Vector2 debugMove;

    public GameObject target;

    void RunCycle()
    {
        
    }


    private void DebugMove()//force animal to go in a certain direction for debugging purposes
    {
        rb2d.velocity = debugMove;
    }

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        DebugMove();
    }

    public void MoveTowardTarget()
    {
        //Find direction
        Vector3 dir = (target.transform.position - rb2d.transform.position).normalized;

        rb2d.MovePosition(rb2d.transform.position + dir * movePerCycle * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if(target)
        {
            MoveTowardTarget();
        }
    }

    public void EatFood(Consumable food)
    {
        print("yummy");
        foodConsumed += food.consumptionReward;
        Destroy(food.gameObject);
        target = null;
        DebugMove();
    }
}

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
}

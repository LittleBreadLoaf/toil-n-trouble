using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Vector2 homePosition;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        target = GameObject.FindWithTag("Player").transform;
        homePosition = transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector2.Distance(target.position, transform.position) <= chaseRadius
            && Vector2.Distance(target.position, transform.position) >= attackRadius)
        {
            Vector2 movement = target.position - transform.position;
            MoveEnemy(movement, walkSpeed);
        } else if(Vector2.Distance(target.position, transform.position) > chaseRadius
            && Vector2.Distance(homePosition, transform.position) > 0.2)
        {
            Vector2 movement = homePosition - new Vector2(transform.position.x, transform.position.y);
            MoveEnemy(movement, walkSpeed);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public string enemyName;
    public float walkSpeed;
    public int baseAttack;
    Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void MoveEnemy(Vector2 movement, float moveSpeed)
    {
        Vector2 location = new Vector2(transform.position.x, transform.position.y);
        movement.Normalize();
        enemyRigidBody.MovePosition(location + (movement * moveSpeed * Time.deltaTime));
    }
}

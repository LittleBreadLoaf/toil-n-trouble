using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D playerRigidBody;
    private Vector2 speedChange;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        speedChange = Vector2.zero;
        speedChange.x = Input.GetAxisRaw("Horizontal");
        speedChange.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Action"))
        {
            if (currentState != PlayerState.attack
                && currentState != PlayerState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.28f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (speedChange != Vector2.zero)
        {
            MoveCharacter(speedChange, speed);
            animator.SetFloat("moveX", speedChange.x);
            animator.SetFloat("moveY", speedChange.y);
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter(Vector2 movement, float moveSpeed)
    {
        Vector2 location = new Vector2(transform.position.x, transform.position.y);
        movement.Normalize();
        playerRigidBody.MovePosition(location + (movement * moveSpeed * Time.deltaTime));
    }

    public void OnHit(float knockbackTime, float damage)
    {
        currentHealth.value -= damage;
        playerHealthSignal.Raise();
        if(currentHealth.value > 0)
        {
            StartCoroutine(KnockbackCo(knockbackTime));
        }
    }

    private IEnumerator KnockbackCo(float knockbackTime)
    {
        if (playerRigidBody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            playerRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.walk;
        }
    }
}

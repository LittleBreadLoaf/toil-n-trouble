using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool playerInRange;
    public PlayerMovement player;
    protected Animator anim;

    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void OnPlayerInteract()
    {
    }

    protected virtual void OnPlayerEnteredRange()
    {
        playerInRange = true;
    }

    protected virtual void OnPlayerExitedRange()
    {
        playerInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnteredRange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerExitedRange();
        }
    }

}

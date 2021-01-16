using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private Animator anim;
    public float breakAnimLength;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        anim.SetBool("break", true);
        StartCoroutine(BreakCoroutine());
    }

    IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(breakAnimLength);
        this.gameObject.SetActive(false);
    }
}

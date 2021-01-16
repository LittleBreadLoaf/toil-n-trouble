﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockbackTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackCo(enemy));
            }
        }
    }

    private IEnumerator KnockbackCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}

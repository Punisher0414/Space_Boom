﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Invoke("Destroy", 5F);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth e = collision.gameObject.GetComponentInParent<EnemyHealth>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }

        Destroy();
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}

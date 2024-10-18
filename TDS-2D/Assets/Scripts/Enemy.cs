using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 3f;
    [SerializeField] GameObject enemy;
    [SerializeField] Collider2D clBullet;
    [SerializeField] float enemyHealth = 100f;
    Rigidbody2D rb;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(player != null)
        {
        Debug.Log(enemyHealth);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * enemySpeed * Time.fixedDeltaTime);
        }

    }
}

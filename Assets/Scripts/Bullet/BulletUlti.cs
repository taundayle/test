﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUlti : MonoBehaviour
{
    public int damage;
    public float speedbullet;
    private Rigidbody2D Bullett;
    private Transform player; //Tham chiếu tới player
    private bool isBullet = true;
    private float timer;
    void Start()
    {
        Bullett = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveBullet();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5)
        {
            Destroy(gameObject);
        }
        Destroybullet();
    }
    void moveBullet()
    {
        // Thiết lập vận tốc theo trục x dựa trên hướng của người chơi
        Vector2 chiuchiu = player.transform.localScale.x > Mathf.Epsilon ? Vector2.right : Vector2.left;
        Bullett.velocity = chiuchiu * speedbullet;
    }
    private void Destroybullet()
    {
        if (isBullet == false)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.TakeLife(damage);
        }
        //if (collision.CompareTag("Player"))
        //{
        //    FindObjectOfType<GameSession>().AddBullet(1);
        //    FindObjectOfType<Gun>().AddBullet(1);
        //    Destroy(gameObject);
        //}
    }
}

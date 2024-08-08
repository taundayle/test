using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 1;
    public float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            Destroy(gameObject);
        }
    }
    public void Up1(int num)
    {
        damage += num;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.TakeLife(damage);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    private enum Type { Punching, Shooting };
    [SerializeField] private Type types;

    [SerializeField] private float offset;

    private void Update()
    {
        if (types == Type.Punching)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (types == Type.Shooting)
        {
            if (Vector2.Distance(player.position, transform.position) > distance && Vector2.Distance(player.position, transform.position) <= distance*2)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

        Vector3 direction = player.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        if (health <= 0)
            Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    [SerializeField] private float offset;

    [SerializeField] private GameObject hurts;

    private void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);

        transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)player.position, speed * Time.deltaTime);

        try
        {
            Vector3 direction = player.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        }
        catch
        {
            Debug.Log("Oh. Not good. No player!");
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(hurts, player.position, Quaternion.identity);
        health -= damage;
    }
}

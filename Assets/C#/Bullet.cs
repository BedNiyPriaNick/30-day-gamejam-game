using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed, lifeTime, distance;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask whatIsSolid;

    [SerializeField] private bool enemyBullet;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>()?.TakeDamage(damage);
                hitInfo.collider.GetComponent<Boss>()?.TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Player") && enemyBullet)
            {
                hitInfo.collider.GetComponent<Player>()?.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}

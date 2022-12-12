using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [HideInInspector] public int health;
    [SerializeField] private Transform player;

    [HideInInspector] public bool isInvulnerable;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LookAtPlayer()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, player.position.z);
        transform.LookAt(dir);
    }

    private void Update()
    {
        if (isInvulnerable)
            return;

        else if (health <= 0 && !isInvulnerable)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;

    private void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

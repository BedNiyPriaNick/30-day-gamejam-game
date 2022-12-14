using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [SerializeField] private Transform punchPoint;
    [SerializeField] private LayerMask player_mask, enemy_mask;
    [SerializeField] private float radius;

    [SerializeField] private int damage;

    [SerializeField] private float startTimeBtwPunch;

    [SerializeField] private bool enemyPunch;

    private float timeBtwShots;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && !enemyPunch)
            {
                Punching();
            }
            else if (enemyPunch)
            {
                Punching();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Punching()
    {
        if (enemyPunch)
        {
            Collider2D[] hitIfo = Physics2D.OverlapCircleAll(punchPoint.position, radius, player_mask);

            if (hitIfo != null)
            {
                for (int i = 0; i < hitIfo.Length; i++)
                {
                    hitIfo[i].GetComponent<Player>().TakeDamage(damage);
                }
            }
        }
        else
        {
            anim.SetTrigger("punch");
        }
        timeBtwShots = startTimeBtwPunch;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchPoint.position, radius);
    }

    public void PlayerPunch()
    {
        Collider2D[] hitIfo = Physics2D.OverlapCircleAll(punchPoint.position, radius, enemy_mask);

        if (hitIfo != null)
        {
            for (int i = 0; i < hitIfo.Length; i++)
            {
                hitIfo[i].GetComponent<Enemy>()?.TakeDamage(damage);
                hitIfo[i].GetComponent<Boss>()?.TakeDamage(damage);
            }
        }
        timeBtwShots = startTimeBtwPunch;
    }
}

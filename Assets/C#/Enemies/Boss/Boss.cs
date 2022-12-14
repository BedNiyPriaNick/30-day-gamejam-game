using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int health;
    [SerializeField] private Transform player;

    public bool isInvulnerable;

    Animator anim;

    GameObject[] enemies;
    [SerializeField] private GameObject[] points;

    [SerializeField] private GameObject slice, musicBattle, swordSound, hurts;

    private void Start()
    {
        Instantiate(musicBattle, player.position, Quaternion.identity);
        anim = GetComponent<Animator>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, player.position.z);
        transform.LookAt(dir);
    }

    public void Attacking()
    {
        for(int i = 0; i < points.Length; i++)
        {
            Instantiate(slice, points[i].transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene("GameEnd");

        if(health <= 200)
        {
            anim.SetBool("SecondForm", true);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(hurts, player.position, Quaternion.identity);
        health -= damage;
    }

    public void CanAttack()
    {
        attack = true;
    }

    public void NoAttack()
    {
        attack = false;
    }

    bool attack;

    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && attack)
        {
            Instantiate(swordSound, player.position, Quaternion.identity);
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
}

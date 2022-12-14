using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private float startTimeBtwShots;

    [SerializeField] private bool enemyGun;

    private float timeBtwShots;

    [SerializeField] Enemy enemy;

    [SerializeField] private GameObject shootSound;

    private void Update()
    {
        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) || (enemyGun && !enemy.unfollowPlayer))
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        try
        {
            Instantiate(shootSound, transform.position, Quaternion.identity);
            Instantiate(bullet, transform.position, transform.parent.rotation);
        }
        catch
        {
            Debug.Log("Gun can't shoot");
        }
        timeBtwShots = startTimeBtwShots;
    }
}

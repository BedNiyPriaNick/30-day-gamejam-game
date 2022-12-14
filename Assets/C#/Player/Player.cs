using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isInvulnerable;

    [Space]

    private Camera cam;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector2 direction;

    [Space]

    [Header("WeaponHold")]
    [SerializeField] private bool hold;
    [SerializeField] private float distance;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private LayerMask weapon;
    Collider2D hit;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private GameObject walkSound;

    #region my_fun

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HP();
        PlayerLook();
        TakeWeapon();

        if(direction.x != 0f || direction.y != 0f)
        {
            walkSound.SetActive(true);
        }
        else
        {
            walkSound.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerLook()
    {
        Vector3 direction = cam.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
    }

    private void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("moveVector.x", Mathf.Abs(direction.x));
        anim.SetFloat("moveVector.y", Mathf.Abs(direction.y));

        rb.MovePosition((Vector2)rb.position + direction * speed * Time.deltaTime);
    }

    private void HP()
    {
        if (isInvulnerable)
            return;
        if (health <= 0)
            this.gameObject.SetActive(false);
    }

    private void TakeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!hold)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.OverlapCircle(holdPoint.position, distance, weapon);

                if(hit != null && hit.tag == "Weapon")
                {
                    hold = true;
                    hit.gameObject.transform.SetParent(this.gameObject.transform);
                }
            }
            else
            {
                hold = false;

                if (hit != null)
                {
                    hit.gameObject.transform.parent = null;
                }
            }
        }

        if (hold)
        {
            hit.gameObject.transform.position = holdPoint.position;
            hit.gameObject.transform.rotation = transform.rotation;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}

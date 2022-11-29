using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isInvulnerable;
    [SerializeField] private Transform holdPoint;

    [Space]

    private Camera cam;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector2 direction;

    private Rigidbody2D rb;
    private Animator anim;

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

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void HP()
    {
        if (isInvulnerable)
            return;
        if (health <= 0)
            this.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    #endregion

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            collision.gameObject.transform.parent = this.gameObject.transform;
            collision.gameObject.transform.position = holdPoint.position;
        }
    }
}

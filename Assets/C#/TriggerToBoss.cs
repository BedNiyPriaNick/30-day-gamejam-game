using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToBoss : MonoBehaviour
{
    [SerializeField] private GameObject tp, samurai;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = tp.transform.position;
            samurai.SetActive(true);
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}

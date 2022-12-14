using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fog : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnBecameInvisible()
    {
        anim.enabled = false;
    }

    private void OnBecameVisible()
    {
        anim.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    [SerializeField] private GameObject slice;

    public void MakeASlice()
    {
        Instantiate(slice, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}

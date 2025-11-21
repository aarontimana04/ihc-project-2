using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhisics : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.MovePosition(target.transform.position);
    }
}

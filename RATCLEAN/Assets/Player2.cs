using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody rb;

    public float force , girar ;

    float hor, ver;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(hor, 0, 0);

        rb.AddForce(direction * force);

        Vector3 diret= new Vector3(0, 0, ver);

       rb.AddForce(diret * girar);
    }
}



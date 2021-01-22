using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform car;
    public float speed = 17;
    public float acceleration = 0.05f;
    private float currentAcceleration;
    private char direction;


    Vector3 rotationRight = new Vector3(0, 150, 0);
    Vector3 rotationLeft = new Vector3(0, -150, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    // Initialize
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        car = gameObject.GetComponent<Transform>();
        currentAcceleration = 0f;
        direction = 'f';
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            accelerate();
        }
        if (Input.GetKey("s"))
        {
            reverse();
        }

        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }

        if (!Input.anyKey)
        {
            decellerate();
        }
    }

    void accelerate()
    {
        if(currentAcceleration < 1)
            currentAcceleration += acceleration;
        transform.Translate(forward * speed * Time.deltaTime * currentAcceleration);
        direction = 'f';
    }

    void reverse()
    {
        if (currentAcceleration < 1)
            currentAcceleration += acceleration;
        transform.Translate(backward * speed * Time.deltaTime * currentAcceleration);
        direction = 'b';
    }

    void decellerate()
    {
        if (currentAcceleration > 0)
            currentAcceleration -= acceleration;
        transform.Translate(((direction == 'f') ? forward : backward) * speed * Time.deltaTime * currentAcceleration);
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Debuff")
        {
            speed = 5;

            yield return new WaitForSeconds(5);

            speed = 17;
        }
        else
        {
            speed = 30;

            yield return new WaitForSeconds(5);

            speed = 17;
        }
    }
}
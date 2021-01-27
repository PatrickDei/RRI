using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform car;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float acceleration;
    private float currentAcceleration;
    private char direction;
    private float currentSpeed;
    private float distanceToGround;

    Vector3 rotationRight = new Vector3(0, 80, 0);
    Vector3 rotationLeft = new Vector3(0, -80, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        car = gameObject.GetComponent<Transform>();
        currentAcceleration = 0f;
        direction = 'f';
        currentSpeed = speed;
        CarInstance.SharedInstance.maxSpeed = maxSpeed;
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        if (IsGrounded())
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
                Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime * currentAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotationRight);
                if (!(Input.GetKey("w") || Input.GetKey("s")))
                    decellerate();
            }

            if (Input.GetKey("a"))
            {
                Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime * currentAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotationLeft);
                if (!(Input.GetKey("w") || Input.GetKey("s")))
                    decellerate();
            }
        }
        if (!Input.anyKey || !IsGrounded())
        {
            decellerate();
        }

        CarInstance.SharedInstance.speed = currentSpeed * currentAcceleration;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.3f);
    }

    void accelerate()
    {
        if (direction == 'f' || currentAcceleration == 0)
        {
            if (currentAcceleration < 1)
                currentAcceleration += acceleration;
            transform.Translate(forward * currentSpeed * Time.deltaTime * currentAcceleration);
            direction = 'f';
        }
        else
        {
            decellerate();
        }
    }

    void reverse()
    {
        if (direction == 'b' || currentAcceleration == 0)
        {
            if (currentAcceleration < 1)
                currentAcceleration += acceleration;
            transform.Translate(backward * currentSpeed * Time.deltaTime * currentAcceleration);
            direction = 'b';
        }
        else
        {
            decellerate();
        }
    }

    void decellerate()
    {
        if (currentAcceleration > 0)
            currentAcceleration -= acceleration;
        else if (currentAcceleration != 0)
            currentAcceleration = 0f;
        transform.Translate(((direction == 'f') ? forward : backward) * currentSpeed * Time.deltaTime * currentAcceleration);
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "HalfPointTrigger" && other.gameObject.name != "LapCompleteTrigger")
        {
            other.gameObject.SetActive(false);

            if (other.tag == "Debuff")
            {
                currentSpeed = minSpeed;

                yield return new WaitForSeconds(5);

                currentSpeed = speed;
            }
            else if (other.tag == "Powerup")
            {
                currentSpeed = maxSpeed;

                yield return new WaitForSeconds(5);

                currentSpeed = speed;
            }
            else if (other.tag == "Time")
            {
                LapTimeManager.SecondCount -= 5;

                yield return new WaitForSeconds(5);
            }

            other.gameObject.SetActive(true);
        }
    }
}



//car singleton
public class CarInstance
{
    private static CarInstance instance = null;

    public static CarInstance SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new CarInstance();
            }
            return instance;
        }
    }

    public float speed;
    public float maxSpeed;
}
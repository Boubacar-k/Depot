using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControll : MonoBehaviour
{
    public Rigidbody rb;
    float up_down_axis, forward_backward_axis, right_left_axis;
    float forward_backward_angle = 0, right_left_angle=0;
        [SerializeField]
    float speed=1.3f, angle=25;
    bool isOnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controlls();
        transform.localEulerAngles = Vector3.back * right_left_angle + Vector3.right * forward_backward_angle;
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(right_left_axis,up_down_axis,forward_backward_axis);
    }

    void Controlls()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            up_down_axis = 10 * speed;
            isOnGround = false;
        }

        else if (Input.GetKey(KeyCode.E))
        {
            up_down_axis = 8;
        }

        else
        {
            up_down_axis = 9.81f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, angle, Time.deltaTime);
            forward_backward_axis = speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, -angle, Time.deltaTime);
            forward_backward_axis = -speed;
        }

        else
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, 0, Time.deltaTime);
            forward_backward_axis = 0;
        }


        if (Input.GetKey(KeyCode.D))
        {
            right_left_angle = Mathf.Lerp(right_left_angle, angle, Time.deltaTime);
            right_left_axis = speed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            right_left_angle = Mathf.Lerp(right_left_angle, -angle, Time.deltaTime);
            right_left_axis = -speed;
        }

        else
        {
            right_left_angle = Mathf.Lerp(right_left_angle, 0, Time.deltaTime);
            right_left_axis = 0;
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, angle, Time.deltaTime);
            right_left_angle = Mathf.Lerp(right_left_angle, angle, Time.deltaTime);
            forward_backward_axis = 0.5f* speed;
            right_left_axis = 0.5f * speed;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, angle, Time.deltaTime);
            right_left_angle = Mathf.Lerp(right_left_angle, -angle, Time.deltaTime);
            forward_backward_axis = 0.5f * speed;
            right_left_axis = -0.5f * speed;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, -angle, Time.deltaTime);
            right_left_angle = Mathf.Lerp(right_left_angle, angle, Time.deltaTime);
            forward_backward_axis = -0.5f * speed;
            right_left_axis = 0.5f * speed;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            forward_backward_angle = Mathf.Lerp(forward_backward_angle, -angle, Time.deltaTime);
            right_left_angle = Mathf.Lerp(right_left_angle, -angle, Time.deltaTime);
            forward_backward_axis = -0.5f * speed;
            right_left_axis = -0.5f * speed;
        }
    }

    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;
        }
    }
}

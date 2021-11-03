using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float velocity = 2.0f;
    float rotationSpeed = 0.5f;

    Rigidbody m_Rb;
    public static Movement s_Instance;
    public static Movement Instance{
        get{
            return s_Instance;
        }
    }

    private void Awake() {
        s_Instance = this;
    }
    void Start()
    {
        m_Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0 ||
            Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0)
        {
            velocity= 8.0f;
        }else{
            velocity = 2.0f;
        }
        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = transform.TransformDirection(movement); // changing it to slef space
        movement.Normalize(); // movement speed will be same in every direction even digonally

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                180 * Time.fixedDeltaTime);

        // rb.postion is currentPosition
        m_Rb.MovePosition(m_Rb.position + movement * velocity * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
        // transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0), Space.Self);


    }
}

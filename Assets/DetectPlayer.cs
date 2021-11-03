using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Transform player;
    Rigidbody m_Rigidbody;
    LineRenderer lineRenderer;

    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
        lineRenderer = this.GetComponent<LineRenderer>();
        player = Movement.Instance.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= 10f)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {

                Debug.DrawRay(transform.position, direction, Color.red);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                // Debug.Log("Angle " + angle);

                // transform.eulerAngles = Vector3.up * (angle -20);
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                DetectedRay(direction);
            }
        }
    }

    void DetectedRay(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast( transform.position,direction, out hit, 100f))
        {
            //100f raycast distance
            // Debug.DrawRay(Camera.main.transform.position,hit.point,Color.green,5f);
            Vector3 lineReaderPosition = transform.position;
            // lineReaderPosition.y = 1.5f;
            lineRenderer.SetPosition(0, lineReaderPosition);
            hit.point = new Vector3(hit.point.x ,1.7f,hit.point.z);
            lineRenderer.SetPosition(1, hit.point );
            Debug.Log("Object Name : "+ hit.collider.gameObject.name + "Object Position : "+hit.point);
            if (hit.rigidbody != null)
            {
                // hit.rigidbody.AddForce(100f,200f,0f);
                // Debug.Log(hit.point - lineReaderPosition);
                Debug.Log(hit.rigidbody.gameObject.name);
                hit.rigidbody.AddForce(new Vector3(0f,0f,-4.5f)); 
                //hit.point - lineReaderPosition direction in which force will apply
                Debug.Log("force");
            }
        }
    }
}

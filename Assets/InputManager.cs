
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer lineRenderer;
    PlayerWeapon playerWeapon;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerWeapon = Movement.Instance.GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                10f));

            Vector3 direction = worldMousePosition - Camera.main.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                //100f raycast distance
                // Debug.DrawRay(Camera.main.transform.position,hit.point,Color.green,5f);
                Vector3 lineReaderPosition = Movement.Instance.transform.position;
                lineReaderPosition.y = 1.5f;
                // lineRenderer.SetPosition(0, lineReaderPosition);
                // lineRenderer.SetPosition(1, hit.point);
                playerWeapon.Fire(lineReaderPosition , hit.point - lineReaderPosition); /// position from player + height
                
                // Invoke("ResetLineRenderer", 0.005f);
            }
        }

        if (Input.GetMouseButtonUp(0)){
            Invoke("ResetLineRenderer", 0.1f);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                10f));

            Vector3 direction = worldMousePosition - Camera.main.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                //100f raycast distance
                // Debug.DrawRay(Camera.main.transform.position,hit.point,Color.green,5f);
                Vector3 lineReaderPosition = Movement.Instance.transform.position;
                lineReaderPosition.y = 1.5f;
                lineRenderer.SetPosition(0, lineReaderPosition);
                lineRenderer.SetPosition(1, hit.point);

                if (hit.rigidbody != null)
                {
                    // hit.rigidbody.AddForce(100f,200f,0f);
                    // Debug.Log(hit.point - lineReaderPosition);
                    hit.rigidbody.AddForce((hit.point - lineReaderPosition) * 100);
                    //hit.point - lineReaderPosition direction in which force will apply
                }

                Invoke("ResetLineRenderer", 0.3f);
            }
            else
            {
                Debug.DrawRay(Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
                // lineRenderer.SetPosition(0,Camera.main.transform.position);
                // lineRenderer.SetPosition(1,worldMousePosition);
            }
        }


    }

    void ResetLineRenderer()
    {
        lineRenderer.positionCount = 0;
        lineRenderer.positionCount = 2;
    }

}

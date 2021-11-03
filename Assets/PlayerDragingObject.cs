using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragingObject : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void OnMouseDrag() {
        // this.transform.position= Camera.main.ScreenToWorldPoint(
        //     new Vector3(Input.mousePosition.x,Input.mousePosition.y, 20f)
        //     );
    }
}

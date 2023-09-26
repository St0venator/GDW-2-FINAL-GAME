using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class mousePos : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mask))
        {
            transform.position = hit.point;
        }

        //Vector3 currNode = findClosestNode();
    }
}

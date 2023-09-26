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

        Vector3 currNode = findClosestNode();
    }

    public Vector3 findClosestNode()
    {
        //Resetting our conditions for finding the closest node, making the distance something impossibly high so that the first node in the list is automatically the closest, so we always select a node
        Vector3 closestObj = new Vector3(0, 0, 0);
        float smallestDistance = 99999;

        //Looping through every node close enough to the player, stored in a singleton node manager
        foreach (Vector3 node in nodeManager.instance.availableNodes)
        {
            if (node != null)
            {

                //Distance to the current node we're checking
                float currDist = Vector3.Distance(transform.position, node);

                //If this distance is the smallest, set it's corresponding node to the closest node
                if (currDist < smallestDistance)
                {
                    smallestDistance = currDist;
                    closestObj = node;
                }
            }
        }

        //Setting the closest node as the active node in nodeManager
        nodeManager.instance.currNode = closestObj;

        //Returning the current node, not necessary but I thought it prudent, in case we need to reference it within this script later
        return closestObj;
    }
}

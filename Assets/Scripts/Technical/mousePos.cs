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

        GameObject currNode = findClosestNode();
    }

    GameObject findClosestNode()
    {

        //Resetting our conditions for finding the closest node, making the distance something impossibly high so that the first node in the list is automatically the closest, so we always select a node
        GameObject closestObj = null;
        float smallestDistance = 99999;

        //Looping through every node close enough to the player, stored in a singleton node manager
        foreach (GameObject node in nodeManager.instance.availableNodes)
        {
            if (node != null)
            {
                //Un-highlighting every node
                node.GetComponent<nodeController>().isClicked = false;

                //Distance to the current node we're checking
                float currDist = Vector3.Distance(transform.position, node.transform.position);

                //If this distance is the smallest, set it's corresponding node to the closest node
                if (currDist < smallestDistance)
                {
                    smallestDistance = currDist;
                    closestObj = node;
                }
            }
        }

        //Making sure we have a node to operate on
        if (closestObj != null)
        {
            //highlighting the closest node
            closestObj.GetComponent<nodeController>().isClicked = true;

            //Setting the closest node as the active node in nodeManager
            nodeManager.instance.currNode = closestObj;
        }

        //Returning the current node, not necessary but I thought it prudent, in case we need to reference it within this script later
        return closestObj;
    }
}

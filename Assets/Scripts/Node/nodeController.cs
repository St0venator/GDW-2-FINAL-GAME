using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeController : MonoBehaviour
{
    /*
    //nodeType enums, JiC
    //public enum nodeType {Basic, Booster}
    //public nodeType thisType;
    //private bool canBoost = true;

    //References
    GameObject playerRef;
    playerController playerScript;
    Material mat;
    //public GameObject connectingNode = null;

    //Checking if it's the active node
    [HideInInspector] public bool isClicked;
    
    //Maybe deprecated??
    //public bool isFallNode = false;

    // Start is called before the first frame update
    void Start()
    {
        //Reference variables, I want to move away from using public variables for convenience, use the GetComponent and GameObject methods whenever possible, it's just better coding
        playerRef = GameObject.FindWithTag("Player");
        playerScript = playerRef.GetComponent<playerController>(); 
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //All this can be moved to a function called in the player's "Climb" coroutine if performance becomes an issue, but cannot move to fixedUpdate or it's own Coroutine, for fear of latency

        //If a node is close enough to the player (10 units) add it to the list of available nodes, and color it blue
        // && Vector3.Distance(transform.position, playerRef.transform.position) > playerScript.upLimit
        if (Vector3.Distance(transform.position, playerRef.transform.position) < 10)
        {
            //TODO: Parameterize the 10 Units thing in the player controller
            if(!nodeManager.instance.availableNodes.Contains(gameObject))
            {
                nodeManager.instance.availableNodes.Add(gameObject);
            }
            mat.color = Color.blue;
        }

        //If it's not close enough, removing it from the list of available nodes, and color it red
        else
        {
            if (nodeManager.instance.availableNodes.Contains(gameObject))
            {
                nodeManager.instance.availableNodes.Remove(gameObject);
            }
            mat.color = Color.red;
        }

        //If this node is the selected node, lighten it's color a little
        if(isClicked)
        {
            mat.color = new Color(mat.color.r + 0.25f, mat.color.g + 0.25f, mat.color.b + 0.25f);
        }

        
        //Using different behaviors based on the type of the node
        //CURRENTLY NOT IN USE, COME BACK LATER
        /*
        switch(thisType)
        {
            //Currently no special behavior for basic nodes
            case nodeType.Basic:
                break;

            //Calling the player's "climb" coroutine, targeting this Node's "connectingNode" GameObject variable
            case nodeType.Booster: 
                
                //Activating the "climb" coroutine if the player is on the node
                if(Vector3.Distance(playerRef.transform.position, transform.position) <= 1 && canBoost)
                {
                    canBoost = false;
                    playerScript.StopAllCoroutines();
                    playerScript.StartCoroutine(playerScript.climb(connectingNode.transform.position, 0.05f));
                }
                break;
        }
        */
    }

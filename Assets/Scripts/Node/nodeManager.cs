using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class nodeManager : MonoBehaviour
{
    public static nodeManager instance;

    //A list of all valid nodes, that the cursor can select and the player can climb to
    public List<Vector3> availableNodes = new List<Vector3>();
    public List<Vector3> fallNodes = new List<Vector3>();
    public List<Vector3> allNodes;
    GameObject playerRef;

    //The node the cursor is currently selecting
    public Vector3 currNode;
    public Vector3 fallNode;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        instance = this;
        //allNodes = GameObject.FindGameObjectWithTag("Wall").GetComponent<nodeGenerator>().clippedNodes.ToList();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        updateNodes();
    }

    Vector3[] generateChunks(int subDivisionNum, Mesh targetObj)
    {
        Vector3[] chunks = new Vector3[subDivisionNum];
        float objBounds = targetObj.bounds.size.x;

        float interval = (objBounds / subDivisionNum) - (objBounds / subDivisionNum * 2);

        for(int i = 0; i < subDivisionNum; i++)
        {
            for(int j = 0; j < subDivisionNum; j++)
            {
                //chunks[i + j] = 
            }
        }
        return chunks;
    }

    public void updateNodes()
    {
        foreach (Vector3 node in allNodes)
        {
            if (Vector3.Distance(playerRef.transform.position, node) < 20)
            {
                availableNodes.Add(node);
            }
            
            else if(availableNodes.Contains(node))
            {
                availableNodes.Remove(node);
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeManager : MonoBehaviour
{
    public static nodeManager instance;

    //A list of all valid nodes, that the cursor can select and the player can climb to
    public List<GameObject> availableNodes = new List<GameObject>();
    public List<GameObject> fallNodes = new List<GameObject>();

    //The node the cursor is currently selecting
    public GameObject currNode;
    public GameObject fallNode;

    private void Start()
    {
        instance = this; 
    
    }
}

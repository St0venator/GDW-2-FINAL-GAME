using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToNearest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = nodeManager.instance.currNode;
    }
}

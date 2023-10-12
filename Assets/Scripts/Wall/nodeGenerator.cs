/*
 * Biiiiiiiiig todo, turn this into an editor script so we can use it to create scenes
 * Biiiiiiiiigger todo, kill myself, then make a geometry/vertex shader to GPU instance the nodes
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class nodeGenerator : MonoBehaviour
{
    Vector3[] objectVerts;
    Vector3[] nodes;
    public Vector3[] clippedNodes;
    // Start is called before the first frame update
    void Start()
    {
        objectVerts = GetComponent<MeshFilter>().mesh.vertices;
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();

        nodes = new Vector3[objectVerts.Length];

        int i = 0;

        //Generating a random offset for our perlin noise
        float offSet = Random.Range(0.0f, 10.0f);

        foreach (Vector3 vert in objectVerts)
        {
            //converting the object-space vertex positions to world space
            Vector3 newVert = transform.TransformPoint(vert);

            //Generating perlin noise based on the worldspace coords plus a small random offset to produce random results
            //Mathf.Perlin(X + Z, Y), might change
            float rand = Mathf.PerlinNoise(((newVert.x + newVert.z) + offSet) / 2, newVert.y + offSet);

            if(rand >= 0.5f)
            {
                //append the new node to the list of nodes
                nodes[i] = newVert;
                i++;
            }
            
        }

        clippedNodes = new Vector3[i + 1];

        clippedNodes = nodes[0..(clippedNodes.Length - 1)];
        nodeManager.instance.allNodes = clippedNodes.ToList();
        nodeManager.instance.updateNodes();
    }
}

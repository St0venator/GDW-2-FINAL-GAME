/*
 * Biiiiiiiiig todo, turn this into an editor script so we can use it to create scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeGenerator : MonoBehaviour
{
    Vector3[] objectVerts;
    public GameObject nodeRef;
    // Start is called before the first frame update
    void Start()
    {
        objectVerts = GetComponent<MeshFilter>().mesh.vertices;
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();

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
                //Instantiate the worldspace node if it passes the noise map
                Instantiate(nodeRef, newVert, Quaternion.identity);
            }
            
        }
    }
}

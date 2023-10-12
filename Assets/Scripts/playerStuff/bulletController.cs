using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public Vector2 velocity;
    LayerMask wallLayer;
    Rigidbody rb;
    SphereCollider sc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
        wallLayer = 6;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;

        Ray zRay = new Ray(transform.position, new Vector3(0, 0, 1));

        Debug.DrawRay(transform.position, new Vector3(0, 0, 999));

        if(Physics.Raycast(zRay, out RaycastHit zHit, float.MaxValue, wallLayer))
        {
            sc.center = zHit.point;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.transform.parent != null)
        {
            if (other.gameObject.transform.parent.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
    }
}

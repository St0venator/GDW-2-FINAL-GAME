using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.transform.parent != null)
        {
            if (other.gameObject.transform.parent.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
    }
}

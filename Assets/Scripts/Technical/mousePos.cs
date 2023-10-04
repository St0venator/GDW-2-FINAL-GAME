using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class mousePos : MonoBehaviour
{
    Camera cam;
    float zComponent = 0;
    public LayerMask mask;
    public float range;
    GameObject playerRef;
    Vector3 playerPos;
    Vector2 localHitPoint;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        playerPos = playerRef.transform.position;
        cam = Camera.main;
        localHitPoint = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerRef.transform.position;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mask))
        {
            localHitPoint = hit.point;

            Ray zRay = new Ray(new Vector3(localHitPoint.x, localHitPoint.y), new Vector3(0, 0, 1));

            if (Physics.Raycast(zRay, out RaycastHit zHit, float.MaxValue, mask))
            {
                temp = new Vector3(localHitPoint.x, localHitPoint.y, zHit.point.z);
            }   
        }

        transform.position = temp;
        
    }

    Vector3 clampPos(Vector3 startPos, int r)
    {
        Vector2 newPlayerPos = (Vector2)playerPos;
        Vector2 newMousePos = (Vector2)startPos;

        Vector2 newPos = (newMousePos - newPlayerPos);

        newPos = newPos.normalized * r;

        Vector3 pos = new Vector3(newPos.x, newPos.y, startPos.z);

        Debug.DrawRay(newPlayerPos, pos);

        return pos;
    }
}

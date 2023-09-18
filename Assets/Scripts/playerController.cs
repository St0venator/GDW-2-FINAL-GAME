using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //The animation curves the player follows when they jump from one node to another
    [SerializeField] private AnimationCurve climbCurve;
    [SerializeField] private AnimationCurve fallCurve;

    //The speed the player jumps up to another node
    [SerializeField] private float climbSpeed;

    //The height a node needs to be above the player to be considered valid
    public float upLimit;

    //References
    Rigidbody rb;
    [SerializeField] Transform wallRef;
    Transform yAxisTarget;

    // Start is called before the first frame update
    void Start()
    {
        yAxisTarget = wallRef;
        rb = GetComponent<Rigidbody>();
        climbSpeed /= 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //Facing the player towards the center of the mountain, along the Y-axis at the center
        transform.LookAt(new Vector3(yAxisTarget.position.x, transform.position.y, yAxisTarget.position.z));


        //If the player hits Left Shift, stop all current climb coroutines, and start a new one targeting the node the cursor is selecting
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            StopAllCoroutines();

            //If the current node is above the player, climbing
            if(nodeManager.instance.currNode.transform.position.y >= transform.position.y)
            {
                StartCoroutine(climb(nodeManager.instance.currNode.transform.position, climbSpeed));
            }
            //Otherwise, fall
            else
            {
                StartCoroutine(fall(nodeManager.instance.currNode.transform.position, climbSpeed));
            }
            
        }
    }

    public IEnumerator climb(Vector3 dest, float speed)
    {
        /*
         * dest  - The transform.position of the node we're climbing to
         * speed - The amount we move along the x-axis of our animation curve each loop of the coroutine
         * 
         * climb: Moves the player from one node to another by LERPing, sampling an animation curve
        */

        //Resetting all of our variables, starting the animation curve at -0.1, and our starting position as our current position
        float pos = 0.0f;
        Vector3 startPos = transform.position;

        //Keeping the player in front of the wall, from the camera's POV by moving the player slightly closer to the camera
        dest = Vector3.MoveTowards(dest, Camera.main.transform.position, 0.1f);

        //Calculating the midpoint between the current and target nodes, and them moving it away from the camera
        Vector3 midPoint = (dest + startPos) / 2;
        midPoint -= Vector3.MoveTowards(midPoint, Camera.main.transform.position, 3.14f) - midPoint;

        //Getting our modified coordinates for our SLERP
        Vector3 newStart = startPos - midPoint;
        Vector3 newDest = dest - midPoint;

        //LERPing towards "dest" until we reach the end of our animation curve
        while(pos <= 1.5f)
        {

            //Moving n% of the way between our start and end positions, with n being the y-value of our animation curve at x = "pos"
            transform.position = Vector3.Slerp(newStart, newDest, climbCurve.Evaluate(pos / 0.3f)) + midPoint;
            pos = Mathf.MoveTowards(pos, 1.0f, speed * Time.deltaTime);

            yield return null;
        }
    }

    public IEnumerator fall(Vector3 dest, float speed)
    {
        /*
         * dest  - The transform.position of the node we're climbing to
         * speed - The amount we move along the x-axis of our animation curve each loop of the coroutine
         * 
         * fall: Moves the player from one node to another by LERPing, sampling an animation curve
        */

        //Resetting all of our variables, starting the animation curve at -0.1, and our starting position as our current position
        float pos = 0.0f;
        Vector3 startPos = transform.position;

        //Keeping the player in front of the wall, from the camera's POV by moving the player slightly closer to the camera
        dest = Vector3.MoveTowards(dest, Camera.main.transform.position, 0.1f);

        //Calculating the midpoint between the current and target nodes, and them moving it away from the camera
        Vector3 midPoint = (dest + startPos) / 2;
        midPoint -= Vector3.MoveTowards(midPoint, Camera.main.transform.position, 3.14f) - midPoint;

        //Getting our modified coordinates for our SLERP
        Vector3 newStart = startPos - midPoint;
        Vector3 newDest = dest - midPoint;

        //LERPing towards "dest" until we reach x = 1.1 on our animation curve
        while (pos <= 1.5f)
        {

            //Moving n% of the way between our start and end positions, with n being the y-value of our animation curve at x = "pos"
            transform.position = Vector3.Slerp(newStart, newDest, fallCurve.Evaluate(pos / 0.3f)) + midPoint;
            pos = Mathf.MoveTowards(pos, 1.0f, speed * Time.deltaTime);

            yield return null;
        }

    }
}

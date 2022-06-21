using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bevegelse : MonoBehaviour
{
    //For testing:
    private bool idle = true;

    //Variables
    private bool walking = false;

    private bool lookAround = false;

    private int turnSpeed = 100;

    private int walkSpeed = 2;

    private int runSpeed = 5;

    private Vector3 randomCoordinate;

    private Quaternion direction;
    
    private Animator walkingAnim;

    private Transform head;

    private float nyPositionTimer;

    private float analyseTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Walking animation
        walkingAnim = gameObject.GetComponent<Animator>();
        walkingAnim.Play("WalkAnimStart");

        //Start koordinat
        randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

        //Hode
        head = gameObject.transform.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        //Timers
        nyPositionTimer += Time.deltaTime;

        analyseTimer += Time.deltaTime;

        //Idle animation:
        if(idle == true)
        {
            //Idle walk
            transform.position += transform.forward * Time.deltaTime * walkSpeed;

            //Idle rotation
            direction = Quaternion.LookRotation(randomCoordinate - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed * Time. deltaTime);

            //Posisjon endring
            if (nyPositionTimer > 8f && idle == true)
            {
                randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

                nyPositionTimer = 0f;
            }
        }

        //Looks around for obstacle
        if(lookAround == true)
        {
            walkingAnim.Play("New State");
            transform.Rotate(new Vector3(0,1,0) * Time.deltaTime, Space.Self);
        }

        //Walks towards target
        if(lookAround == true)
        {
            walkingAnim.Play("WalkAnimStart");
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
        }
    }

    public void AnalyseSurroundings()
    {
        //Turn of idle animation
        idle = false;

        lookAround = true;

        walking = false;
    }

    public void WalkTowardsX()
    {
        //Turn of idle animation
        idle = false;

        lookAround = false;

        walking = true;
    }
}

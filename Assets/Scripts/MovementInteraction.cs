using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInteraction : MonoBehaviour
{
    //For testing:
    private bool idleMovement = true;

    //Variables
    private bool moving = false;

    private static bool searchForTarget = false;

    private int turnTime = 100;

    private int walkSpeed = 2;

    private int runSpeed = 5;

    private Vector3 randomCoordinate;

    private Quaternion direction;
    
    private Animator walkingAnim;

    private float nyPositionTimer;

    private float analyseTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Walking animation
        walkingAnim = gameObject.GetComponent<Animator>();

        //Start koordinat
        randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));
    }

    // Update is called once per frame
    void Update()
    {
        //Timers
        nyPositionTimer += Time.deltaTime;

        analyseTimer += Time.deltaTime;

        //Test function
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AnalyzeSurroundings(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AnalyzeSurroundings(false);
        }

        //Idle animation for testing:
        if (idleMovement == true)
        {
            //Idle walk
            transform.position += transform.forward * Time.deltaTime * walkSpeed;

            //Idle rotation
            direction = Quaternion.LookRotation(randomCoordinate - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, 100 * Time. deltaTime);

            //Posisjon endring
            if (nyPositionTimer > 8f && idleMovement == true)
            {
                randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

                nyPositionTimer = 0f;
            }

            moving = true;
        }
        else
        {
            moving = false;
        }

        //Walking Animation (yes or no)
        if (moving == true)
        {
            walkingAnim.Play("WalkAnimStart");
        }
        else
        {
            walkingAnim.Play("StandStill");
        }

        //Look around until target found
        if (searchForTarget == true)
        {
            transform.RotateAround(transform.position, Vector3.up, 359 * Time.deltaTime / turnTime);
        }
    }

    //Eat Food
    public void Eat()
    {
        
    }

    //Go to sleep
    public void Sleep()
    {
        idleMovement = false;

        //Lie down 
        transform.Rotate(-90.0f, 0.0f, 90.0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
    }

    //Go to sleep
    public void WakeUp()
    {

    }

    //Recieves a target to approach
    public void WalkTowards()
    {

    }

    //Look arounds
    public void AnalyzeSurroundings(bool targetNotFound)
    {
        if (targetNotFound == true)
        {
            searchForTarget = true;
        }
        else 
        {
            searchForTarget = false;
        }
    }

    //Attack target
    public void AttackTarget()
    {

    }

    //Get away from target
    public void EscapeTarget()
    {

    }
}

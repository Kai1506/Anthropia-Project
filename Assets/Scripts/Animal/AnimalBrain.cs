using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBrain : MonoBehaviour
{
    //Variables
    private bool idle = true;

    private bool move = true;

    private int moveSpeed = 3;

    private Vector3 targetCoordinate;

    private Quaternion direction;

    private bool walkAnim = false;

    private static bool searchForTarget = false;

    private int turnTime = 100;
    
    private Animator animalAnim;

    private float nyPositionTimer;

    private float analyseTimer;

    //AnimalSenses class
    AnimalSenses animalSensesClass; 


    // Start is called before the first frame update
    void Start()
    {
        //Walking animation
        animalAnim = gameObject.GetComponent<Animator>();

        //Start koordinat og rotasjon
        targetCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

        //Finds AnimalSenses
        animalSensesClass = gameObject.GetComponent<AnimalSenses>();
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
            Sleep();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StopSleeping();
        }

        //Walk towards something
        if (move == true)
        {
            //Walk forwards
            transform.position += transform.forward * Time.deltaTime * moveSpeed;

            //Rotate towards location
            direction = Quaternion.LookRotation(targetCoordinate - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, 100 * Time. deltaTime);

            //Find new locations in area to walk towards
            if (idle == true && nyPositionTimer > 8f)
            {
                targetCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

                nyPositionTimer = 0f;
            }
        }

        //Walking Animation (yes or no)
        if (move == true && walkAnim == false)
        {
            animalAnim.Play("WalkAnimStart");
            walkAnim = true;
        }
        else if (move == false)
        {
            animalAnim.Play("StandStill");
            walkAnim = false;
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
        //Stop
        move = false;
    }

    public void StopEating()
    {       

    }
    
    //Go to sleep
    public void Sleep()
    {
        //Stop
        move = false;

        //Lie down 
        transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
    }

    public void StopSleeping()
    {
        //Stand up
        move = true;
        
        transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
    }

    //Recieves a target to approach, with speed 1-5
    public void MoveTowardsTarget(bool move_, int moveSpeed_, Vector3 targetCoordinate_)
    {
        move = move_;

        moveSpeed = moveSpeed_;

        targetCoordinate = targetCoordinate_;

        idle = false;
    }

    public void StopMovingTowardsTarget()
    {
        animalAnim.Play("StandStill");
    }   

    //Get away from target
    public void EscapeTarget(bool move_, int moveSpeed_, Vector3 targetCoordinate_)
    {
        move = move_;

        moveSpeed = moveSpeed_;

        targetCoordinate = -targetCoordinate_;
    }

    public void StopEscapingTarget()
    {
        animalAnim.Play("StandStill");
    }

    //Look arounds
    public void AnalyzeSurroundings(bool searchForTarget_)
    {
        searchForTarget = searchForTarget_;
    }

    //Attack target
    public void AttackTarget()
    {
        //Stop
        move = false;

        animalAnim.Play("AttackAnim");
    }

    public void StopAttackingTarget()
    {
        animalAnim.Play("StandStill");
    }
}


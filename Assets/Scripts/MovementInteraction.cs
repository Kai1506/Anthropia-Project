using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInteraction : MonoBehaviour
{
    //testing:
    private bool idle = true;

    //Variables
    private bool move = true;

    private int moveSpeed = 3;

    private Vector3 targetCoordinate;

    private bool walkAnim = false;

    private static bool searchForTarget = false;

    private int turnTime = 100;

    private Vector3 randomCoordinate;

    private Quaternion direction;
    
    private Animator humanoidAnim;

    private float nyPositionTimer;

    private float analyseTimer;

    //core and sense class

    Core coreClass; 

    Senses sensesClass; 


    // Start is called before the first frame update
    void Start()
    {
        //Walking animation
        humanoidAnim = gameObject.GetComponent<Animator>();

        //Start koordinat
        randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

        //Finner Core og Senses
        coreClass = gameObject.GetComponent<Core>();
        sensesClass = gameObject.GetComponent<Senses>();
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

            //Rotate towards coordinate
            direction = Quaternion.LookRotation(targetCoordinate - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, 100 * Time. deltaTime);

            //Idle Posisjon endring *
            if (idle == true && nyPositionTimer > 8f)
            {
                targetCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

                nyPositionTimer = 0f;
            }
        }

        //Walking Animation (yes or no)
        if (move == true && walkAnim == false)
        {
            humanoidAnim.Play("WalkAnimStart");
            walkAnim = true;
        }
        else if (move == false)
        {
            humanoidAnim.Play("StandStill");
            walkAnim = false;
        }

        //Look around until target found
        if (searchForTarget == true)
        {
            transform.RotateAround(transform.position, Vector3.up, 359 * Time.deltaTime / turnTime);
        }

        //Hvis avgjørelsen å sove blir tatt, velger den å sove

        /*
        if(sensesClass.GetIsSleeping() == true && coreClass.GetFirstTimeSleeping() == true)
        {
            Sleep();
            coreCore.SetFirsTimeSleeping(false); 
            coreCore.SetFirsTimeAwake(true); 
        }
        else if (sensesClass.GetIsSleeping() == false && coreCore.GetFirstTimeAwake() == true)
        {
            WakeUp();
            coreCore.SetFirsTimeAwake(false); 
            coreCore.SetFirsTimeSleeping(true); 
        }
        */
        /*
        if(sensesClass.GetIsEating() == true && coreClass.GetFirstTimeEating() == true)
        {
            Eat();
            coreCore.SetFirsTimeEating(false); 
            coreCore.SetFirsTimeNotEating(true); 
        }
        else if (sensesClass.GetIsEating() == false && coreCore.GetFirstTimeNotEating() == true)
        {
            StopEating();
            coreCore.SetFirsTimeNotEating(false); 
            coreCore.SetFirsTimeEating(true); 
        }
        */
        /*
        if(sensesClass.GetIsSocializing() == true && coreClass.GetFirstTimeSocialise() == true)
        {
            Socialise();
            coreCore.SetFirsTimeSocialise(false); 
            coreCore.SetFirsTimeNotSocialise(true); 
        }
        else if (sensesClass.GetIsSocializing() == false && coreCore.GetFirstTimeNotSocialise() == true)
        {
            StopSocialise();
            coreCore.SetFirsTimeNotSocialise(false); 
            coreCore.SetFirsTimeSocialise(true); 
        }
        */
    }

    //Eat Food
    public void Eat()
    {
        //Stop
        move = false;

        humanoidAnim.Play("EatingAnim");
    }

    public void StopEating()
    {
        humanoidAnim.Play("StandStill");
    }
    
    //Go to sleep
    public void Sleep()
    {
        //Stop
        move = false;

        //Lie down 
        transform.Rotate(-90.0f, 0.0f, 90.0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
    }

    public void StopSleeping()
    {
        //Stand up
        transform.Rotate(90.0f, 0.0f, -90.0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
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
        humanoidAnim.Play("StandStill");
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

        humanoidAnim.Play("AttackAnim");
    }

    public void StopAttackingTarget()
    {
        humanoidAnim.Play("StandStill");
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
        humanoidAnim.Play("StandStill");
    }

    //Socialize
    public void Socialize()
    {
        //Stop
        move = false;

        humanoidAnim.Play("TalkAnim");
    }

    public void StopSocializing()
    {
        humanoidAnim.Play("StandStill");
    }

    public void Socialise()
    {

    }

    public void StopSocialise()
    {

    }
}

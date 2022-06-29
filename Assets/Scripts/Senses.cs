using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    //Senere: gjore om vektoren til en funksjon som dekker et omrade foran
    private Core coreClass;

    private static LayerMask bear;

    private static LayerMask obstacle;

    private Vector3 eyesightDirection;

    private float warningTimer;

    private bool foundTarget;

    private string requestedTarget;

    private bool sleeping;

    private bool eating;

    private bool socializing;

    private bool procreating;

    private bool attacking;

    private int damageTaken = 30;

    // Start is called before the first frame update
    void Start()
    {
        //Check for raycast target
        bear = LayerMask.GetMask("Bear");
        
        obstacle = LayerMask.GetMask("Obstacle");

        //Finding core
        coreClass = gameObject.GetComponent<Core>();
    }

    void Update()
    {
        //Eyesight direction
        eyesightDirection = transform.TransformDirection(Vector3.forward);

        // If raycast has spotted x
        if (Physics.Raycast(transform.position, eyesightDirection, 100, bear))
        {
            SeesSomething(bear);
        }
        if(Physics.Raycast(transform.position, eyesightDirection, 100, obstacle))
        {
            SeesSomething(obstacle);
        }
    }

    //Sleeping
    public void IsSleeping(bool sleeping_)
    {
        sleeping = sleeping_;
    }
    public bool GetIsSleeping() 
    { 
        return sleeping; 
    }

    //Eating
    public void IsEating(bool eating_)
    {
        eating = eating_;
    }
    public bool GetIsEating() 
    { 
        return eating; 
    }

    //Socializing
    public void IsSocializing(bool socializing_)
    {
        socializing = socializing_;
    }
    public bool GetIsSocializing() 
    { 
        return socializing; 
    }

    //Procreating
    public void IsProcreating(bool procreating_)
    {
        procreating = procreating_;
    }
    public bool GetIsProcreating() 
    { 
        return procreating; 
    }

    //Attacking
    public void IsAttacking(bool attacking_)
    {
        attacking = attacking_;
    }
    public bool GetIsAttacking() 
    { 
        return attacking; 
    }

    //Hearing radius
    public bool GetOnTriggerEnter(Collider sound)
    {
        //Gets collider
        SphereCollider hearingCollider = transform.GetComponent<SphereCollider>();

        //If sleeping shrink radius
        if (sleeping == true)
        {
            hearingCollider.radius = 3f; 
        }
        //If awake, normal radius
        else
        {
            hearingCollider.radius = 15f;  //Change to 20 after testing
        }

        //Hearing
        if (sound.tag == "Animal" || sound.tag == "Humanoid")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Sees something and determines what it is
    public string SeesSomething(LayerMask something)
    {
        //Sees bear
        return something.ToString();
        
        /*if (something == bear)
        {
            //Tell brain to calculate bear-scenario
            return something.ToString();
        }

        //Sees obstacle
        else if (something == obstacle)
        {
            //Tell brain to calculate obstacle-scenario
            
        }

        if (something.ToString() == requestedTarget)
        {
            //Tell brain that target is spotted
            return true; 
        }*/
    }

    //Find target requested by core
    public void SearchAfterTarget(string target)
    {
        requestedTarget = target;
    }

    //Has taken damage, tells brain how much
    public int GetDamageTakejn()
    {
        return damageTaken;
    }
}

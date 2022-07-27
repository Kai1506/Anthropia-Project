using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    //Senere: gjore om raycast til en funksjon som dekker et omrade foran

    private int lineOfSight = 100000;

    private RaycastHit something;

    private Vector3 eyesightDirection;

    private float warningTimer;

    private bool sleeping;

    private bool eating;

    private bool socializing;

    private bool procreating;

    private bool attacking;

    //Variables for taking and dealing damage
    public static int damageTaken;

    public static int damageDealing;

    //Core class
    private Core coreClass;

    // Start is called before the first frame update
    void Start()
    {
        //Finds core
        coreClass = gameObject.GetComponent<Core>();
    }

    void Update()
    {
        //Eyesight direction
        eyesightDirection = transform.TransformDirection(Vector3.forward);

        Ray ray = new Ray(transform.position, transform.forward);;

        // If raycast has spotted x
        if (Physics.Raycast(ray, out something, lineOfSight)) 
        {
            ISeeSomething();
        }
    }

    //Sleeping
    public void SetIsSleeping(bool sleeping_)
    {
        sleeping = sleeping_;
    }
    public bool GetIsSleeping() 
    { 
        return sleeping; 
    }

    //Eating
    public void SetIsEating(bool eating_)
    {
        eating = eating_;
    }
    public bool GetIsEating() 
    { 
        return eating; 
    }

    //Socializing
    public void SetIsSocializing(bool socializing_)
    {
        socializing = socializing_;
    }
    public bool GetIsSocializing() 
    { 
        return socializing; 
    }

    //Procreating
    public void SetIsProcreating(bool procreating_)
    {
        procreating = procreating_;
    }
    public bool GetIsProcreating() 
    { 
        return procreating; 
    }

    //Attacking
    public void SetIsAttacking(bool attacking_)
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
    public void ISeeSomething()
    {
        //Sees something and alerts core
        coreClass.ObjectDetected(something.transform.gameObject.layer.ToString());
        
    }

    //Has taken damage, tells core amount taken
    public int GetDamageTaken()
    {
        return damageTaken;
    }

    //Metode for WakeUpEvent. Denne metoden skal returnere true dersom noe vekker humanoiden mens den sover
    public bool WakeUpEvent()
    {
        return false; 
    }
}

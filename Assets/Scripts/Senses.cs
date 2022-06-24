using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    //Senere: gjore om vektoren til en funksjon som dekker et omrade foran
    private static LayerMask bear;

    private static LayerMask obstacle;

    private Vector3 eyesightDirection;

    private float warningTimer;


    private bool foundTarget;

    // Start is called before the first frame update
    void Start()
    {
        //Check for raycast target
        bear = LayerMask.GetMask("Bear");
        
        obstacle = LayerMask.GetMask("Obstacle");
    }

    void Update()
    {
        //Eyesight direction
        eyesightDirection = transform.TransformDirection(Vector3.forward);

        // If raycast has spotted x
        if (Physics.Raycast(transform.position, eyesightDirection, 100,bear))
        {
            SeesSomething(bear);
        }
        if(Physics.Raycast(transform.position, eyesightDirection, 100, obstacle))
        {
            SeesSomething(obstacle);
        }
    }

    public void IsSleeping(bool asleep)
    {
        
    }

    //Spotted something and determined what it is
    public static void SeesSomething(LayerMask target)
    {
        //Sees bear
        if (target == bear)
        {
            //Tell brain to calculate bear-scenario
        }

        //Sees obstacle
        if (target == obstacle)
        {
            //Tell brain to calculate obstacle-scenario
        }
    }

    //Hearing radius
    void OnTriggerEnter(Collider sound)
    {
        //Hearing
        if(sound.tag == "Animal" || sound.tag == "Humanoid")
        {
            print("I hear something");
        }
    }

    void HasBeenHurt(bool hurt)
    {

    }

    void HasSocialized(bool socialized)
    {

    }

}

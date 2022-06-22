using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    //Senere: gjøre om vektoren til en funksjon som dekker et område foran
    private LayerMask bear;

    private LayerMask obstacle;

    private Vector3 eyesightDirection;

    private float warningTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Check for raycast target
        bear = LayerMask.GetMask("Bear");

        obstacle = LayerMask.GetMask("Obstacle");
    }

    void Update()
    {
        warningTimer += Time.deltaTime;


        //Eyesight
        eyesightDirection = transform.TransformDirection(Vector3.forward);

        // Check if raycast has spotted x
        if (Physics.Raycast(transform.position, eyesightDirection, 100, bear) && warningTimer > 2f)
        {
            print("I see bear");
            warningTimer = 0f;
        }
        if(Physics.Raycast(transform.position, eyesightDirection, 100, obstacle) && warningTimer > 2f)
        {
            print("I see obstacle");
            warningTimer = 0f;
        }
    }

    //Hearing radius
    private void OnTriggerEnter(Collider sound)
    {
        //Hearing
        if(sound.tag == "Animal" || sound.tag == "Humanoid")
        {
            print("I hear something");
        }
    }
}

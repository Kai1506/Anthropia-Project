using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    //Senere: gjøre om vektoren til en funksjon som dekker et område foran
    private LayerMask bear;

    private LayerMask obstacle;

    private Vector3 eyesightDirection;

    private Bevegelse bevegelse;

    // Start is called before the first frame update
    void Start()
    {
        // Check for a Wall.
        bear = LayerMask.GetMask("Bear");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        eyesightDirection = transform.TransformDirection(Vector3.forward);

        // Check if a Wall is hit.
        if (Physics.Raycast(transform.position, eyesightDirection, 100, bear) )
        {
            print("I see bear");
            bevegelse.AnalyseSurroundings();
        }
        if(Physics.Raycast(transform.position, eyesightDirection, 100, obstacle))
        {
            bevegelse.WalkTowardsX();
        }

        
    }
}

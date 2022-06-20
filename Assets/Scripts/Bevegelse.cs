using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bevegelse : MonoBehaviour
{
    private int turnSpeed = 100;

    private int walkSpeed = 2;

    private int runSpeed = 5;

    private Vector3 randomCoordinate;

    private Quaternion direction;
    
    private Animator walking;

    private Transform head;

    private float nyPositionTimer;

    private float analyseTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Walking animtion
        walking = gameObject.GetComponent<Animator>();
        walking.Play("WalkAnimStart");

        //Start koordinat
        randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

        //Head
        head = gameObject.transform.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        //Timers
        nyPositionTimer += Time.deltaTime;

        analyseTimer += Time.deltaTime;

        //Spasering
        if(true)
        {
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
        }

        //Rotering
        direction = Quaternion.LookRotation(randomCoordinate - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed * Time. deltaTime);

        //Posisjon endring
        if (nyPositionTimer > 8f)
        {
            randomCoordinate = new Vector3(Random.Range(-45,46), 3, Random.Range(-45,46));

            nyPositionTimer = 0f;
        }
        
    }
}

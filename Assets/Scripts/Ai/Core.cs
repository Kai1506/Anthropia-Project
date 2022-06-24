using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    //Variables
    //Timers
    float deathTimer; 
    float timeToDie = 110; 
    float tiredTimer; 
    float tiredCap; 
    float hungryTimer; 
    float hungryCap; 

    //The object
    public Humanoid HumanoidInfo; 
    private bool iWasBorn; 

    // Update is called once per frame
    void Update()
    {
        //Min sikre Start()
        if(iWasBorn == true)
        {
            //Første ord
            print("I've been born");

            //Sette caps
            tiredCap = HumanoidInfo.FormUtholdenhetMental; //Gjør dette mer nyansert senere
            hungryCap = HumanoidInfo.FormUtholdenhetFysisk; //Gjør dette mer nyansert senere

            //Avslutter sikre Start()
            iWasBorn = false; 
        }

        //Background activities
        TimeIsTicking(); 
        HungerRegulator();
        SleepRegulator();
        DeathIsWaiting();
    }

    //Kjører klokkene som går i bakgrunnen
    private void TimeIsTicking()
    {
        deathTimer += Time.deltaTime;
        tiredTimer += Time.deltaTime; 
        hungryTimer += Time.deltaTime; 
    }

    //Gjør at han sakte men sikkert blir mer og mer sulten, senere legge til muligheten for påfyll
    private void HungerRegulator()
    {
        if(hungryTimer > hungryCap)
        {
            HumanoidInfo.HelseMetthetsverdi -= 10;

            if(HumanoidInfo.HelseMetthetsverdi < 0)
            {
                HumanoidInfo.HelseMetthetsverdi = 0; 
            }
        }

        hungryTimer = 0; 
    }

    // Gjør at han sakte men sikkert blir mer og mer trøtt, senere legge til muligheten for påfyll
    private void SleepRegulator()
    {
        if(tiredTimer > tiredCap)
        {
            HumanoidInfo.HelseUthviltsverdi -= 10;

            if(HumanoidInfo.HelseUthviltsverdi < 0)
            {
                HumanoidInfo.HelseUthviltsverdi = 0; 
            }
        }

        tiredTimer = 0; 
    }

    //Dreper personen
    private void DeathIsWaiting()
    {
        if(deathTimer > timeToDie)
        {
            HumanoidInfo.Fallet = true; 
        }
    }

        //Getters and setters
    public void SetBeenBorn(bool input)
    {
        iWasBorn = input; 
    }
}



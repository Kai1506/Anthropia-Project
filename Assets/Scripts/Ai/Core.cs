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
    private bool firstTimeSleep = true; 
    private bool firstTimeAwake = true; 
    float hungryTimer; 
    float hungryCap; 

    //The object
    public Humanoid HumanoidInfo; 
    private bool iWasBorn; 

    //Beslutninger
    private Beslutninger beslutningerClasse; 
    private Senses sensesClass; 

    void Start()
    {
        beslutningerClasse = new Beslutninger();

        //Henter Senses
        sensesClass = gameObject.GetComponent<Senses>();

    }

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
        /*
            if(sensesClass.GetIsSleeping == false)
            {
                ShouldISleep();               
            }
        */
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
        // om våken 
        if(tiredTimer > tiredCap && sensesClass.GetIsSleeping() == false)
        {
            HumanoidInfo.HelseUthviltsverdi -= 10;

            if(HumanoidInfo.HelseUthviltsverdi < 0)
            {
                HumanoidInfo.HelseUthviltsverdi = 0; 
            }
        }
 
        //Om sover
        if(tiredTimer > Mathf.FloorToInt(tiredCap/3) && sensesClass.GetIsSleeping() == true)
        {
            HumanoidInfo.HelseUthviltsverdi += 10;

            if(HumanoidInfo.HelseUthviltsverdi > 100)
            {
                HumanoidInfo.HelseUthviltsverdi = 100;
                sensesClass.IsSleeping(false);
            }

            /* WakeUpEvent
            if(sensesClass.WakeUpEvent == true)
            {
                senseClass.IsSleeping(false);
            }
            */
        }

        tiredTimer = 0;
    }

    public void ShouldISleep()
    {
        /*
        if(sensesClass.IsEating() == false && sensesClass.IsAttacking() == false && sensesClass.IsSocialising() == false && sensesClass.IsProcreating() == false)
        {
            sensesClass.IsSleeping(beslutningerClasse.ChoosesToSleep(HumanoidInfo.HelseUthviltsverdi, HumanoidInfo.HelseMetthetsverdi);)
        }
        */
       sensesClass.IsSleeping(false);
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

    public bool GetFirstTimeAwake()
    {
        return firstTimeAwake;
    }
        public bool GetFirstTimeSleeping()
    {
        return firstTimeSleep;
    }

    public void SetFirstTimeAwake(bool inp)
    {
        firstTimeAwake = inp;
    }
        public void SetFirstTimeSleeping(bool inp)
    {
        firstTimeSleep = inp;
    }

    //Denne skal gi informasjon til senses om hva den skal lete etter
    public string GetTargetToSearchAfter()
    {

        //code more
        return "";
    }
    
}



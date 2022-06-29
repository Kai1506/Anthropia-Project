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
    private bool firstTimeAwake = false; 
    float hungryTimer; 
    float hungryCap; 
    private bool firstTimeEating = true;
    private bool firstTimeNotEating = false; 
    private bool firstTimeSocialise = true; 
    private bool firstTimeNotSocialise = false; 

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
        SocialiseRegulator();
        /*
            if(sensesClass.GetIsSleeping == false)
            {
                ShouldISleep();               
            }
        */
        /*
            if(sensesClass.GetIsEating == false)
            {
                ShouldIEat();               
            }
        */
        /*
            if(SensesClass.GetIsSocializing == false)
            {
                ShouldISocialise();
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

    //Metoder for å sosialisere
    public void shouldISoicialise(bool seenSomeone)
    {
        
        if(sensesClass.GetIsEating() == false && sensesClass.GetIsAttacking() == false && sensesClass.GetIsSleeping() == false && sensesClass.GetIsProcreating() == false)
        {
            sensesClass.IsSocializing(beslutningerClasse.ChoosesToSocialise(HumanoidInfo.Sosialt, seenSomeone));
        }
        
       sensesClass.IsSocializing(false);
    }


    //Gjør at han sakte men sikkert blir mer og mer sulten, senere legge til muligheten for påfyll
    private void HungerRegulator()
    {
        if(hungryTimer > hungryCap && sensesClass.GetIsEating() == false)
        {
            HumanoidInfo.HelseMetthetsverdi -= 10;

            if(HumanoidInfo.HelseMetthetsverdi < 0)
            {
                HumanoidInfo.HelseMetthetsverdi = 0; 
            }
        }

        if(hungryTimer > Mathf.FloorToInt(hungryCap/5) && sensesClass.GetIsEating() == false)
        {
            HumanoidInfo.HelseMetthetsverdi += 20; 

            if(HumanoidInfo.HelseMetthetsverdi > 100)
            {
                HumanoidInfo.HelseMetthetsverdi = 100; 
                sensesClass.IsEating(false);
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

            // WakeUpEvent
            if(sensesClass.WakeUpEvent() == true)
            {
                sensesClass.IsSleeping(false);
            }
        }

        tiredTimer = 0;
    }


    public void SocialiseRegulator()
    {
        //not socializing
        /*
            if(something == true && sensesClass.GetIsSoializing == false)
            {
                sensesClass.IsSocializing(true);
            }
        */

        //socializing
        /*
            if(something == true && sensesClass.GetIsSoializing == true)
            {
                sensesClass.IsSocializing(false);
            }

        */
        
    }

    public void ShouldISleep()
    {
        /*
        if(sensesClass.GetIsEating() == false && sensesClass.GetIsAttacking() == false && sensesClass.GetIsSocialising() == false && sensesClass.GetIsProcreating() == false)
        {
            sensesClass.IsSleeping(beslutningerClasse.ChoosesToSleep(HumanoidInfo.HelseUthviltsverdi, HumanoidInfo.HelseMetthetsverdi));
        }
        */
       sensesClass.IsSleeping(false);
    }

    //Metoder tilknyttet spising
    public void ShouldIEat()
    {
        /*
        if(sensesClass.GetIsSleeping() == false && sensesClass.GetIsAttacking() == false && sensesClass.GetIsProcreating() == false && sensesClass.GetIsSleeping() == false)
        {
            sensesClass.IsEating(beslutningerClasse.VelgerHumanoidSpise(HumanoidInfo.HelseMetthetsverdi, HumanoidInfo.HelseSykdom));
        }
        */
        sensesClass.IsEating(false);

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

        public bool GetFirstTimeEating()
    {
        return firstTimeEating;
    }
        public bool GetFirstTimeNotEating()
    {
        return firstTimeNotEating;
    }

    public void SetFirstTimeEating(bool inp)
    {
        firstTimeEating = inp;
    }
    public void SetFirstTimeNotEating(bool inp)
    {
        firstTimeNotEating = inp;
    }

    public bool GetFirstTimeSocialise()
    {
        return firstTimeSocialise;
    }
        public bool GetFirstTimeNotSocialise()
    {
        return firstTimeNotSocialise;
    }

    public void SetFirstTimeSocialise(bool inp)
    {
        firstTimeSocialise = inp;
    }
    public void SetFirstTimeNotSocialise(bool inp)
    {
        firstTimeNotSocialise = inp;
    }
   
    //Denne skal gi informasjon til senses om hva den skal lete etter
    public string GetTargetToSearchAfter()
    {

        //code more
        return "";
    }
    
}



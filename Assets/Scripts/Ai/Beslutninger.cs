using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beslutninger
{
    //Metoder for aa ta beslutninger basert paa egenskaper
    public bool AngriperHumanoidDyret(int intelligensGunstighet, int formStyrke, int helseUthviltverdi, int helseSult, int helseSykdom)
    {
        //Deklarerer virtuelle variabler
        float helseIndikator;
        float angripSjanseIntelligens;
        float tvil = Random.Range(0, 101)*Mathf.Sqrt(1-formStyrke/100);

        //Setter verdier for de viruelle variablene
        helseIndikator = (helseUthviltverdi + helseSult + helseSykdom)/3;
        if(helseUthviltverdi < 20 || helseSult < 20 || helseSykdom < 20)    
        {
            helseIndikator = helseIndikator/2; 
        }
        angripSjanseIntelligens = Random.Range(Mathf.Floor(intelligensGunstighet*intelligensGunstighet/100), intelligensGunstighet);

        //Kjorer tester for aa teste hva som skjer
        if(helseIndikator > 80)
        {
            //Gunstig aa angripe
            if(angripSjanseIntelligens >= tvil)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(helseIndikator > 50)
        {
            //Middel gunstig aa angripe
            if(formStyrke > 70)
            {
                //Gunstig aa angripe
                if(angripSjanseIntelligens >= tvil)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //Ikke gunstig aa angripe
                if(angripSjanseIntelligens >= tvil)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        else if(helseIndikator > 25)
        {
            //Ikke lurt aa angripe
            if(angripSjanseIntelligens >= tvil)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            //Helse saa lav at man automatisk velger aa flykte
            return false; 
        }
    }

    public bool VelgerHumanoidSpise(int helseSult, int helseSykdom)
    {
        if(helseSult < 30)
        {
            return true; 
        }
        else if (helseSult < 50)
        {
            if(helseSykdom < 60)
            {
                return true; 
            }
            else
            {
                float chance = Random.Range(0, 101);
                if(chance < 50)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

    //Returnerer en bool som sier om denne personen har lyst til aa sosialisere eller ikke med en annen person
    public bool ChoosesToSocialise(int sosialt, bool seenSomeone)
    {
        if(seenSomeone == true)
        {
            int randint = Random.Range(0, 101);

            if(sosialt > 70)
            {
                return true; 
            }
            else if(sosialt > 40)
            {
                if(randint > 50)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public bool ChoosesToSleep(int helseUthviltverdi, int helseSult)
    {
        int randint = Random.Range(0, 101);

        if(helseUthviltverdi < 40 && helseSult > 60)
        {
            return true;
        }
        else if (helseUthviltverdi < 40)
        {
            if(randint > 35)
            {
                return true;
            }
        }

        return false;
    }


    //Gir bool om denne personen vil ha sex med en annen person. For at det skal skje maa begge personer gi boolean = true
    public bool TriesToProcreate(int attractiveness, int helseSykdom, int sosialt)
    {
        int randint = Random.Range(0, 101);
        int randint2 = Random.Range(0, 101);
        bool attractivenessCheck = false; 

        if(attractiveness > 70)
        {
            attractivenessCheck = true; 
        }
        else if(attractiveness > 40)
        {
            if(randint2 > 50)
            {
                attractivenessCheck = true;
            }
        }

        if(attractivenessCheck == true)
        {
            if(helseSykdom > 60)
            {
                if(sosialt > 60)
                {
                    if(randint > 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if(sosialt > 40)
                {
                    if(randint > 60)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    } 

                }
                else
                {
                    return false; 
                }
            }
            else if(helseSykdom > 40)
            {
                if(sosialt > 60)
                {
                    if(randint > 50)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if(sosialt > 40)
                {
                    if(randint > 70)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    } 

                }
                else
                {
                    return false; 
                }                
            }
            else
            {
                return false;
            }

        }

        return false;
    }
    
    public Beslutninger()
    {
        
    }

}

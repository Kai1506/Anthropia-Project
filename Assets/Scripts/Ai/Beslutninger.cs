using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beslutninger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid
{
    //Properties
    public int Hurtighet {get; set;}
    public int IntelligensHurtighet { get; set; }
    public int IntelligensGunstighet { get; set; }
    public int FormStyrke { get; set; }
    public int FormUtholdenFysisk { get; set; }
    public int FormUtholdenhetMental { get; set; }
    public int Sosialt { get; set; }
    public int HelseUthviltsverdi { get; set; }
    public int HelseMetthetsverdi { get; set; }
    public int HelseSykdom { get; set; }
    public bool Do {get; set;}

    //Methods
    public void Jakte()
    {
        debug.Log("Hunt");
    }
    public void Angripe()
    {
        debug.Log("Attack");
    }
    public void Spise()
    {
        debug.Log("eat");
    }
    public void Hvile()
    {
        debug.Log("rest");
    }
    public void Sosialisere()
    {
        debug.Log("Socialise");
    }
    public void Prokreere()
    {
        debug.Log("procreate");
    }
    public void Do()
    {
        debug.Log("die");
    }
    public void BliFodt()
    {
        debug.Log("be born");
    }

    //Constructors
    public Humanoid(int hurtighet, int intelligensHurtighet, int intelligensGunstighet, int formStyrke, int formUtholdenhetFysisk, int formUtholdenhetMental, int sosialt)
    {
        //Setter helse verdiene til 100 ved fodsel
        Do = false; 
        HelseUthviltsverdi = 100; 
        HelseMetthetsverdi = 100; 
        HelseSykdom = 100; 




    }


}
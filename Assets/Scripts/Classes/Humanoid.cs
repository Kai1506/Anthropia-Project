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
    public int FormUtholdenhetFysisk { get; set; }
    public int FormUtholdenhetMental { get; set; }
    public int Sosialt { get; set; }
    public int Attractiveness { get; set; }
    public int HelseUthviltsverdi { get; set; }
    public int HelseMetthetsverdi { get; set; }
    public int HelseSykdom { get; set; }
    public int Id { get; set; }
    public bool Fallet {get; set;}

    //Methods
    public void Jakte()
    {
        Debug.Log("Hunt");
    }
    public void Angripe()
    {
        Debug.Log("Attack");
    }
    public void Spise()
    {
        Debug.Log("eat");
    }
    public void Hvile()
    {
        Debug.Log("rest");
    }
    public void Sosialisere()
    {
        Debug.Log("Socialise");
    }
    public void Prokreere()
    {
        Debug.Log("procreate");
    }
    public void AvslutteLivet()
    {
        Debug.Log("die");
    }
    public void BliFodt()
    {
        Debug.Log("be born");
    }

    //Constructors
    public Humanoid(int hurtighet, int intelligensHurtighet, int intelligensGunstighet, int formStyrke, int formUtholdenhetFysisk, int formUtholdenhetMental, int sosialt, int attractiveness, int id)
    {
        //Kjoorer BliFodt metode
        BliFodt();

        //Setter helse verdiene til 100 ved fodsel
        Fallet = false; 
        HelseUthviltsverdi = 100; 
        HelseMetthetsverdi = 100; 
        HelseSykdom = 100; 

        //Setter egenskapene til inputverdiene
        Hurtighet = hurtighet; 
        IntelligensHurtighet = intelligensHurtighet;
        IntelligensGunstighet = intelligensGunstighet;
        FormStyrke = formStyrke;
        FormUtholdenhetFysisk = formUtholdenhetFysisk;
        FormUtholdenhetMental = formUtholdenhetMental;
        Sosialt = sosialt; 
        Attractiveness = attractiveness;
        Id = id;

    }

}
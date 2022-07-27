using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    //Properties
    public int Redsel {get; set;}
    public int Styrke {get; set;}
    public int Storrelse {get; set;}

    //Methods
    public void Flykte()
    {
        Debug.Log("Flight");
    }
    public void Slaass()
    {
        Debug.Log("Slaass");
    }
    public void BliFodtDyr()
    {
        Debug.Log("BliFodt");
    }
    public void AvsluttDyreLiv()
    {
        Debug.Log("die");
    }

    //Constructor
    public Animal(int redsel, int styrke, int storrelse)
    {
        //Kjører BliFodtDyr metode
        BliFodtDyr();

        //Setter egenskapene lik inputet
        Redsel = redsel; 
        Styrke = styrke; 
        Storrelse = storrelse; 


    }

}

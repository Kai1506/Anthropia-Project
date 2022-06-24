using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidManager : MonoBehaviour
{
    //Variables
    //Lists
    private List<Humanoid> masterListObjects = new List<Humanoid>();
    private List<GameObject> masterListGameObjects = new List<GameObject>();

    [SerializeField]
    private GameObject HumanoidPrefab; 

    //SpawningCoordinates
    private float xMax = 46; 
    private float xMin = -45; 
    private float zMax = 46; 
    private float zMin = -45; 

    //Other Variables
    private int numberInGenerationOne = 3; 

    // Start is called before the first frame update
    void Start()
    {
        //Lager genereasjon 1
        for (int i = 0; i < numberInGenerationOne; i++)
        {
            InstantiateFirstGenerationHumanoid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //lager ny humanoid basert på prokreasjon mellom foreldre


    }


    //Methods
    //Metode for å skape de første humanoidene i starten av simulasjonen
    private void InstantiateFirstGenerationHumanoid()
    {
        Vector3 newPosition = new Vector3(Random.Range(xMin, xMax), 3, Random.Range(zMin, zMax));
        Quaternion newRotation = new Quaternion(1, 0, 0, 0);

        GameObject newHumanoid = Instantiate(HumanoidPrefab, newPosition, newRotation);
        Core coreScript = newHumanoid.GetComponent<Core>();

        coreScript.HumanoidInfo = new Humanoid(RandomAttribute(), RandomAttribute(), RandomAttribute(), RandomAttribute(), RandomAttribute(), RandomAttribute(), RandomAttribute(), RandomAttribute());
        coreScript.SetBeenBorn(true);

        masterListGameObjects.Add(newHumanoid);
        masterListObjects.Add(coreScript.HumanoidInfo);
    }

    //Metode for å lage en ny humanoid basert på at forelde velger å prokreere. Usikker på om parameterene skal være Gameobjects eller Humanoids
    private void InstantiateChildHumanoid(GameObject parent1, GameObject parent2)
    {
        GameObject newHumanoid = Instantiate(HumanoidPrefab, parent1.transform);
        Core coreScript = newHumanoid.GetComponent<Core>();

        int indexForParent1 = 0; 
        int indexForParent2 = 0;
        for (int i = 0; i < masterListGameObjects.Count; i++)
        {
            if(masterListGameObjects[i]== parent1)
            {
                indexForParent1 = i; 
            }
            if(masterListGameObjects[i]== parent2)
            {
                indexForParent2 = i; 
            }
        }

        coreScript.HumanoidInfo = new Humanoid(MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].Hurtighet, masterListObjects[indexForParent2].Hurtighet),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].IntelligensHurtighet, masterListObjects[indexForParent2].IntelligensHurtighet),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].IntelligensGunstighet, masterListObjects[indexForParent2].IntelligensGunstighet),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].FormStyrke, masterListObjects[indexForParent2].FormStyrke),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].FormUtholdenhetFysisk, masterListObjects[indexForParent2].FormUtholdenhetFysisk),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].FormUtholdenhetMental, masterListObjects[indexForParent2].FormUtholdenhetMental),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].Sosialt, masterListObjects[indexForParent2].Sosialt),
            MakeNewQualityBasedOnParents(masterListObjects[indexForParent1].Attractiveness, masterListObjects[indexForParent2].Attractiveness));
        coreScript.SetBeenBorn(true);

        masterListGameObjects.Add(newHumanoid);
        masterListObjects.Add(coreScript.HumanoidInfo);

    }

    //Metode for å gi tilfeldig egenskapsverdi
    private int RandomAttribute()
    {
        int randint = Random.Range(0, 101);

        if(randint > 20 && randint < 80)
        {
            return Random.Range(21, 81);
        }
        else if (randint >= 80)
        {
            return Random.Range(81, 101);
        }
        else
        {
             return Random.Range(0, 21);
        }
    }

    //Metode for å velge egenskapene til en child basert på egenskapene til foreldrene

    private int MakeNewQualityBasedOnParents(int qualityParent1, int qualityParent2)
    {

        int newQuality = Mathf.FloorToInt((qualityParent1 + qualityParent2)/2 + Random.Range(0, Mathf.FloorToInt((qualityParent1 - qualityParent2)/2))*Mathf.Pow(-1, Random.Range(1, 3)));

        //Sjekker grensetilfellene hvor variasjonen eventuelt har tatt egenskapsverdien ute av bounds
        if(newQuality > 100)
        {
            newQuality = 100; 
        }
        if(newQuality < 0)
        {
            newQuality = 0; 
        }

        return newQuality;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDebrisRed : MonoBehaviour
{
    private InteractableObject interactable;
    private string sciName, classification, composition;
    private float density, weight;
    private double resistivity;
    
    private int key;
    private void Awake() 
    {
        sciName = "Metallic asteroid";
        classification = "M-type asteroid";
        composition = "Made from what appears to be a mixture of nickel and iron. Formed close to a star forcing basaltic lava to the surface";
        density = 6.0f; // unit is kg/m^3
        resistivity = 8.4e-8;
        weight = 6000.0f; // unit is kg
        key = 2;
        gameObject.GetComponent<InteractableObject>().GiveExposedVariables
                                                    (sciName, classification,
                                                    composition, density, 
                                                    resistivity, weight, key);
    }
}

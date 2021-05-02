using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDebrisBlue : MonoBehaviour
{
    private InteractableObject interactable;
    private string sciName, classification, composition;
    private float density, weight;
    private double resistivity;
    
    private int key;
    private void Awake() 
    {
        sciName = "F-type asteroid";
        classification = "B-type subclassification";
        composition = "Made up of mostly carbon, lacks any H2O";
        density = 2.0f; // unit is kg/m^3
        resistivity = 1.0e-5;
        weight = 4000.0f; // unit is kg
        key = 1;
        gameObject.GetComponent<InteractableObject>().GiveExposedVariables
                                                    (sciName, classification,
                                                    composition, density, 
                                                    resistivity, weight, key);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebris2 : MonoBehaviour
{

    private InteractableObject interactable;
    private string sciName, classification, composition;
    private float density, weight;
    private double resistivity;
    private int key;
    
    private void Awake() 
    {
        sciName = "Another Space Rock";
        classification = "I like this one, not worthless";
        composition = "10% luck 20% skill 15% concentrated power of will 5% pleasuer 50% pain 100% reason to remember the name";
        density = 7.0f; // unit is kg/m^3
        resistivity = 1.8e-4;
        weight = 20f; // unit is kg
        key = 1;

        gameObject.GetComponent<InteractableObject>().GiveExposedVariables
                                                    (sciName, classification,
                                                    composition, density, 
                                                    resistivity, weight, key);
    }
    
}
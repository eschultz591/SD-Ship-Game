using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebris : MonoBehaviour
{

    private InteractableObject interactable;
    private string sciName, classification, composition;
    private float density, weight;
    private double resistivity;
    
    private int key;
    private void Awake() 
    {
        sciName = "Space Rock";
        classification = "some worthless space rock that no one cares about";
        composition = "1% evil 99% hot gas";
        density = 2.0f; // unit is kg/m^3
        resistivity = 1.69e-18;
        weight = 1.5f; // unit is kg
        key = 2;
        gameObject.GetComponent<InteractableObject>().GiveExposedVariables
                                                    (sciName, classification,
                                                    composition, density, 
                                                    resistivity, weight, key);
    }
    
}

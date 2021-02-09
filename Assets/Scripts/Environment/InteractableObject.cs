using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // object exposes specific variables that are needed to people who intereact with them

    // stats for what an object might need to expose 
    // use sciName over name since Object.name exists
    private string _sciName;
    private string _classification;
    private string _composition;
    private float _weight;
    private double _resistivity;
    private float _density;


    private void Start() 
    {
        
    }


    public void GiveExposedVariables(string sciName, string classification, string composition, float weight, double resistivity, float density)
    {
        _sciName = sciName;
        _classification = classification;
        _composition = composition;
        _weight = weight;
        _resistivity = resistivity;
        _density = density;

    }


    public string GetName()
    {
        return _sciName;
    }
    


}

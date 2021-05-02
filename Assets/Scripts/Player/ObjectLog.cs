using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectLog : MonoBehaviour
{

    // this script is a log for objects you have scanned
    // once an object is scanned it is stored here
    // the log only stores data that is shared between all of its types
    // so not weight


    // all separated into their own list, with the name being the Key used to look up
    // other elements. Finde name in list go to that index in the other lists
    private List<string> names;
    private List<string> classifications;
    private List<string> compositions;
    private List<float> densities;
    private List<double> resistivities;
    public List<int> keys;


    public TextMeshProUGUI ui_text;
    private bool display_log = false;


    private bool has_goal;
    private List<object> returnList;

    private void Awake() 
    {
        names = new List<string>();
        classifications = new List<string>();
        compositions = new List<string>();
        densities = new List<float>();
        resistivities = new List<double>();
        keys = new List<int>();
        has_goal = false;
    }

    private void Update()
    {
        if(!display_log)
        {
            ui_text.gameObject.SetActive(false);
        }
        else
        {
            ui_text.gameObject.SetActive(true);
        }
    }
    public void AddObject(string name, string classification, string composition, float density, double resistivity, int key)
    {
            names.Add(name);
            classifications.Add(classification);
            compositions.Add(composition);
            densities.Add(density);
            resistivities.Add(resistivity);
            keys.Add(key);

            string entry = "Inventory key: " + key + " name: " + name + "\n";
            ui_text.text += entry;
    }

    public List<object> FindLogObject(string name)
    {
        int index = names.IndexOf(name);
        // if in list
        if(index != -1)
        {
            string classification = classifications[index];
            string composition = compositions[index];
            float density = densities[index];
            double resistivity = resistivities[index];
            int key = keys[index];

            returnList = new List<object>(5);
            returnList.Add(name);
            returnList.Add(classification);
            returnList.Add(composition);
            returnList.Add(density);
            returnList.Add(resistivity);
            returnList.Add(key);

            return returnList;
        }
        // if not in list, we will have a gui error message as of now just Debug.log


        return null;
    }

    // find log by key
    public List<object> FindLogObject(int target_key)
    {
        int index = keys.IndexOf(target_key);
        // if in list
        if(index != -1)
        {
            string classification = classifications[index];
            string composition = compositions[index];
            float density = densities[index];
            double resistivity = resistivities[index];
            int key = keys[index];

            returnList = new List<object>(5);
            returnList.Add(target_key);
            returnList.Add(classification);
            returnList.Add(composition);
            returnList.Add(density);
            returnList.Add(resistivity);
            returnList.Add(key);

            return returnList;
        }
        // if not in list, we will have a gui error message as of now just Debug.log


        return null;
    }

    public void ToggleHasGoal()
    {
        has_goal = !has_goal;
    }
    
    public bool CheckGoalStatus()
    {
        return has_goal;

    }

    public void ShowLog()
    {
        display_log = !display_log;
    }

}

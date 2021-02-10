using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{

    private ObjectLog log;

    private void Awake() 
    {
        log = gameObject.GetComponent<ObjectLog>();
        
    }




    public void ScanObject()
    {
        Debug.Log("am scanning");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit ) && hit.transform.tag == "InteractibleDebris")
        {
            log.AddObject(hit.transform.GetComponent<InteractableObject>().GetName(),
                          hit.transform.GetComponent<InteractableObject>().GetClassification(),
                          hit.transform.GetComponent<InteractableObject>().GetComposition(),
                          hit.transform.GetComponent<InteractableObject>().GetDensity(),
                          hit.transform.GetComponent<InteractableObject>().GetResistivity());
        }
    }


    public void CheckLog()
    {

        RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit ) && hit.transform.tag == "InteractibleDebris")
            {
                List<object> testList = log.FindLogObject(hit.transform.GetComponent<InteractableObject>().GetName());
                Debug.Log("found it here is its composition" + testList[2]);
            }

    }
}

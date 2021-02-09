using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }




    public void ScanObject()
    {
        Debug.Log("am scanning");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit ) && hit.transform.tag == "InteractibleDebris")
        {
            Debug.Log("this is the name" + hit.transform.GetComponent<InteractableObject>().GetName());

        }
    }
}

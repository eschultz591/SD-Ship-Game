using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScannerScript : MonoBehaviour
{

    private ObjectLog log;
    public GameManager gm;

    public TextMeshProUGUI ui_text;

    private float text_timer = 2.0f;
    private float text_timer_cd = 0.0f;

    private bool scan_message_lock = false;
    private int scanned_key;

    // 0 = start the message loop
    // 1 = scanning....
    // 2 = name of the object
    // 3 = analysing...
    // 4 = if its the target or not 
    // 5 = done, do nothing until we go back to 0
    private int start_scan_message = 5;
    private void Awake() 
    {
        log = gameObject.GetComponent<ObjectLog>();
        text_timer_cd = 15.0f + Time.time;
    }




    public void ScanObject()
    {
        if (start_scan_message == 5)
        {

        
            Debug.Log("am scanning");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit ) && hit.transform.tag == "InteractibleDebris")
            {
                if (log.keys.Count > 0 && !log.keys.Contains(hit.transform.GetComponent<InteractableObject>().GetKey()) || log.keys.Count <= 0)
                {
                    log.AddObject(hit.transform.GetComponent<InteractableObject>().GetName(),
                                hit.transform.GetComponent<InteractableObject>().GetClassification(),
                                hit.transform.GetComponent<InteractableObject>().GetComposition(),
                                hit.transform.GetComponent<InteractableObject>().GetDensity(),
                                hit.transform.GetComponent<InteractableObject>().GetResistivity(),
                                hit.transform.GetComponent<InteractableObject>().GetKey());

                    int key = hit.transform.GetComponent<InteractableObject>().GetKey();
                    bool success = gm.CheckSuccess(key);
                    if(success)
                        log.ToggleHasGoal();
                    Destroy(hit.transform.gameObject);
                    scanned_key = key;
                    ui_text.gameObject.SetActive(true);
                    start_scan_message = 0;
                }
                else
                {
                    Debug.Log("sorry object is already in the list");
                    ui_text.text = "get a hold of yourself. This is already a part of your cargo!";
                    text_timer_cd = Time.time + text_timer;
                }

            }
        }
    }


    public void CheckLog()
    {
        log.ShowLog();
        /*RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit ) && hit.transform.tag == "InteractibleDebris")
            {
                List<object> testList = log.FindLogObject(hit.transform.GetComponent<InteractableObject>().GetName());
                Debug.Log("found it here is its composition" + testList[2]);

            }*/

    }


    private void Update()
    {

        if(start_scan_message == 0 && !scan_message_lock)
        {
            text_timer_cd = Time.time + text_timer;
            scan_message_lock = true;

            ui_text.text = "Asteroid collected!";
        }
        if(start_scan_message == 1 && !scan_message_lock)
        {
            text_timer_cd = Time.time + text_timer;
            scan_message_lock = true;

            ui_text.text = "scanning........";
        }
        if(start_scan_message == 2 && !scan_message_lock)
        {
            text_timer_cd = Time.time + text_timer + .5f;
            scan_message_lock = true;

            List<object> testList = log.FindLogObject(scanned_key);
            ui_text.text = "This is a "+ testList[1] + " asteroid";
        }
        if(start_scan_message == 3 && !scan_message_lock)
        {
            text_timer_cd = Time.time + text_timer;
            scan_message_lock = true;

            ui_text.text = "analysing.......";

        }

        if(start_scan_message == 4 && !scan_message_lock)
        {
            text_timer_cd = Time.time + text_timer + 1.3f;
            scan_message_lock = true;

            if(log.CheckGoalStatus())
            {
                ui_text.text = "Thats it come back to the ship now. Easy does it, the boss wants it back in one piece.";
            }
            else
            {
                ui_text.text = "Thats not the target. Don't want to waste company time so dont let that happen again";
            }
        }



        if (text_timer_cd < Time.time && start_scan_message >= 5)
            ui_text.gameObject.SetActive(false);
        
        if (text_timer_cd < Time.time && start_scan_message < 5)
        {
            scan_message_lock = false;
            start_scan_message++;
        }
    }

}

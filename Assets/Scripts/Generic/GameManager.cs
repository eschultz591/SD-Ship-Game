using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    // list of goal objects in the scene
    // will select a random one as the goal for this mission
    // after this, the game manager will give text to the player stating the goal object
    [SerializeField]
    private List<InteractableObject> goalObjects;  
    // set of hints to be given when game starts
    private string[,] hints;
    [SerializeField]
    private int goalKey;

    public TextMeshProUGUI ui_text;
    private bool need_to_talk = false;

    private float text_timer = 15.0f;
    private float text_timer_cd = 0.0f;
    void Start()
    {
        need_to_talk = true;
        //  goalObjects = new List<InteractableObject>();

        // pick goal object from list randomly 
        int selection = Random.Range(0, goalObjects.Count - 1);
        goalKey = goalObjects[selection].GetKey();
        hints = new string[2,2];
        // hints for goal object of key 1 which is GoalDebrisBlue
        hints[0,0] = "F-";
        hints[0,1] = "blue and mainly made of carbon";
        // hints for goal object of key 2 which is GoalDebrisRed
        hints[1,0] = "M-";
        hints[1,1] = "Metalic and in this world, they are red or silver due to volcanic activity at formation";
        
        ui_text.gameObject.SetActive(true);
        text_timer_cd = Time.time + text_timer;
        if(goalKey == 2)
        {
            ui_text.text = ("your goal is to find a " + hints[goalKey - 1, 0] + "type asteroid"  + ", these are generally "+ hints[goalKey - 1,1] + ". This object is very important to the higher ups, its worth well over 30 euros so make haste!" ); 

        }
        else
        {
            ui_text.text = ("your goal is to find a " + hints[goalKey - 1, 0] + "type asteroid"  + ", these are generally "+ hints[goalKey - 1,1] + ". these are somewhat common in this cluster, so it shouldnt take you long." ); 

        }

        Debug.Log("your goal is to find a " + hints[goalKey - 1, 0] + "type asteroid"  + ", these are generally "+ hints[goalKey - 1,1] );   

    }


    public bool CheckSuccess(int key)
    {
        if (key == goalKey)
        {
            Debug.Log("YOUGOTIT");
            return(true);
        }
        else
        {
            Debug.Log("Not it dummy");
            return(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text_timer_cd < Time.time && need_to_talk == true)
        {
            need_to_talk = false;
            ui_text.gameObject.SetActive(false);
        }
    }




    public void Restart()
    {
        SceneManager.LoadScene(0);

    }
}





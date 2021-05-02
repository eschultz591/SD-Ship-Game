using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneScript : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.tag =="Player")
        {
            if (col.gameObject.GetComponent<ObjectLog>().CheckGoalStatus() == true)
            {
                Debug.Log("YOU DID IT YOU WON");
                gameManager.Restart();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
}

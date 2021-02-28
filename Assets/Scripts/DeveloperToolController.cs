using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperToolController : MonoBehaviour
{
    public bool isNoClip = false;
    bool isInFuel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!isInFuel)
            {
                isInFuel = true;
                GameObject drill = GameObject.FindWithTag("Player");
                drill.GetComponent<DrillController>().fuelBleed = 0;
                drill.GetComponent<DrillController>().fuelAmount = 999;
                drill.GetComponent<DrillController>().obsFuelLoss = 0;
            } else
            {
                isInFuel = false;
                GameObject drill = GameObject.FindWithTag("Player");
                drill.GetComponent<DrillController>().fuelBleed = 5;
                drill.GetComponent<DrillController>().fuelAmount = 600;
                drill.GetComponent<DrillController>().obsFuelLoss = 50;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if(!isNoClip)
            {
                isNoClip = true;
                GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obs)
                {
                    obstacle.GetComponent<BoxCollider2D>().enabled = false;
                }

            } else
            {
                isNoClip = false;
                GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obs)
                {
                    obstacle.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        /*if(isNoClip)
        {
            GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject obstacle in obs) {
                obstacle.GetComponent<BoxCollider2D>().enabled = false;
            }
        }*/

    }
}

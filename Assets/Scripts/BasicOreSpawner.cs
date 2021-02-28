using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOreSpawner : MonoBehaviour
{
    public GameObject[] ores;
    public GameObject obstacle;
    public float spawnTimer;
    public float spawnTimerStart;
    public int goldChance;
    public int rubyChance;
    public int emeraldChance;
    public int diamondChance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            int remainingPostions = 6;
            bool[] positions = { false, false, false, false, false, false };
            int randNumObs = Random.Range(1,4);
            remainingPostions -= randNumObs;
            int randNumOres = Random.Range(0, remainingPostions+1);
            for (int i = 0; i < randNumOres; i++)
            {
                int randPos = Random.Range(0,6);
                while (positions[randPos])
                {
                    randPos = Random.Range(0, 6);
                }
                positions[randPos] = true;
                Instantiate(orePicker(), transform.position + new Vector3(-2.5f + (randPos * 1), 0, 0), Quaternion.identity);
            }
            for (int i = 0; i < randNumObs; i++)
            {
                int randPos = Random.Range(0, 6);
                while (positions[randPos])
                {
                    randPos = Random.Range(0, 6);
                }
                positions[randPos] = true;
                Instantiate(obstacle, transform.position + new Vector3(-2.5f + (randPos * 1), 0, 0), Quaternion.identity);
            }
            spawnTimer = spawnTimerStart;
        } else
        {
            spawnTimer -= Time.deltaTime;
        }
       
    }

    private GameObject orePicker()
    {
        int chanceTotal = goldChance + rubyChance + emeraldChance + diamondChance;
        int x = Random.Range(0, chanceTotal);
        if((x -= goldChance) < 0)
        {
            return ores[0];
        } else if ((x -= rubyChance) < 0)
        {
            return ores[1];
        } else if ((x -= emeraldChance) < 0)
        {
            return ores[2];
        } else
        {
            return ores[3];
        }
    }
}

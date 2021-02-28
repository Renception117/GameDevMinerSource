using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrillController : MonoBehaviour
{
    Vector2 newPos;
    public float speed;
    public float upperLim;
    public float lowerLim;
    public float fuelAmount;
    public float fuelBleed;
    public int obsFuelLoss;
    float curScore = 0;
    public Text score;
    public Text fuel;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: 0";
        fuel.text = "Fuel: " + fuelAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > lowerLim)
        {
            newPos = new Vector2(lowerLim, transform.position.y);

        } else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < upperLim)
        {
            newPos = new Vector2(upperLim, transform.position.y);
        } else
        {
            newPos = transform.position;
        }
        fuelAmount -= fuelBleed * Time.deltaTime;
        fuel.text = "Fuel: " + fuelAmount.ToString("F0");
        if (fuelAmount <= 0.0f)
        {
            SceneManager.LoadScene("StartMenu");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ore")
        {
            curScore += other.gameObject.GetComponent<OreController>().value;
            score.text = "Score: " + curScore.ToString();
        } else if (other.tag == "Obstacle")
        {
            fuelAmount -= obsFuelLoss;
        }
    }
}

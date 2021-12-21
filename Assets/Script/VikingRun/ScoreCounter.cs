using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    int score = 0;
    public void getCoin()
    {
        score++;
        transform.GetComponent<Text>().text = System.Convert.ToString(score);
    }
    public void getScore(GameObject e)
    {
        e.SendMessage("setScore", score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

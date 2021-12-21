using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Score").SendMessage("getScore", transform.gameObject);
        transform.GetComponent<Text>().text = System.Convert.ToString(score);
    }
    public void setScore(int value)
    {
        score = value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

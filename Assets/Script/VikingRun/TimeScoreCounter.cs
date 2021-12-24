using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScoreCounter : MonoBehaviour
{
    float totalTime = 0;
    Text text;
    bool isRun = false;
    public void start()
    {
        isRun = true;
    }
    public void end()
    {
        isRun = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            totalTime += Time.deltaTime;
            text.text = System.Convert.ToString(System.Math.Round(totalTime, 2));
        }
    }
}

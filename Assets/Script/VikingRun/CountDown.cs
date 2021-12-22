using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    int time = 3;
    float timeNow;
    // Start is called before the first frame update
    void Start()
    {
        timeNow = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = System.Convert.ToString(time - (int)(Time.time - timeNow));
        if (Time.time - timeNow > 3)
        {
            GameObject.Find("viking").SendMessage("startGame");
            Destroy(transform.parent.parent.gameObject);
        }
            
    }
}

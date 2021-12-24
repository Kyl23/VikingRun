using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Text>().text = GameObject.Find("TimeScore").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

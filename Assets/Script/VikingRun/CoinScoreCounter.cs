using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScoreCounter : MonoBehaviour
{
    int score = 0;
    AudioSource audio;
    public void getCoin()
    {
        audio.Play();
        score++;
        transform.GetComponent<Text>().text = System.Convert.ToString(score);
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

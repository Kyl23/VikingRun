using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        string name = collider.gameObject.name;
        if (name.Equals("Character1_Reference"))
        {
            GameObject.Find("CoinScore").SendMessage("getCoin");
            Destroy(transform.gameObject);
        }
    }
}

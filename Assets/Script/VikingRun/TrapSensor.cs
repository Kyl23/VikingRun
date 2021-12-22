using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSensor : MonoBehaviour
{
    public GameObject endUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        string name = collider.gameObject.name;
        if (name.Equals("fence_02") || name.Equals("stairs_02"))
        {
            Instantiate(endUI);
            GameObject.Find("viking").SendMessage("endGame");
        }

    }
}

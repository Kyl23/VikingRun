using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSensor : MonoBehaviour
{
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
            if(name.Equals("fence_02"))
                GameObject.Find("Character1_Reference").transform.rotation = Quaternion.Euler(90, 0, 0);
            else if(name.Equals("stairs_02"))
                GameObject.Find("Character1_Reference").transform.rotation = Quaternion.Euler(-90, 0, 0);
            GameObject.Find("viking").SendMessage("endGame");
        }
    }
}

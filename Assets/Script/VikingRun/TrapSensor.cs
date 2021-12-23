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
    public void flipToFront()
    {
        GameObject.Find("Character1_Reference").transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    public void flipToRear()
    {
        GameObject.Find("Character1_Reference").transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
    private void OnTriggerEnter(Collider collider)
    {
        string name = collider.gameObject.name;
        if (name.Equals("fence_02") || name.Equals("stairs_02"))
        {
            transform.GetComponent<AudioSource>().Play();
            if (name.Equals("fence_02"))
                flipToFront();
            else if (name.Equals("stairs_02"))
                flipToRear();
            GameObject.Find("Ghost").SendMessage("chased");
        }
        if (name.Equals("big_tree_01"))
        {
            GameObject.Find("Ghost").SendMessage("crash");
        }
    }
}

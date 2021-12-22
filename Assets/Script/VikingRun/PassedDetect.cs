using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Equals("Floor(Clone)"))
        {
            GameObject.Find("mapFactory").GetComponent<MapFactory>().SendMessage("recycleFloor");
        }
    }
}

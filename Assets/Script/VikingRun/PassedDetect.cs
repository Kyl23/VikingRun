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
        string name = collider.gameObject.name;
        if (name.Equals("Floor(Clone)")
            || name.Equals("CoinFloor3(Clone)") 
            || name.Equals("CoinFloor2(Clone)") 
            || name.Equals("CoinFloor1(Clone)")
            || name.Equals("TrapFloor1(Clone)")
            || name.Equals("TrapFloor2(Clone)")
            || name.Equals("SideTrapFloor1(Clone)")
            || name.Equals("SideTrapFloor2(Clone)")
        ){
            GameObject.Find("mapFactory").GetComponent<MapFactory>().SendMessage("recycleFloor");
        }
    }
}

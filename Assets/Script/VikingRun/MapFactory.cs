using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    public List<GameObject> needDelete;
    public GameObject floor, trapObj;
    public int floorDirection = 0;
    public int vikingDirection = 0;
    public int trapProb = 0;
    int[] rotationTable = { 0, 90, 180, 270 };
    public void setVikingDirection(int value)
    {
        vikingDirection = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    System.Random rdm = new System.Random();
    // Update is called once per frame
    void Update()
    {
    }
    void newFloor()
    {
        //need add trap function
        int probTrap = rdm.Next();
        if(probTrap%101 < trapProb)
        {
            
        }
        Vector3 tempPosition = needDelete[needDelete.Count - 1].transform.localPosition;//get the last item
        GameObject spawn = Instantiate(floor);
        spawn.transform.parent = transform;
        switch (floorDirection)
        {
           case 0:
                spawn.transform.localPosition = tempPosition + new Vector3(0, 0, 8);
                break;
            case 1:
                spawn.transform.localPosition = tempPosition + new Vector3(8, 0, 0);
                break;
            case 2:
                spawn.transform.localPosition = tempPosition + new Vector3(0, 0, -8);
                break;
            case 3:
                spawn.transform.localPosition = tempPosition + new Vector3(-8, 0, 0);
                break;
        }
        needDelete.Add(spawn);
    }
    int getNextDirection()
    {
       int temp = rdm.Next(-1, 2) + floorDirection;
        if (temp > 3) temp = 0;
        else if (temp < 0) temp =3;
        return temp;
    }
   
   
    public void recycleFloor()
    {
        Destroy(needDelete[0]);
        needDelete.RemoveAt(0);

        if (needDelete.Count < 18)
        {
            //build new floor here
            floorDirection = getNextDirection();// update direction
            //here need to new sensor
            for(int i = 0; i < 9; i++) 
                newFloor();

            floorDirection = getNextDirection();// update direction
            //here need to new sensor
            for (int i = 0; i < 9; i++)
                newFloor();
        }

    }
   
    public void pushList(GameObject obj)
    {
        needDelete.Add(obj);
    }
    void OnTriggerStay(Collider collider)
    {
        
    }

    void OnTriggerExit(Collider collider)
    {

    }
}

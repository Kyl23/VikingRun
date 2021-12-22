using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    public List<GameObject> needDelete;
    public GameObject floor;
    public GameObject[] trapObj, coinObj;
    public int floorDirection = 0;
    public int vikingDirection = 0;
    public int probTrap = 0 , probCoinVsEmpty = 0;
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
    void newFloor(GameObject obj)
    {
        Vector3 tempPosition = needDelete[needDelete.Count - 1].transform.localPosition;//get the last item
        GameObject spawn = Instantiate(obj);
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
        spawn.transform.localRotation = Quaternion.Euler(0, rotationTable[floorDirection], 0);

        needDelete.Add(spawn);
    }
    int getNextDirection()
    {
       int temp = rdm.Next(-1, 2) + floorDirection;
        if (temp > 3) temp = 0;
        else if (temp < 0) temp =3;
        return temp;
    }
   
   
    void newParagraphFloor()
    {
        //build new floor here
        floorDirection = getNextDirection();// update direction
        int trapIndex = 5; // must not be 0 & 8
        //need add trap function
        if (rdm.Next() % 101 <= probTrap)
        {
            trapIndex = rdm.Next(2, 7);
        }
        else
        {
            trapIndex = -1;
        }

        //here need to new sensor
        for (int i = 0; i < 9; i++)
        {
            if (i == trapIndex)
            {
                newFloor(trapObj[rdm.Next() % 2]);
            }
            else
            {
                if (trapIndex == -1)
                {
                    if (rdm.Next() % 101 <= probCoinVsEmpty)
                    {
                        newFloor(coinObj[rdm.Next() % 3]);
                    }
                    else
                    {
                        newFloor(floor);
                    }
                }
                else
                {
                    newFloor(floor);
                }
            }
        }
    }
    public void recycleFloor()
    {
        Destroy(needDelete[0]);
        needDelete.RemoveAt(0);

        if (needDelete.Count < 18)
        {
            newParagraphFloor();
            newParagraphFloor();
        }

    }
}

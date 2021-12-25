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
    Vector3 tempPosition;
    int[] rotationTable = { 0, 90, 180, 270 };
    int constFloorDirection, constFloorNum;
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
   
   
    void newParagraphFloor(Vector3 tp)
    {
        tempPosition = tp;
        //build new floor here
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
                newFloor(trapObj[rdm.Next() % 4]);
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
            tempPosition = needDelete[needDelete.Count - 1].transform.localPosition;
        }
    }
    int addFloorDirection(int value) 
    {
        int temp = value + vikingDirection;
        if (temp > 3) temp = 0;
        else if (temp < 0) temp = 3;
        return temp;
    }
    public void recycleUselessFloor(Vector3 vikingPosition) // 2 is right ,1 is left
    {
        try
        {
            for (int i = 0; ;)
            {
                switch (vikingDirection)
                {
                    case 0:
                        if (needDelete[i].transform.localPosition.z < GameObject.Find("viking").transform.localPosition.z - 4)
                        {
                            Destroy(needDelete[i]);
                            needDelete.RemoveAt(i);
                            continue;
                        }
                        break;
                    case 1:
                        if (needDelete[i].transform.localPosition.x < GameObject.Find("viking").transform.localPosition.x - 4)
                        {
                            Destroy(needDelete[i]);
                            needDelete.RemoveAt(i);
                            continue;
                        }
                        break;
                    case 2:
                        if (needDelete[i].transform.localPosition.z > GameObject.Find("viking").transform.localPosition.z - 4)
                        {
                            Destroy(needDelete[i]);
                            needDelete.RemoveAt(i);
                            continue;
                        }
                        break;
                    case 3:
                        if (needDelete[i].transform.localPosition.x > GameObject.Find("viking").transform.localPosition.x - 4)
                        {
                            Destroy(needDelete[i]);
                            needDelete.RemoveAt(i);
                            continue;
                        }
                        break;

                }
                i++;
                if (i >= needDelete.Count) break;
            }
        }
        catch (System.Exception) { Debug.Log("unknow error"); }
    }
    public void recycleFloor()
    {
        try
        {
            Destroy(needDelete[0]);
            needDelete.RemoveAt(0);

            Vector3 tpPosition = needDelete[needDelete.Count - 1].transform.localPosition;//get the last item
            constFloorNum = needDelete.Count;
            constFloorDirection = floorDirection;
            if (needDelete.Count < 10)
            {
                if (rdm.Next() % 3 < 2)
                {
                    floorDirection = addFloorDirection(rdm.Next(-1, 2));// update direction
                    newParagraphFloor(tpPosition);
                }
                else
                {
                    floorDirection = addFloorDirection(1);
                    newParagraphFloor(tpPosition);
                    floorDirection = addFloorDirection(-1);
                    newParagraphFloor(tpPosition);
                }

            }
        }
        catch (System.Exception) { Debug.Log("duplicate destroy"); }

    }
}

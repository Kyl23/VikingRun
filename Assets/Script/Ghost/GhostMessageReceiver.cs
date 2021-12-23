using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMessageReceiver : MonoBehaviour
{
    public int chaseSpeed = 20;
    bool isNearing = true;
    float timeNow = 0;
    bool isAnimateNear = false, isAnimateFar = false;
    int target = 0;
    public void chased()
    {
        isAnimateNear = true;
        target = -2;
        isNearing = false;
        GameObject.Find("viking").SendMessage("endGame");
    }
    public void crash()
    {
        if (isNearing)
        {
            GameObject.Find("Character1_Reference").SendMessage("flipToRear");
            chased();
        }
        else
        {
            timeNow = Time.time;
            isAnimateNear = true;
            isNearing = true;
            target = -4;
        }
    }
    public void goBackPosition()
    {
        isNearing = false;
        isAnimateFar = true;
        target = -8;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimateNear)
        {
            transform.localPosition += new Vector3(0, 0, chaseSpeed * Time.deltaTime);
            if (transform.localPosition.z >= target)
            {
                transform.localPosition = new Vector3(0, 0, target);
                isAnimateNear = false;
            }
        }
        if (isAnimateFar)
        {
            transform.localPosition -= new Vector3(0, 0, chaseSpeed * Time.deltaTime);
            if (transform.localPosition.z <= target)
            {
                transform.localPosition = new Vector3(0, 0, target);
                isAnimateFar = false;
            }
        }
        
        if(isNearing && Time.time - timeNow > 5)
        {
            goBackPosition();
        }
            
    }
}

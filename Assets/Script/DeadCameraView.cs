using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCameraView : MonoBehaviour
{
    public int cameraSpeed = 5, radius = 5;
    bool isStartRotate = false;
    float camRotated = 0 , camScaled = 0;
    float y, z;
    public void viewStart()
    {
        isStartRotate = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        y = 15 - transform.localPosition.y;
        z = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isStartRotate && camRotated < 180) 
        {
            if (transform.localPosition.y < 15)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, camRotated / 180 * y * 60, transform.localPosition.z);
            }
            transform.localRotation = Quaternion.Euler((camRotated * 0.5f * 10 > 90) ? 90 : camRotated * 0.5f * 10, camRotated, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z - camRotated / 180 * z);
            camRotated += Time.deltaTime * cameraSpeed;
        }
    }
}

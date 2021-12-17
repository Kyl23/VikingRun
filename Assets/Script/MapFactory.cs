using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    public List<GameObject> needDelete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.name.Equals("viking"))
        {
            Destroy(needDelete[0]);
            needDelete.RemoveAt(0);
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 8);
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

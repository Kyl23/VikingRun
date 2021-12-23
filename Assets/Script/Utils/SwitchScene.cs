using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour,IPointerClickHandler
{
    public int target;
    public void OnPointerClick(PointerEventData e)
    {
        SceneManager.LoadScene(target);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

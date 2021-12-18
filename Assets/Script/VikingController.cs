using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    public int rotationSpeed = 200;
    [SerializeField]float movingSpeed=10f;
    bool jump = true;
    public bool run = true;
    public float jumpForce=10000;
    public GameObject lightObj;
    public GameObject sensor;
    Rigidbody rb;
    Animator animator;
    bool turnAnimation = false;
    float y = 0;
    int dic = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    int yRotation = 0;
    Vector3[,] vectorTable = { { Vector3.forward, Vector3.left, Vector3.back, Vector3.right},
                               { Vector3.right, Vector3.forward, Vector3.left, Vector3.back},
                               { Vector3.back, Vector3.right, Vector3.forward, Vector3.left},
                               { Vector3.left, Vector3.back, Vector3.right, Vector3.forward},
                             };
    int[] rotationTable = { 0, 90, 180, 270 };
    // Update is called once per frame
    void Update()
    {
        if(run)
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 0];
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 1];
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 2];
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 3];
        }
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.AddForce(jumpForce * Time.deltaTime * Vector3.up);
            jump = false;
        }
        animator.SetBool("Jump", !jump);
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit raycastHit;
            if (Physics.Raycast(r, out raycastHit))
            {
                if(raycastHit.collider.gameObject.name.Equals("Coin(Clone)"))
                    Destroy(raycastHit.collider.gameObject);
            }
        }
        
        if (turnAnimation ) {
            if (dic == -1)
            {
                y -= rotationSpeed * Time.deltaTime;
                if (y < 0) y += 360;
            }
            else
            {
                y += rotationSpeed * Time.deltaTime;
                if (y > 360) y -= 360;
            }
            if (y > rotationTable[yRotation])
            {
                if (y - rotationTable[yRotation] < 10)
                {
                    y = rotationTable[yRotation];
                    turnAnimation = false;
                }
            }
            else
            {
                if (rotationTable[yRotation] - y < 10)
                {
                    y = rotationTable[yRotation];
                    turnAnimation = false;
                }
            }
            transform.rotation = Quaternion.Euler(0, y, 0);
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            turnAnimation = true;
            flipSensor(-1);
            dic = -1;
            GameObject.Find("Sensor").SendMessage("setVikingDirection", yRotation);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turnAnimation = true;
            flipSensor(1);
            dic = 1;
            GameObject.Find("Sensor").SendMessage("setVikingDirection", yRotation);
        }
        lightObj.transform.localPosition = transform.localPosition + new Vector3(0, 3, 0);
    }
    void flipSensor(int direction)
    {
        Debug.Log("touch");
        switch (yRotation)
        {
            case 0:
                sensor.transform.localPosition += new Vector3(0, 100, -4);
                break;
            case 1:
                sensor.transform.localPosition += new Vector3(-4, 100, 0);
                break;
            case 2:
                sensor.transform.localPosition += new Vector3(0, 100, 4);
                break;
            case 3:
                sensor.transform.localPosition += new Vector3(4, 100, 0);
                break;
        }
        if (direction == 1) //right -1 is left
        {
            setRotaionState(1);
        }
        else
        {
            setRotaionState(-1);
        }
        switch (yRotation)
        {
            case 0:
                sensor.transform.localPosition += new Vector3(0, -100, 4);
                break;
            case 1:
                sensor.transform.localPosition += new Vector3(4, -100, 0);
                break;
            case 2:
                sensor.transform.localPosition += new Vector3(0, -100, -4);
                break;
            case 3:
                sensor.transform.localPosition += new Vector3(-4, -100, 0);
                break;
        }
        sensor.transform.rotation = Quaternion.Euler(Vector3.up * rotationTable[yRotation]);
    }
    void setRotaionState(int value)// value only be -1,1
    {
        if (value > 0)
        {
            if (yRotation == 3) yRotation = 0;
            else yRotation += 1;
        }
        else
        {
            if (yRotation == 0) yRotation = 3;
            else yRotation -= 1;
        }
    }
    void OnCollisionEnter(Collision collision)
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("big_module_05")) ;
            jump = true;
    }

    void OnCollisionExit(Collision collision)
    {
        
    }
}

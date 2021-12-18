using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    [SerializeField]float movingSpeed=10f;
    bool jump = true, run;
    public float jumpForce=10000;
    public GameObject lightObj;
    Rigidbody rb;
    Animator animator;

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

        if (Input.GetKeyDown(KeyCode.Q))
        {            
            setRotaionState(-1);
            transform.rotation = Quaternion.Euler(Vector3.up * rotationTable[yRotation]);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            setRotaionState(1);
            transform.rotation = Quaternion.Euler(Vector3.up * rotationTable[yRotation]);
        }
        lightObj.transform.localPosition = transform.localPosition + new Vector3(0, 3, 0);
        Debug.Log(transform.localPosition);
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
        jump = true;
    }

    void OnCollisionExit(Collision collision)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    Vector3[,] vectorTable = { { Vector3.forward, Vector3.left, Vector3.back, Vector3.right},
                               { Vector3.right, Vector3.forward, Vector3.left, Vector3.back},
                               { Vector3.back, Vector3.right, Vector3.forward, Vector3.left},
                               { Vector3.left, Vector3.back, Vector3.right, Vector3.forward},
                             };
    int[] rotationTable = { 0, 90, 180, 270 };
    [SerializeField]float movingSpeed=10f;
    public int rotationSpeed = 200;
    public float jumpForce=10000 , slideTime = 1.5f;
    public GameObject lightObj, endUI, timer;
    Rigidbody rb;
    Animator animator;
    bool jump, run, turnAnimation, isPause, isSlide;
    float y, timeNow;
    int dic, yRotation;
    
    public void toggleStatus()
    {
        animator.SetBool("Run", !run);
        run = !run;
        isPause = !isPause;
    }
    public void startGame()
    {
        isPause = false;
        animator.SetBool("Run", true);
    }
    public void endGame()
    {
        isPause = true;
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
    void init() {
        jump = true;
        run = true;
        isPause = true;
        isSlide = false;
        turnAnimation = false;
        timeNow = 0;
        yRotation = 0;
        y = 0;
        dic = 1;
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isPause && jump) return;
        Transform vikingShell = GameObject.Find("Character1_Reference").transform;
        if (isSlide && Time.time - timeNow > slideTime)
        {
            isSlide = false;
            vikingShell.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if(run || !jump)
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 0];
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 1];
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!jump)
            {
                jump = true;
                rb.AddForce(jumpForce * Vector3.down);
            }
            vikingShell.localRotation = Quaternion.Euler(-80, 0, 0);
            timeNow = Time.time;
            isSlide = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * vectorTable[yRotation, 3];
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            if (isSlide)
            {
                isSlide = false;
                vikingShell.localRotation = Quaternion.Euler(0, 0, 0);
            }
            rb.AddForce(jumpForce * Vector3.up);
            jump = false;
        }
        animator.SetBool("Jump", !jump);
        
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
            setRotaionState(-1);
            dic = -1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turnAnimation = true;
            setRotaionState(1);
            dic = 1;
        }
        lightObj.transform.localPosition = transform.localPosition + new Vector3(0, 3, 0);

        if (transform.position.y < -5)
        {
            Instantiate(endUI);
            isPause = true;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        if (collision.gameObject.name.Equals("Floor(Clone)"))
        {
            jump = true;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        string name = collider.gameObject.name;
        if (collider.gameObject.name.Equals("Coin"))
        {
            GameObject.Find("Score").SendMessage("getCoin");
            Destroy(collider.gameObject);
        }
    }
}

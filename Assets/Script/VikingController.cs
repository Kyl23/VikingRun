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
    public GameObject map;
    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * Vector3.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * Vector3.left;
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * Vector3.back;
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Time.deltaTime * movingSpeed * Vector3.right;
            run = true;
        }
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.AddForce(jumpForce * Time.deltaTime * Vector3.up);
            jump = false;
        }
        animator.SetBool("Run", run);
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

        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation = new Quaternion(map.transform.localRotation.x, map.transform.localRotation.y - 90, map.transform.localRotation.z, map.transform.localRotation.w);
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

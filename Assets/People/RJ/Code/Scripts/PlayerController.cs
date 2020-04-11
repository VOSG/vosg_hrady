using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public float rotSpeed = 80;
    float rot = 0;
    public float gravity = 8;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _anim = transform.Find("CharMesh").GetComponent<Animator>();
            if(_anim == null)
            {
                Debug.Log("CharMesh of " + this.gameObject.name + "couldn't be found. EXITING");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }






    void Movement()
    {

        if(controller.isGrounded)
        {
            if(Input.GetAxis("Vertical") >= 0.05)
            {
                _anim.SetFloat("walking", 1);
                moveDir = new Vector3(0,0, 1) * speed;
                moveDir = transform.TransformDirection(moveDir);
            }
           
            if(Input.GetAxis("Vertical") <= 0.05)
            {
                moveDir = new Vector3(0,0, 0);
                _anim.SetFloat("walking", 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        Debug.Log(Input.GetAxis("Horizontal"));
        transform.eulerAngles = new Vector3(0, rot, 0);


        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}

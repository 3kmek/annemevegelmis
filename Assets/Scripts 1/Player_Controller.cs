using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{     
    private bool isGrounded;
    public Transform ground;
    
    public float radius;
    public float gravity;
    public float jumpHeight;
    public LayerMask mask;
    Vector3 velocity;

    public Rigidbody rb;
    public float speed = 10f;
    Vector3 move = Vector3.zero;

    
    private void FixedUpdate()
    {
        #region Movement with Rigidbody
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = new Vector3(x, 0, z) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + transform.TransformDirection(move));
        #endregion
        #region Movement
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 move = transform.right * horizontal + transform.forward * vertical ;
        //controller.Move(move * speed * Time.deltaTime);
        #endregion
        

        #region Gravity

        //isGrounded = Physics.CheckSphere(ground.position, radius, mask);
        //if(isGrounded && velocity.y < 0)
        //{
       //     velocity.y = 0f;
        //}

        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);

        #endregion
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rb.velocity = (Vector3.up * Time.deltaTime * jumpHeight);
        }




    }
}

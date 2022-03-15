using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{   /*  
    private bool isGrounded;
    public Transform ground;
    
    public float radius;
    public float jumpHeight;
    public LayerMask mask;
    Vector3 velocity;

    public Rigidbody rb;
    public float speed = 10f;
    Vector3 move = Vector3.zero;*/

    #region ananý sikiyom
    [SerializeField] Transform playerCamera;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    void UpdateMouseLook()
    {
        // mouselooku sildim buraya ekledim burdan sense ve smoothluðuda ayarlayabiliyon
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        // clamp camerapitch deðeri min max arasýndaysa döndürüyo büyükse maxý döndürüyo küçükse mini döndürüyo
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // normalize büyüklükleri 1 yapýyo aga
        targetDir.Normalize();
        // smoothdamp current vectorden target vectore verdiðmiz time da verdiðimiz hýzda deðiþtiriyo :D amk evladý
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // is grounded nasý çalýþýy bilmiyom bakcam
        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }
    #endregion





    /*
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




    }*/
}

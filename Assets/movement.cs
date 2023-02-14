using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private bool jumpPressed;
    public KeyCode jumpKey;
    private bool onGround;
    private bool _groundDetected;
    public bool groundDetected
    {
        get
        {
            Debug.Log(_groundDetected);
            return _groundDetected;
        }
        private set
        {
            _groundDetected = value; 
        }
    }
    public float miny;
    public float maxy;
    public float diffy;
    public Vector3? jumpStart;
    public float jumpLength;
    public int coyoteFrames = 5;
    private int coyoteTimer;
    public float respawnLevel = -7.5f;
    private Vector3 restartPosition;
    public static movement player { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        player = this;
    }

    void Start()
    {
        miny = maxy = transform.position.y;
        restartPosition = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > maxy)
        {
            maxy = transform.position.y;
        }
        if (transform.position.y < miny)
        {
            miny = transform.position.y;
        }
        diffy = maxy - miny;
        float verticalSpeed = rb.velocity.y;
        if (jumpPressed)
        {
            if (coyoteTimer > 0)
            {
                jumpStart = transform.position;
                verticalSpeed = jumpForce;
                coyoteTimer = 0;
            }
            jumpPressed = false;
        }

        if (transform.position.y < respawnLevel)
        {
            transform.position = restartPosition;
        }
        Vector3 move = Input.GetAxis("Vertical") * transform.forward * speed;
        move += Input.GetAxis("Horizontal") * transform.right * speed;
        move += verticalSpeed * Vector3.up;
        //transform.Translate(move * Time.fixedDeltaTime);
        rb.velocity = move;
        onGround = false;
        if (coyoteTimer > 0)
        {
            coyoteTimer--;
        }

    }
    void Update()
    {
        if (!jumpPressed)
        {
            jumpPressed = Input.GetKeyDown(jumpKey);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (Vector3.Dot(collision.GetContact(0).normal, Vector3.up) > 0.85f)
        {
            if (!onGround && jumpStart.HasValue && rb.velocity.y <= 0)
            {
                jumpLength = Vector3.Distance(jumpStart.Value, transform.position);
                jumpStart = null;
            }
            onGround = true;
            coyoteTimer = coyoteFrames;
        }
        groundDetected = onGround;
    }
}
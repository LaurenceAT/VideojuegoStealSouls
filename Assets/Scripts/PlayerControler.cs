using System;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //COMPONENTS
    private Rigidbody2D m_rigidbody2D;
    private GatherInput m_gatherInput;
    private Transform m_transform;
    private Animator m_animator;

    //VALUES
    [SerializeField] private float speed;
    private int direction = 1;
    private int idSpeed;
    private int idIsGrounded;
    [SerializeField] private float jumpForce;
        //EXTRAJUMP
    [SerializeField] private int extrajumps;
    [SerializeField] private int counterExtraJumps;


    [SerializeField] private Transform lFoot, rFoot;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float rayLengnth;
    [SerializeField] private LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gatherInput = GetComponent<GatherInput>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        idSpeed = Animator.StringToHash("Speed");
        idIsGrounded = Animator.StringToHash("isGrounded");
        lFoot = GameObject.Find("LFoot").GetComponent<Transform>();
        rFoot = GameObject.Find("RFoot").GetComponent<Transform>();
    }

    private void Update()
    {
        SetAnimatorValues();
    }

    private void SetAnimatorValues()
    {
        m_animator.SetFloat(idSpeed, Mathf.Abs(m_rigidbody2D.linearVelocityX));
        m_animator.SetBool(idIsGrounded, isGrounded);
    }


     
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
        CheckGround();
    }


    private void Move()
    {
        Flip();
        m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherInput.ValueX, m_rigidbody2D.linearVelocityY);

    }

    private void Flip()
    {
        if(m_gatherInput.ValueX * direction < 0)
        {
            m_transform.localScale = new Vector3(-m_transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
    private void Jump()
    {
        if (m_gatherInput.IsJumping)
        {
            float originalSpeed = speed; // Guardar la velocidad original

            if (isGrounded)
            {
                speed = 6f; // Aumentar la velocidad al saltar
                m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherInput.ValueX, jumpForce);
            }

            if (counterExtraJumps > 0)
            {
                speed = 6f; // Aumentar la velocidad en saltos extra
                m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherInput.ValueX, jumpForce);
                counterExtraJumps--;
            }

            Invoke("ResetSpeed", 0.1f);
        }
        m_gatherInput.IsJumping = false; 
    }

    private void ResetSpeed()
    {
        speed = 5f; // Volver a la velocidad normal
    }
    private void CheckGround()
    {
        RaycastHit2D lFootRay = Physics2D.Raycast(lFoot.position,Vector2.down,rayLengnth,groundLayer);
        RaycastHit2D rFootRay = Physics2D.Raycast(lFoot.position,Vector2.down,rayLengnth,groundLayer);
        if (lFootRay || rFootRay)
        {
            isGrounded = true;
            counterExtraJumps = extrajumps;
        }
        else
        {
            isGrounded = false;
        }
    }
}

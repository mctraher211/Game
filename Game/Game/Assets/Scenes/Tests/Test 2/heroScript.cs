using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{

    Rigidbody2D rb;

    public float heroSpeed = 10f;
    public float heroVertImpulse = 700f;
    public int health;
    public int mana;

    // Переменные для проверки, стоит ли ГГ на земле (чтобы убрать бесконечн. jump)
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // ГГ смотрит вправо
    bool isFacingRight = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // Присваивается значение нажатой кнопки для движения. "A" -> move = -1;  "D" -> move = 1:
        float move;
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * heroSpeed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, heroVertImpulse));
        }

        if ((move < 0) && isFacingRight)
            Flip();
        else if ((move > 0) && !isFacingRight)
            Flip();
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }




    void Update()
    {

    }
}

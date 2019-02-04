using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{

    Rigidbody2D rb;  // Хранит ссылку на RigidBody2D ГГ

    public float heroSpeed = 10f;  // Скорость
    public float heroVertImpulse = 11.9f;  // Сила прыжка


    // Переменные для проверки, стоит ли ГГ на земле (чтобы убрать бесконечн. jump)
    bool grounded = false;
    public Transform groundCheck;  // В инспекторе определяем элемент, который будет отвечать за проверку
    public float groundRadius = 0.69f;  // Радиус
    public LayerMask whatIsGround;  // В инспекторе определяем, что "земля" это всё, кроме ГГ (на первое время)



    bool isFacingRight = true;  // ГГ смотрит вправо

    void Flip()  // Функция для разворота перса
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }  // Inspector -> Transform -> Scale(X) — умножаем на -1


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Инициализация компонента 
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);  // Проверка "земли"
      
        float move;  // Присваивается значение нажатой кнопки для движения
        move = Input.GetAxis("Horizontal");  // "A" -> move = -1..0;  "D" -> move = 0..1  (Плавный переход в пределах -1..1)

        rb.velocity = new Vector2(move * heroSpeed, rb.velocity.y);  // Устанавливаем скорость для Rigidbody2D

        if (Input.GetKeyDown(KeyCode.Space) && grounded)  // Если нажата кл. Space И перс на земле 
            rb.AddForce(new Vector2(0, heroVertImpulse), ForceMode2D.Impulse);  // Прикладывание силы к Rigidbody
        
        // Разворот перса
        if ((move < 0) && isFacingRight)
            Flip();
        else if ((move > 0) && !isFacingRight)
            Flip();
    }


}

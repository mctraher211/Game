using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float horizontalSpeed = 0.5f; //Переменная отображающая скорось. 
    public float speedX;//Служебная переменная в зависимоси от которой определяется движение в лево или в право. 
    public float verticalImpulse;//Значение силы для прыжка. 
    Rigidbody2D rb;//Хранит ссылку на RigidBody2D нашего ГГ. 
    public int health;
    public int mana;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Инициализация компонента. 

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))//Если была нажата клавиша А. 
        {
            speedX = -horizontalSpeed;//Будет хранить отрицатильное значение скорости что поможит двигаться по оси X влево.
            health = 10;
        }
        else if (Input.GetKey(KeyCode.D))//Если была нажата клавиша D.
        {
            speedX = horizontalSpeed;//Будет хранить положительное значение скорости что поможет двигаться вправо. 
        }
        if (Input.GetKeyDown(KeyCode.Space))//Если была нажата клавиша пробел. 
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);//Прикладывание силы к Rigidbody 
        }
        transform.Translate(speedX, 0, 0);//Метод для перемещения по переменой speedX. 
        speedX = 0;//Метод который обнуляет скорость если клавишы не нажаты. 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health = 0;
        }
    }
}
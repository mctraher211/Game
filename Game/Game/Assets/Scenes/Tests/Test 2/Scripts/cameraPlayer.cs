using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayer : MonoBehaviour
{
    public float damping = 2.6f;  // Скорость выравнивания камеры
    public Vector2 offset = new Vector2(5.3f, 2.56f);  // Cмещение по X и Y

    bool faceLeft;  // Вектор движения по Х направлен влево
    private Transform player;
    private int lastX;  // Последнее значение координаты по Х


    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);  // Oкругляем смещение
        FindPlayer(faceLeft); // Ищем игрока
    }

    public void FindPlayer(bool playerFaceLeft)  // Функция для поиска игрока
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Игрок обязательно должен иметь тег "Player"
        lastX = Mathf.RoundToInt(player.position.x);  // Последнее значение координаты по Х равно позиции игрока

        if (playerFaceLeft) // Если двигается влево (изначально не имеет значения, но работает и принимает false, хз)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z); 
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); // Выравниваем камеру с учетом смещения
        }
    }


    void FixedUpdate()
    {
        if (player)  // Если Player найден на сцене
        {
            int currentX = Mathf.RoundToInt(player.position.x);  // Присваивание текущей позиции по Х
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;  // Определяем вектор движения
            lastX = Mathf.RoundToInt(player.position.x);  // Обновляем последнюю позицию по Х

            Vector3 target;  // Задаем пустой вектор для target
            if (faceLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z); // Присваиваем значения в вектор
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);  // Задаем вектор для плавного(Lerp) смещения камеры
            transform.position = currentPosition;  // Смещение камеры
        }
    }

}

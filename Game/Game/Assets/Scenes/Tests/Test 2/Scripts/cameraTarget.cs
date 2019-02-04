using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{
  
    public float damping = 1.5f;  // Скорость выравнивания камеры
    public float offsetX = 0.5f;  // Cмещение X
    public float offsetY = 0.5f;  // Смещение Y
    public Transform target;  // Цель для привязки камеры
    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer spriteSizePicking;  // Выбираем, под какой спрайт камера должна подогнать размер 

    void Start()
    {
        if (spriteSizePicking)  // Если SpriteRenderer не пустой
            Camera.main.orthographicSize = (spriteSizePicking.bounds.size.y + (spriteSizePicking.bounds.size.x / 7)) / 2;  // Меняем размер камеры (выражение подобрано от пизды)
    }

    void FixedUpdate()
    {
        if (target)  // Если выбрана цель, "цепляемся" за нее схожим с cameraPlayer способом
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.75f, target.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offsetY, offsetX, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, damping);
        }
    }


}

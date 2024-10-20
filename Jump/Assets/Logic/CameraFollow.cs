using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Ссылка на объект игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания
    public Vector3 offset;         // Смещение камеры

    void LateUpdate()
    {
        // Определяем позицию цели для камеры
        Vector3 desiredPosition = player.position + offset;

        // Плавно интерполируем позицию камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Устанавливаем позицию камеры
        transform.position = smoothedPosition;
    }
}

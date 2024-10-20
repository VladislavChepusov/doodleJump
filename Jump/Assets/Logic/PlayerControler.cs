using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f; // Сила прыжка
    public float moveSpeed = 5f;   // Скорость движения

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Для изменения спрайта

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer
    }

    void Update()
    {
        // Движение по горизонтали
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Флип спрайта в зависимости от направления движения
        if (moveInput > 0) // Движение вправо
        {
            spriteRenderer.flipX = false; // Оставляем оригинальное отображение
        }
        else if (moveInput < 0) // Движение влево
        {
            spriteRenderer.flipX = true; // Переворачиваем по оси X
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на столкновение с платформой
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Прыжок при столкновении с платформой
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
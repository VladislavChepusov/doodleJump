using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f; // ���� ������
    public float moveSpeed = 5f;   // �������� ��������

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // ��� ��������� �������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer
    }

    void Update()
    {
        // �������� �� �����������
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ���� ������� � ����������� �� ����������� ��������
        if (moveInput > 0) // �������� ������
        {
            spriteRenderer.flipX = false; // ��������� ������������ �����������
        }
        else if (moveInput < 0) // �������� �����
        {
            spriteRenderer.flipX = true; // �������������� �� ��� X
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �������� �� ������������ � ����������
        if (collision.gameObject.CompareTag("Platform"))
        {
            // ������ ��� ������������ � ����������
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
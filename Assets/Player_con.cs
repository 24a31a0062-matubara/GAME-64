using UnityEngine;
using UnityEngine.SceneManagement;

public class UniversalMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public float leftWarpX = -5f;   // 左端にワープするX座標
    public float rightWarpX = 5f;   // 右端にワープするX座標

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面判定
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // ジャンプ処理
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // PC入力（A/Dキー）
        float keyInput = 0f;
        if (Input.GetKey(KeyCode.A)) keyInput = -1f;
        if (Input.GetKey(KeyCode.D)) keyInput = 1f;

        // スマホ入力（傾き）
        float tiltInput = Input.acceleration.x;

        // 両方の入力を合成（優先度はキー入力）
        float moveInput = Mathf.Abs(keyInput) > 0 ? keyInput : tiltInput;

        // 移動処理
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // スプライトの反転
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        float leftWarpX = Camera.main.transform.position.x - halfWidth;
        float rightWarpX = Camera.main.transform.position.x + halfWidth;

        if (other.CompareTag("LeftWall"))
        {
            transform.position = new Vector3(rightWarpX, transform.position.y, transform.position.z);
        }
        else if (other.CompareTag("RightWall"))
        {
            transform.position = new Vector3(leftWarpX, transform.position.y, transform.position.z);
        }
        if (other.CompareTag("DeathZone"))
        {
            // ゲームオーバー処理（指定のシーンへ移動）
            SceneManager.LoadScene("RisultScene");
        }

    }

}

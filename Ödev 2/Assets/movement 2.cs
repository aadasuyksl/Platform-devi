using UnityEngine;

public class TopZiplama2 : MonoBehaviour
{
    public float ziplaGucu = 7f; // Z�plama g�c�
    public float hareketHizi = 5f; // Hareket h�z�
    private Rigidbody2D rb;
    private bool yerdemi = true; // Topun yerde olup olmad���n� kontrol etmek i�in

    void Start()
    {
        // Rigidbody2D bile�enini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Yatay eksende hareketi kontrol et (A ve D tu�lar�yla)
        float yatayHareket = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            yatayHareket = -hareketHizi; // Sol tarafa git
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yatayHareket = hareketHizi; // Sa� tarafa git
        }

        // Yatay hareketi uygulamak
        rb.velocity = new Vector2(yatayHareket, rb.velocity.y);

        // Z�plama - E�er W tu�una bas�ld�ysa ve top yerdeyse
        if (Input.GetKeyDown(KeyCode.W) && yerdemi)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplaGucu); // Y ekseninde z�plama
            yerdemi = false; // Top art�k havada
        }
    }

    // Top zemine de�di�inde
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer"))
        {
            yerdemi = true; // Top zemine de�di�inde z�plama aktif olur
        }
    }


}
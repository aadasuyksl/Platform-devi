using UnityEngine;

public class TopZiplama2 : MonoBehaviour
{
    public float ziplaGucu = 7f; // Zýplama gücü
    public float hareketHizi = 5f; // Hareket hýzý
    private Rigidbody2D rb;
    private bool yerdemi = true; // Topun yerde olup olmadýðýný kontrol etmek için

    void Start()
    {
        // Rigidbody2D bileþenini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Yatay eksende hareketi kontrol et (A ve D tuþlarýyla)
        float yatayHareket = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            yatayHareket = -hareketHizi; // Sol tarafa git
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yatayHareket = hareketHizi; // Sað tarafa git
        }

        // Yatay hareketi uygulamak
        rb.velocity = new Vector2(yatayHareket, rb.velocity.y);

        // Zýplama - Eðer W tuþuna basýldýysa ve top yerdeyse
        if (Input.GetKeyDown(KeyCode.W) && yerdemi)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplaGucu); // Y ekseninde zýplama
            yerdemi = false; // Top artýk havada
        }
    }

    // Top zemine deðdiðinde
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer"))
        {
            yerdemi = true; // Top zemine deðdiðinde zýplama aktif olur
        }
    }


}
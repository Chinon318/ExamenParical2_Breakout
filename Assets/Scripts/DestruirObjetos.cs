using System.Collections;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    [SerializeField]private AgregarPuntaje agregarPuntaje;
    [SerializeField]private EmpezarJuego empezarJuego;

    private Rigidbody2D rb;

    public Transform posInicial;
    void Awake()
    {
        agregarPuntaje = FindFirstObjectByType<AgregarPuntaje>();
        empezarJuego = FindFirstObjectByType<EmpezarJuego>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!empezarJuego.empezar)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            agregarPuntaje.AddPuntos(5);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limite"))
        {
            agregarPuntaje.ResetPuntos();
            empezarJuego.empezar = false;
            Debug.Log("Limite");

            StartCoroutine(ReiniciarPosicion());
        }
    }


    IEnumerator ReiniciarPosicion()
    {
        transform.position = posInicial.position;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);

        rb.gravityScale = 1;
        
    }


}

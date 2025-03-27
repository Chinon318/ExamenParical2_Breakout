using System.Collections;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    [SerializeField]private AgregarPuntaje agregarPuntaje;
    [SerializeField]private EmpezarJuego empezarJuego;

    [SerializeField] private float fuerzaInicial;
    [SerializeField]private bool inicioFuerza;

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
            rb.linearVelocity = Vector2.zero;
            inicioFuerza = false;
        }
        else if (!inicioFuerza && empezarJuego.empezar)
        {
            inicioFuerza = true;
            AgregarFuerza();
        }


    }

    private void AgregarFuerza()
    {
        inicioFuerza = true;
        rb.AddForce(Vector2.one * fuerzaInicial, ForceMode2D.Impulse);
        Debug.Log("Fuerzaaaa");
        
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
            inicioFuerza = false;

            StartCoroutine(ReiniciarPosicion());
        }
    }


    IEnumerator ReiniciarPosicion()
    {
        transform.position = posInicial.position;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        
    }


}

using UnityEngine;

public class MovimientoScripts : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private EmpezarJuego empezarJuego;
    public float speed = 3;

    public Transform posicionInicial;

    private void Awake() 
    {
        empezarJuego = FindFirstObjectByType<EmpezarJuego>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() 
    {
        if (empezarJuego.empezar)
        {
            Movimiento();
        }
        if (!empezarJuego.empezar)
        {
            transform.position = posicionInicial.position;
        }
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            Vector2 direccion  = new Vector2(horizontal, 0);
            rb.MovePosition((Vector2)transform.position + (direccion * speed * Time.fixedDeltaTime));
        }
        
    }
}

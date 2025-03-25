using UnityEngine;

public class EmpezarJuego : MonoBehaviour
{
    public bool empezar;


    private void Start() 
    {
        empezar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            empezar = true;
        }
    }
}

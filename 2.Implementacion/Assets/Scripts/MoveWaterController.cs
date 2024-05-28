using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaterController : MonoBehaviour
{
    // Velocidad a la que se desplazarán las imágenes
    [SerializeField] float speed;

    // Referencia al renderizador del objeto
    Renderer render;

    // Start se llama antes del primer frame update
    void Start()
    {
        // Inicializamos el componente
        render = GetComponent<Renderer>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Vector que representa la cantidad de desplazamiento de la textura
        Vector2 offset = Vector2.right * speed * Time.time;

        // Accedemos al material del objeto y aplicamos el desplazamiento
        render.material.mainTextureOffset = offset;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMove : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private bool moviendo;
    private Vector3 puntoDestino;
    private Vector3 ultimoInput;
    private Vector3 puntoInteraccion;
    private Collider2D colliderDelante; //indica el collider que tenemos por delante
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float radioInteraccion;
    [SerializeField] private LayerMask queescolisionable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");
        }
      

        //Ejecuto el movimiento solo si estoy en una casilla y solo si hay input
        if (!moviendo && (inputH != 0 || inputV !=0))
        {   
            //Actualizo cual fue mi ultimo input, cual va a ser mi puntoDestino y cual es mi puntoInteraccion
            ultimoInput=new Vector3 (inputH, inputV,0);
            puntoDestino = transform.position + ultimoInput;
            puntoInteraccion = puntoDestino;
            colliderDelante = Lanzacheck();
            if(colliderDelante == false)
            {
                StartCoroutine(Mover());
            }
           
        }
        
    }
    IEnumerator Mover()
    {
        moviendo = true;
       
        while (transform.position!= puntoDestino)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        //Ante un nuevo destino, necesito refrescar de nuevo puntoInteraccion
        puntoInteraccion=transform.position+ultimoInput;
        moviendo= false;
    }
    private Collider2D Lanzacheck()
    {
        return Physics2D.OverlapCircle(puntoInteraccion, radioInteraccion, queescolisionable);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoInteraccion, radioInteraccion);
    }
}

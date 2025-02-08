using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapTransition : MonoBehaviour
{
    //limites de la pantalla nueva
    [SerializeField] PolygonCollider2D mapBoundaries;
    CinemachineConfiner confiner;

    //Este campo es la dirección de la transición.
    //Por ejemplo en la transición del pueblo al templo es Up

    [SerializeField] Direction direction;
    enum Direction { Up, Down, Left, Right };   
    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner>();
    }

    //el collider determina el punto de transicion de una zona a otra
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            confiner.m_BoundingShape2D = mapBoundaries;
            UpdatePlayerPosition(collision.gameObject);
        }



    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        //este pequeño empuje a la posicion es para que el jugador no interactue con el collider de la nueva pantalla al entrar en ella. 
        //si hacemos más transiciones con diferentes espacios entre medias lo mismo este empuje hay que serializarlo para cada caso, de momento lo dejo fijo
        switch (direction)
        {
            case Direction.Up:
                newPos.y += 4;
                break;
            case Direction.Down:
                newPos.y -= 4;
                break;
            case Direction.Left:
                newPos.x -= 4;
                break;
            case Direction.Right:
                newPos.x += 4;
                break;

        }

        player.transform.position = newPos;


    }

}

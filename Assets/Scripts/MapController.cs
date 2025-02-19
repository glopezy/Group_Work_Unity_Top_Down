using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; set; }

    public GameObject mapParent;
    private List<Image> mapImages;

    public Color highlightedColour = Color.white; //Resaltado en blanco
    public Color dimmedColour = new Color(1f, 1f, 1f, 0.5f); //El resto en blanco con transparencia de 0.5

    public RectTransform playerIconTransform;

    private void Awake()
    {
        if (Instance != null && Instance != this) //Significa que est� duplicado
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        mapImages = mapParent.GetComponentsInChildren<Image>().ToList();
    }

    public void HighlightedArea(string areaName)
    {
        //Es muy importante que el nombre de las �reas sea igual en el mapBoundary que en el canvas
        //Atenuamos todas las �reas
        foreach (Image area in mapImages)
        {
            {
                area.color = dimmedColour;
            }

            //Buscamos el �rea deseada (en la que estamos)
            Image currentArea = mapImages.Find(x => x.name == areaName);

            //Resaltamos el �rea deseada
            if (currentArea != null)
            {
                currentArea.color = highlightedColour;

                //Movemos el icono del player al �rea correspondiente
                playerIconTransform.position = currentArea.GetComponent<RectTransform>().position;
            }
            else
            {
                Debug.LogWarning("Area not found: " + areaName);
            }
        }
    }

}

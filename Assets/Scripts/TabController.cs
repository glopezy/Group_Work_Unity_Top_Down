using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{

    public Image[] tabImages;
    public GameObject[] pages;

    void Start()
    {
        //al abrir el menu siempre se abre de predeterminada la primera pagina
        ActivateTab(0);
    }

    //dependiendo del id, que corresponde a cada una de las páginas del menú,
    //desactivamos las demás páginas y ponemos grises las demas tabs
    public void ActivateTab(int tabId)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[tabId].SetActive(true);
        tabImages[tabId].color = Color.white;
    }
    

}

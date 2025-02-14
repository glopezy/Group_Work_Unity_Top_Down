using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    

    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}

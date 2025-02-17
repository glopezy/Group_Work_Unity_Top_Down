using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{

    private InventoryController inventoryController;
    // Start is called before the first frame update
    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if(item!=null)
            {
                //meter objeto a inventario
                bool itemAdded = inventoryController.AddItem(collision.gameObject);

                //eliminar objeto flotante
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}

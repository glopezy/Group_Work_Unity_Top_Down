using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //save data
    private ItemDict itemDict;

    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount; //32
    public GameObject[] itemPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        itemDict = FindObjectOfType<ItemDict>();


        //-----------------------esto ahora lo hacen las funciones llamadas desde LoadGame(), pero por si acaso lo dejamos comentado----------------------
        //for(int i = 0; i< slotCount; i++)
        //{
        //    Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
        //    if( i < itemPrefabs.Length)
        //    {
        //        GameObject item = Instantiate(itemPrefabs[i], slot.transform);
        //        //centrar
        //        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //        slot.currentItem = item;
        //    }
        //}
    }

    public bool AddItem(GameObject itemPrefab)
    {
        //iterar slots
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();

            //si está vacío metemos el objeto
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; 
                slot.currentItem = newItem;
                return true;
            }
        }

        //si no hay slots disponibles pues na
        return false;

    }

    //getter y setter con truco!

    //Save
    public List<InventorySaveData> GetInventoryItems()
    {
        List<InventorySaveData> inventoryData = new List<InventorySaveData>();

        //rellenar con los slots e item que tengamos
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();

            //si hay item
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                //añadir a la lista  
                inventoryData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }

        return inventoryData;
    }

    //Load
    public void SetInventoryItems(List<InventorySaveData> inventoryData)
    {
        
        //limpiar primero
        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        //volver a colocar slots
        for (int i = 0; i < slotCount; i++)
        {
            
            Instantiate(slotPrefab, inventoryPanel.transform);
        }

        //rellenar slots con objetos del savedata
        foreach(InventorySaveData item in inventoryData)
        {
            if (item.slotIndex < slotCount)
            {
                //daba errores pero era porque el ItemID estaba creado con mayuscula, fixed
                Slot slot = inventoryPanel.transform.GetChild(item.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDict.GetItemPrefab(item.itemID);
                if(itemPrefab != null)
                {
                    GameObject newItem = Instantiate(itemPrefab, slot.transform);
                    //centrar igual que en el script del inventario
                    newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = newItem;
                }

            }
        }
    }

}

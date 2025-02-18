using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string saveLocation;

    // Start is called before the first frame update
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SaveData newSaveData = new SaveData
        {
            playerPosition = Vector3.zero,
            mapBoundary = "Town1",
            inventorySaveData = new List<InventorySaveData>(),
            chestSaveData = new List<ChestSaveData>(),
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(newSaveData));

        SceneManager.LoadScene("InitScene");
    }

    public void Continue()
    {
        SceneManager.LoadScene("InitScene");
    }
}

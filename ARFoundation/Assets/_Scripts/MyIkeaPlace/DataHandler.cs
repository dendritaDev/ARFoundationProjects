using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;

    private int currentId = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }    
    }

    private void Start()
    {
        LoadItems();
        CreateButtons();
    }

    void LoadItems()
    {
        var itemsObject = Resources.LoadAll("Items", typeof(Item)); //Si hicieramos una app real, esto lo sacariamos de informacion en la nube. Ahora mismo esto lo obtiene del Folder Resources
        foreach (var item in itemsObject)
        {
            items.Add(item as Item);
        }
    }

    void CreateButtons()
    {
        foreach (var item in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = currentId;
            b.ButtonTexture = item.itemImage;
            currentId++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }
}

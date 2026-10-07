using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;

    [SerializeField] List<Item> items = new List<Item>();

    [SerializeField] public List<Item> allItems = new List<Item>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance.gameObject);

        allItems.Clear();
        GameObject[] allItemsInScene = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject itemObj in allItemsInScene)
        {
            allItems.Add(itemObj.GetComponent<Item>());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public GameObject TestObject;

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in items)
        {
            if (item != null)
            {
                item.SetTotalStats();
                item.Timer();
                item.CheckTimerAndEffect();
            }
        }
        
        
    }

    [ContextMenu("ITEM TESTING")]
    void TestyTesty()
    {
        Item testItem = TestObject.GetComponent<Item>();
        AddItem(testItem);
    }

    /// <summary>
    /// Adds item to the Item list and increments it if it isn't in there already, in which case it only increments it 
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        if (item != null)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                item.stacks++;
            }
            else
            {
                item.stacks++;
            }
        }
    }
}

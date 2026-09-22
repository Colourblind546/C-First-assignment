using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;

    [SerializeField] List<Item> items = new List<Item>();

    void Awake()
    {
        Instance = this;
        if (Instance != gameObject.GetComponent<ItemManager>())
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public GameObject TestObject;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            Item testItem = TestObject.GetComponent<Item>();
            AddItem(testItem);
        }
        
        foreach (Item item in items)
        {
            item.Timer();
            item.CheckTimerAndEffect();
        }
    }

    [ContextMenu("ITEM TESTING")]
    void TestyTesty()
    {
        Debug.Log("Space was pressed");
        Item testItem = TestObject.GetComponent<Item>();
        AddItem(testItem);
    }

    public void AddItem(Item item)
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

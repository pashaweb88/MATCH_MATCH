using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public int boardWidth;
    public int boardHeight;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ItemSettings[] itemsSO;

    public GameObject[,] boardItems;


    private void Start()
    {
        InitializeBoardItemsList();
        CreateBoard();
    }

    private void InitializeBoardItemsList ()
    {
        boardItems = new GameObject[boardWidth, boardHeight];
    }
    private void CreateBoard()
    {
       BoardIterate(CreateItem);
    }

    private void CreateItem(int x, int y)
    {
        int random = Random.Range(0, itemsSO.Length);
        ItemSettings itemSettings = itemsSO[random];
        GameObject item = Instantiate(itemPrefab, new Vector2(x, y), Quaternion.identity);
        ItemDot itemDot = item.GetComponent<ItemDot>();
        item.GetComponent<SpriteRenderer>().sprite = itemSettings.GetImage();
        item.tag = itemSettings.GetTag();
        item.transform.parent = gameObject.transform;
        itemDot.SetInitPos(new Vector2Int(x, y));
        itemDot.SetBoard(GetComponent<Board>());
        boardItems[x, y] = item;
    }
    private void BoardIterate(Action<int, int> action)
    {
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                action?.Invoke(x, y);
            }
        }
    }
}

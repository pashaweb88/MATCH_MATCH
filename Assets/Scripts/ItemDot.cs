using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    private Vector2Int mainPos;
    private Vector2 firstTouchPos;
    private Vector2 finalTouchPosition;
    private float swipeAngle;
    private Board board;
    public void SetInitPos(Vector2Int pos)
    {
        mainPos = pos;
    }
    public void SetBoard(Board b)
    {
        board = b;
    }
    private void OnMouseDown()
    {
        firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
        MovePieces();
    }

    private void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPos.y, finalTouchPosition.x - firstTouchPos.x) * 180 / Mathf.PI;
    }

    private void MovePieces()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && mainPos.x < board.boardWidth - 1)
        {
            ItemMove(mainPos.x + 1, mainPos.y);// Right.
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && mainPos.y < board.boardHeight - 1)
        {
            ItemMove(mainPos.x, mainPos.y+1);//UP.
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && mainPos.x > 0)
        {
            ItemMove(mainPos.x - 1, mainPos.y);//left.
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && mainPos.y > 0)
        {
            ItemMove(mainPos.x, mainPos.y-1);//Down.
        }

       
    }

    private void GameObject()
    {

    }

    private void ItemMove(int x, int y)
    {
        GameObject item2 = board.boardItems[x, y];
        ItemDot itemDot2 = item2.GetComponent<ItemDot>();

        board.boardItems[mainPos.x, mainPos.y] = item2;
        board.boardItems[x, y] = gameObject;

        itemDot2.mainPos = new Vector2Int(mainPos.x, mainPos.y);
        GetComponent<ItemDot>().mainPos = new Vector2Int(x, y);

        LeanTween.move(gameObject, new Vector2(mainPos.x, mainPos.y), moveSpeed);
        LeanTween.move(item2, new Vector2(itemDot2.mainPos.x, itemDot2.mainPos.y), moveSpeed);

    }
}

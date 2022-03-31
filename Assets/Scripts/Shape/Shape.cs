using UnityEngine;
using System.Collections.Generic;

public class Shape : MonoBehaviour
{
    public GameObject squreShapeImage;

    [HideInInspector]
    public ShapeData currentShapeData;

    private List<GameObject> _currentShape = new List<GameObject>();

    void Start()
    {
        
    }

    private float GetYPositionForShapeSquare(ShapeData shapeData, int row, Vector2 moveDistance)
    {
        float shiftOnY = 0f;

        if(shapeData.rows > 1)
        {
            if(shapeData.rows % 2 != 0)
            {
                var middleSquareIndex = (shapeData.rows - 1) / 2;
                var multiplier = (shapeData.rows - 1) / 2;

                if(row < middleSquareIndex)   // move it on minus
                {
                    shiftOnY = moveDistance.y * 1;
                    shiftOnY *= multiplier;
                }
                else if(row > middleSquareIndex)   // plus
                {
                    shiftOnY = moveDistance.y * -1;
                    shiftOnY *= multiplier;
                }

            }

            else
            {
                var middleSquareIndex2 = (shapeData.rows == 2) ? 1 : (shapeData.rows / 2);
                var middleSquareIndex1 = (shapeData.rows == 2) ? 0 : (shapeData.rows - 2);
                var multiplier  = (shapeData.rows) / 2;

                if(row == middleSquareIndex1 || row == middleSquareIndex2)
                {
                    if(row == middleSquareIndex2)
                    {
                        shiftOnY = (moveDistance.y / 2) * -1;

                    }

                    if (row == middleSquareIndex1)
                    {
                        shiftOnY = (moveDistance.y / 2);

                    }

                    if(row < middleSquareIndex1 && row < middleSquareIndex2)
                    {
                        shiftOnY = moveDistance.y;
                        shiftOnY *= multiplier;
                    }
                    else if(row > middleSquareIndex1 && row > middleSquareIndex2)
                    {
                        shiftOnY = moveDistance.y * -1;
                        shiftOnY *= multiplier;
                    }
                }
            }
        }

        return shiftOnY;
    }


    private float GetXPositionForShapeSquare(ShapeData shapeData, int column, Vector2 moveDistance)
    {
        float shiftOnX = 0f;

        if(shapeData.columns > 1)
        {
            if(shapeData.columns % 2 != 0)
            {
                var middleSquareIndex = (shapeData.columns - 1) / 2;
                var multiplier = (shapeData.columns - 1) / 2;

                if(column < middleSquareIndex)  // move to negative
                {
                    shiftOnX = moveDistance.x * -1;
                    shiftOnX *= multiplier;
                }
                else if(column > middleSquareIndex)
                {
                    shiftOnX = moveDistance.x * 1;
                    shiftOnX *= multiplier;
                }
            }
            else
            {
                var middleSquareIndex2 = (shapeData.columns == 2) ? 1 : (shapeData.columns / 2);
                var middleSquareIndex1 = (shapeData.columns == 2) ? 0 : (shapeData.columns - 1);
                var multipier = shapeData.columns / 2;

                if(column == middleSquareIndex1 || column == middleSquareIndex2)
                {
                    if(column == middleSquareIndex2)
                    {
                        shiftOnX = moveDistance.x / 2;
                    }
                    if(column == middleSquareIndex1)
                    {
                        shiftOnX = moveDistance.x / 2 * -1;
                    }
                }

                if (column < middleSquareIndex1 && column < middleSquareIndex2) // move it on negative
                {
                    shiftOnX = moveDistance.x * -1;
                    shiftOnX *= multipier;
                }
                else if(column > middleSquareIndex1 && column > middleSquareIndex2)
                {
                    shiftOnX = moveDistance.x * 1;
                    shiftOnX *= multipier;
                }
            }
        }
        return shiftOnX;
    }
    private int GetNumberOfSquares(ShapeData shapeData)
    {
        int number = 0;

        foreach(var rowData in shapeData.board)
        {
            foreach(var active in rowData.column)
            {
                if (active)
                {
                    number++;
                }
            }
        }
        return number;
    }
   
}

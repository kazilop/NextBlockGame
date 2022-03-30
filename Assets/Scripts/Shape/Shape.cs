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


    private int GetNumberOfSquares(ShapeData shapeData)
    {
        int number = 0;

        foreach(var rowData in shapeData.board)
        {
            foreach(var active in rowData.column)
            {
                if (active)
                {

                }
            }
        }
        return number;
    }
   
}

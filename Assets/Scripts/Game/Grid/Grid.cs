using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridSquare;
    public Vector2 startPosition = Vector2.zero;
    public float squareScale = 0.5f;
    public float everySquareOffset = 0.0f;

    private Vector2 _offset = Vector2.zero;
    private List<GameObject> _gridSquares = new List<GameObject>();

    void Start()
    {
        CreateGrid();
    }


    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquaresPositions();
    }

    private void SpawnGridSquares()
    {
        int square_index = 0;
        for (var row = 0; row < rows; ++row) 
        { 
            for(var column = 0; column < columns; ++column)
            {
                _gridSquares.Add(Instantiate(gridSquare) as GameObject);
                _gridSquares[_gridSquares.Count - 1].transform.SetParent(this.transform);
                _gridSquares[_gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);

                _gridSquares[_gridSquares.Count - 1].GetComponent<GridSquare>().SetImage(square_index % 2 == 0);

                square_index++;
            }
        }
    }

    private void SetGridSquaresPositions()
    {
        int column_number = 0;
        int row_number = 0;

        Vector2 square_gap_number = Vector2.zero;
        bool row_moved = false;

        var square_rect = _gridSquares[0].GetComponent<RectTransform>();

        _offset.x = square_rect.rect.width * square_rect.transform.localScale.x + everySquareOffset;
        _offset.y = square_rect.rect.height * square_rect.transform.localScale.y + everySquareOffset;

        foreach(GameObject square in _gridSquares)
        {
            if(column_number + 1 > columns)
            {
                square_gap_number.x = 0;
                column_number = 0;
                row_number++;
                row_moved = false;
            }

            var pos_x_offset = _offset.x * column_number + (square_gap_number.x * squaresGap);
            var pos_y_offset = _offset.y * row_number + (square_gap_number.y * squaresGap);

            if(column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += squaresGap;
            }

            if(row_number> 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += squaresGap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + pos_x_offset, 
                startPosition.y - pos_y_offset);

            square.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + pos_x_offset,
                startPosition.y - pos_y_offset, 0f);

            column_number++;

        }
    }

}

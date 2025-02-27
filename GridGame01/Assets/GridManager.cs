using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int numRows = 8;
    [SerializeField] private int numColumns = 8;
    [SerializeField] private Vector2 tileSize = Vector2.one;
    [SerializeField] private Vector2 padding = new Vector2(0.1f, 0.1f);

    private List<GameObject> _tiles = new List<GameObject>();

    void Start() 
    {
        _tiles.Capacity = numRows * numColumns;

        for (int row = 0; row < numRows; row++)
        {
            for(int col = 0; col < numColumns; col++)
            {
                Vector2 pos = new Vector2(col * (tileSize.x + padding.x), row * (tileSize.y + padding.y));
                GameObject tile = Instantiate(_tilePrefab, pos, Quaternion.identity,transform);
                _tiles.Add(tile);
            }
        }
    }

    public GameObject GetTile(int column, int row)
    {
        //Check if coordinate is valid
        if (column < 0 || row < 0 || column >= numColumns || row >= numRows)
        {
            Debug.LogError($"Invalid tile coordinate({column},{row})");
            return null;
        }
        return _tiles[row * numColumns + column];
    }
}

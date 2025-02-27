using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Vector2Int _gridPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _gridPos.x++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _gridPos.x--;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _gridPos.y++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _gridPos.y--;
        }

        //Look up tile at grid position
        GameObject tile = _gridManager.GetTile(_gridPos.x, _gridPos.y);
        //Move worldspace position to match current tile
        transform.position = Vector3.MoveTowards(transform.position, tile.transform.position, 5.0f * Time.deltaTime);
    }
}

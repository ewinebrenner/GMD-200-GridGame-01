using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Vector2Int _gridPos;
    [SerializeField] private float _moveDuration = 0.5f;
    //Built in Ease function
    [SerializeField] private Ease _moveEase = Ease.InOutCubic;
    //Custom ease function
    [SerializeField] private AnimationCurve _moveCurve;
    Tween _moveTween;
    void GoToPosition(Vector2Int pos)
    {
        if (_moveTween != null && _moveTween.IsActive())
            return;

        _gridPos = pos;
        GameObject tile = _gridManager.GetTile(_gridPos.x, _gridPos.y);
        Vector3 targetPos = tile.transform.position;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(targetPos, _moveDuration).SetEase(_moveCurve));
      //  seq.Append(transform.DOPunchScale(Vector3.one * 1.5f, 0.3f));
        _moveTween = seq;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GoToPosition(_gridPos + new Vector2Int(1,0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GoToPosition(_gridPos + new Vector2Int(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GoToPosition(_gridPos + new Vector2Int(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GoToPosition(_gridPos + new Vector2Int(0, -1));
        }

        //Look up tile at grid position

        //Move worldspace position to match current tile
        //  transform.position = Vector3.MoveTowards(transform.position, tile.transform.position, 5.0f * Time.deltaTime);
    }
}

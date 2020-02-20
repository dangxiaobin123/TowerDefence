using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11, 11);

    [SerializeField]
    GameBoard board = default;

    [SerializeField]
    GameTileContentFactory tileContentFactory = default;

    Ray touchRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        board.Initialize(boardSize, tileContentFactory);
        board.ShowGrid = true;
    }
    
    private void OnValidate() {
        boardSize.x = Mathf.Max(boardSize.x, 2);
        boardSize.y = Mathf.Max(boardSize.y, 2);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            HandleTouch();
        }
        else if(Input.GetMouseButtonDown(1)) {
            HandleAlternativeTouch();
        }

        if(Input.GetKeyDown(KeyCode.V)) {
            board.ShowPaths = !board.ShowPaths;
        }

        if(Input.GetKeyDown(KeyCode.G)) {
            board.ShowGrid = !board.ShowGrid;
        }
    }

    void HandleAlternativeTouch()
    {
        GameTile tile = board.GetTile(touchRay);
        if(tile!=null) {
            board.ToggleDestination(tile);
        }
    }

    void HandleTouch()
    {
        GameTile tile = board.GetTile(touchRay);
        if(tile!=null) {
            board.ToggleWall(tile);
        }
    }
}

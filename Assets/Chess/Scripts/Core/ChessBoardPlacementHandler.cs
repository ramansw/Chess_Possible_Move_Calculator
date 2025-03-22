using System;
using UnityEngine;
using Chess.Scripts.Core; 

public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    private GameObject[,] _chessBoard;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake() {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j) => _chessBoard[i, j];

    internal void Highlight(int row, int col) {
        var tile = GetTile(row, col);
        if (tile == null) return;

        var allPieces = FindObjectsOfType<ChessPlayerPlacementHandler>();
        foreach (var piece in allPieces) {
            if (piece.row == row && piece.column == col) return;
        }

        var highlight = Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
        highlight.tag = "Highlight";
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;

                foreach (Transform childTransform in tile.transform) {
                    if (childTransform.CompareTag("Highlight")) {
                        Destroy(childTransform.gameObject);
                    }
                }
            }
        }
    }
}

using Chess.Scripts.Core;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    protected int Row => GetComponent<ChessPlayerPlacementHandler>().row;
    protected int Column => GetComponent<ChessPlayerPlacementHandler>().column;

    public abstract void CalculateLegalMoves();

    protected void HighlightTile(int targetRow, int targetCol) {
        if (!IsValidPosition(targetRow, targetCol)) return;
        var targetTile = ChessBoardPlacementHandler.Instance.GetTile(targetRow, targetCol);

        if (targetTile != null && targetTile.GetComponentInChildren<ChessPlayerPlacementHandler>() == null) {
            ChessBoardPlacementHandler.Instance.Highlight(targetRow, targetCol);
        }
    }

    protected bool IsValidPosition(int row, int col) => row >= 0 && row < 8 && col >= 0 && col < 8;
}

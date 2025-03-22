using UnityEngine;

public class Rook : ChessPiece
{
    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        for (int i = 1; i < 8; i++)
        {
            HighlightTile(Row + i, Column);   // Up
            HighlightTile(Row - i, Column);   // Down
            HighlightTile(Row, Column + i);   // Right
            HighlightTile(Row, Column - i);   // Left
        }
    }
}

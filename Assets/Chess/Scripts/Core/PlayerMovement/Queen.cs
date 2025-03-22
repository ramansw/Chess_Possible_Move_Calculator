using UnityEngine;

public class Queen : ChessPiece
{
    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        // Combine Rook + Bishop logic
        for (int i = 1; i < 8; i++)
        {
            HighlightTile(Row + i, Column);   // Up
            HighlightTile(Row - i, Column);   // down
            HighlightTile(Row, Column + i);   // right
            HighlightTile(Row, Column - i);   // left

            HighlightTile(Row + i, Column + i); 
            HighlightTile(Row + i, Column - i); 
            HighlightTile(Row - i, Column + i); 
            HighlightTile(Row - i, Column - i); 
        }
    }
}

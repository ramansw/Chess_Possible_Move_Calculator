using UnityEngine;

public class Bishop : ChessPiece
{
    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        for (int i = 1; i < 8; i++)
        {
            HighlightTile(Row + i, Column + i); 
            HighlightTile(Row + i, Column - i); 
            HighlightTile(Row - i, Column + i); 
            HighlightTile(Row - i, Column - i); 
        }
    }
}

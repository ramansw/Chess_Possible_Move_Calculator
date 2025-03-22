using UnityEngine;

public class King : ChessPiece
{
    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i != 0 || j != 0) 
                {
                    HighlightTile(Row + i, Column + j);
                }
            }
        }
    }
}

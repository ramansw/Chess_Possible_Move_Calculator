using UnityEngine;

public class Pawn : ChessPiece
{
    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        HighlightTile(Row + 1, Column); // Forward 1 step
        if (Row == 1) HighlightTile(Row + 2, Column); // First-move 2 steps
    }
}

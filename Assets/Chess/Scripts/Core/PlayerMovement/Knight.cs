using UnityEngine;

public class Knight : ChessPiece
{
    private readonly int[,] moves = {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
    };

    public override void CalculateLegalMoves()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        for (int i = 0; i < moves.GetLength(0); i++)
        {
            HighlightTile(Row + moves[i, 0], Column + moves[i, 1]);
        }
    }
}

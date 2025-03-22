using UnityEngine;

public class PieceSelectionManager : MonoBehaviour
{
    private ChessPiece selectedPiece;
    private GameObject selectionHighlight;

    [SerializeField] private GameObject selectionHighlightPrefab;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SelectPiece();
        }
    }

    void SelectPiece() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (selectionHighlight != null) {
            Destroy(selectionHighlight);
        }

        if (hit.collider != null) {
            var piece = hit.collider.GetComponent<ChessPiece>();
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            if (piece != null) {
                selectedPiece = piece;
                selectedPiece.CalculateLegalMoves();

                selectionHighlight = Instantiate(
                    selectionHighlightPrefab,
                    selectedPiece.transform.position,
                    Quaternion.identity,
                    selectedPiece.transform
                );
            }
        }
    }
}

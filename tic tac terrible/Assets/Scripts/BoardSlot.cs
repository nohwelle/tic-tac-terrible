using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardSlot : MonoBehaviour
{
    public LayerMask slotLayer;
    public BoxCollider boxCollider;

    bool started;

    public int occupiedBy; // 0 = unoccupied, 1 = player 1, 2 = player 2

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = true;

        Collider2D hit = Physics2D.OverlapBox(transform.position, boxCollider.size / 2, 0, slotLayer);

        if (hit)
        {
            print($"{name} collided with: " + hit.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (started)
        {
            Gizmos.DrawWireCube(Board.Instance.boardSlots[0].transform.position, boxCollider.size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider[] hit = Physics.OverlapSphere(clickPosition, GameManager.Instance.clickRadius, slotLayer);

            if (hit.Length != 0 && hit[0].gameObject == gameObject)
            {
                OccupySlot();
            }
        }
    }

    void OccupySlot() // this is the same as saying who owns what piece (doesn't matter since it's really about the slots)
    {
        if (!GameManager.Instance.isPlayerTwosTurn && occupiedBy == 0)
        {
            occupiedBy = 1;
            Instantiate(GameManager.Instance.playerOnePiece, transform);
        }
        if (GameManager.Instance.isPlayerTwosTurn && occupiedBy == 0)
        {
            occupiedBy = 2;
            Instantiate(GameManager.Instance.playerTwoPiece, transform);
        }

        // update the board -- tell the Board script which slot something was just placed in, then check for any connect-3s
        /*for (var i = 0; i < Board.Instance.boardSlots.Count; i++)
        {
            if (Board.Instance.boardSlots[i] == this)
            {
                Board.Instance.CheckBoardSlots(i);
                break;
            }
        }*/
    }
}

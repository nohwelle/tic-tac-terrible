using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTwosTurn;

    public GameObject playerOnePiece;
    public GameObject playerTwoPiece;

    public Text gameStateText;

    public float clickRadius = 0.01f;
    public int gameWinner;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

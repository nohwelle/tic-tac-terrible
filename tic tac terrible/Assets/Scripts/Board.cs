using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<BoardSlot> boardSlots;

    public static Board Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (BoardSlot slot in FindObjectsOfType<BoardSlot>())
        {
            boardSlots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckBoardSlots(int index)
    {

    }
}

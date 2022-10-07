using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{

    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float turnDuration;
    [SerializeField] private float turnDelay;
    [SerializeField] private float matchTime;

   

    private static TurnManager instance;
    private float currentTurnTime;
    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float currentMatchTime;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 2;
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }
        return index == currentPlayerIndex;
    }
    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {

        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
                currentTurnTime = 0;
            }
        }

        currentTurnTime += Time.deltaTime;

        currentMatchTime += Time.deltaTime;

        if (currentTurnTime >= turnDuration)
        {
            TriggerChangeTurn();

        }

        if (currentMatchTime >= matchTime)
        {
            SceneManager.LoadSceneAsync(1);
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            TriggerChangeTurn();
        } 
    }

   
   
}

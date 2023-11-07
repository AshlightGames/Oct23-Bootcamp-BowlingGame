using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Pin[] pins;

    private bool isGameplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameplaying = true;
        //Get the first throw
        player.StartThrow();
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }

    void NextThrow()
    {
        if(scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over. Your total score is: {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame{scoreManager.currentFrame} - Throw{scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());
            Debug.Log($"current score: {scoreManager.CalculateTotalScore()}");

            player.StartThrow();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;

        foreach (Pin pin in pins) 
        { 
         if(pin.isFallen && pin.gameObject.activeSelf)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }
        Debug.Log($"Total Fallen pins = {count}");
        return count;
    }
    
    public void ResetAllPins()
    {
        foreach (Pin pin in pins) 
        {
            pin.ResetPin();
        }
    }
    

}

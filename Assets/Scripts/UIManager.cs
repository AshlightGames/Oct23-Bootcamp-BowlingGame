using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Transform frameHolder;
    [SerializeField] private GameObject messageUIStrike, messageUISpare, gameOverUI;
    [SerializeField] private TMP_Text ScoreText;

    private FrameUI[] frames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

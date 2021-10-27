using System.Collections;
using System.Collections.Generic;
using Tabtale.TTPlugins;
using UnityEngine;
using UnityEngine.UI;


public class StartStopAnims : MonoBehaviour
{
    private void Awake()
    {
        // Initialize CLIK Plugin
        TTPCore.Setup();
        // Your code here
    }
    
    [SerializeField] private Animator hırsızAnimator;
    [SerializeField] private Animator polisAnimator;
    [SerializeField] private Animator hanimAnimator;
    [SerializeField] private PolicePatrol _policePatrol; 

    [Header("Slider")]
    public Slider slider;
    public Image fill;
    [SerializeField] private int currentValue = 0;
    [SerializeField] private int maxValue = 1000;

   

    [SerializeField] private GameObject[] goldPieces = new GameObject[8];

    [Header("ExclamationMark")]
    [SerializeField] private GameObject exclamationMark;
    private float exclamationMarkValue = 0f;


    [SerializeField] private GameObject failCanvas;
    [SerializeField] private GameObject winCanvas;


    [Header("HideGoldRelated")]
    private int i = 3;
    private int nextGoldToHideIndex = 0;
    private float gameTime = 0;

    
    void Start()
    {
        hırsızAnimator.SetBool("idle", false);
    }
    
   
    private void FixedUpdate()
    {
        
       gameTime = gameTime + Time.fixedDeltaTime;

       HideGold();
    }

    private void HideGold()
    {
        while (gameTime > i)
        {
            goldPieces[nextGoldToHideIndex].SetActive(false);
            i = i + 2;
            nextGoldToHideIndex++;
        }
        if(nextGoldToHideIndex >= 8)
        {
            hırsızAnimator.SetBool("idle", true);
        }
    }
    

    private void OpenWinCanvas()
    {
        if(currentValue >= 100)
        {
            winCanvas.SetActive(true);
        }
    }
}

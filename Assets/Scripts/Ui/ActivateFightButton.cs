using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFightButton : MonoBehaviour
{
    [SerializeField]
    private IntVariable attackScore;
    [SerializeField]
    private IntVariable protectScore;
    [SerializeField]
    private BoolVariable playersBool;
    [SerializeField]
    private BoolVariable opponentsBool;
    [SerializeField]
    private GameObject startBattleButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (protectScore.value == 0 && attackScore.value == 0)
        {
            startBattleButton.SetActive(true);
        }
        else
        {
            startBattleButton.SetActive(false);
        }
    }
    public void Activate()
    {
        playersBool.value = true;
    }
}

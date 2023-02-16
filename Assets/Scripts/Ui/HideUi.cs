using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToHide;
    void Start()
    {
        FightState.OnEnterFightStage += Hide;
        PreparationState.OnplayerSentData += Hide;
    }

    private void OnDisable()
    {
        FightState.OnEnterFightStage -= Hide;
        PreparationState.OnplayerSentData -= Hide;
    }
    public void Hide()
    {
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }
}

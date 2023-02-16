using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private IntVariable timer;

    void Start()
    {
        PreparationState.OnEnterPrepStage += StartCountdown;
    }

    private void OnDisable()
    {
        PreparationState.OnEnterPrepStage -= StartCountdown;
    }

    void StartCountdown()
    {
        StartCoroutine(countdown());
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        timer.value--;
        if (timer.value == 0)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(countdown());
        }

    }
}

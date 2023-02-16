using UnityEngine;
using Photon.Pun;

public class OpponentSelector : MonoBehaviourPun, ISelector
{
    [SerializeField]
    private IntVariable attackScore;

    [SerializeField]
    private IntArray playerAttacks;

    public void SelectPart(int index)
    {
        if (attackScore.value > 0)
        {
            playerAttacks.value[index]++;
            attackScore.value--;
        }
    }
    public void UnSelectPart(int index)
    {
        playerAttacks.value[index]--;
        attackScore.value++;
    }

}

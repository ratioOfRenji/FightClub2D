using UnityEngine;
using Photon.Pun;

public class PlayerSelector : MonoBehaviourPun, ISelector
{
    [SerializeField]
    private IntVariable protectScore;

    [SerializeField]
    private BoolArray playerProtectedParts;


    public void SelectPart(int index)
    {
        if (!playerProtectedParts.value[index] && protectScore.value > 0)
        {
            playerProtectedParts.value[index] = true;
            protectScore.value--;
        }
    }
    public void UnSelectPart(int index)
    {
        playerProtectedParts.value[index] = false;
        protectScore.value++;
    }
}

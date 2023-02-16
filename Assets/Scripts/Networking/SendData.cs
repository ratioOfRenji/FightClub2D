using UnityEngine;
using Photon.Pun;

public class SendData : MonoBehaviour
{

    [SerializeField]
    private IntArray playersAttacks;
    [SerializeField]
    private BoolArray playersProtectedParts;
    [SerializeField]
    private BoolVariable playersBool;

    void Start()
    {
        FightState.OnEnterFightStage += SendHPAndProtectionData;
        PreparationState.OnplayerSentData += SendHPAndProtectionData;
    }

    private void OnDisable()
    {
        FightState.OnEnterFightStage -= SendHPAndProtectionData;
        PreparationState.OnplayerSentData -= SendHPAndProtectionData;
    }
    public void SendHPAndProtectionData()
    {
        playersBool.value = true;
        PhotonView photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveHPAndProtectionData", RpcTarget.Others, playersAttacks.value, playersProtectedParts.value, playersBool.value);
    }
}

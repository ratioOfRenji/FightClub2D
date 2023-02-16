using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Matchmaking : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined or created a room");
        SceneManager.LoadScene("MultiplayerScene");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
}

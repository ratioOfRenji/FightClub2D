using UnityEngine;
using Photon.Pun;

public class OpponentOnline : MonoBehaviourPun
{
    [SerializeField]
    private int attacksRemained = 4;

    [SerializeField]
    private int opponentsHealth = 10;

    public int AttacksRemained { get { return attacksRemained; } }
    public int OpponentsHealth { get { return opponentsHealth; } set { opponentsHealth = value; } }

    public IntArray playerAttacks;
    private void Start()
    {
        playerAttacks.value = new int[8];
    }

    public void MakeAttack(int index)
    {
        if (attacksRemained > 0)
        {
            playerAttacks.value[index]++;
            attacksRemained--;
        }
    }
    public void CancelAttack(int index)
    {
        playerAttacks.value[index]--;
        attacksRemained++;
    }

}

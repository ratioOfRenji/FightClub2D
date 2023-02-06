using UnityEngine;
using TMPro;

public class CalculateDamageOnline : MonoBehaviour
{
    public PlayerOnline player;
    public OpponentOnline oponent;
    public TMP_Text playerHp;
    public TMP_Text opponentHp;
    public Hp playerHealth;
    public Hp oponentHealth;
    public BoolArray playerProtectedParts;
    public BoolArray opponentProtectedParts;
    public IntArray playerAttacks;
    public IntArray opponentsAttacks;

    private void Start()
    {
        playerHp.text = playerHealth.value.ToString();
        opponentHp.text = oponentHealth.value.ToString();
    }
    public int CalculateSum(bool[] boolArray, int[] intArray)
    {
        int sum = 0;
        for (int i = 0; i < boolArray.Length; i++)
        {
            if (!boolArray[i])
            {
                sum += intArray[i];
            }
        }
        return sum;
    }
    public void Calclate()
    {
        CalculatePlayersDamage();
        CalculateOpponentDamage();
    }
    public void CalculatePlayersDamage()
    {
        playerHealth.value -= CalculateSum(playerProtectedParts.value, opponentsAttacks.value);
        playerHp.text = playerHealth.value.ToString();
    }
    public void CalculateOpponentDamage()
    {
        oponentHealth.value -= CalculateSum(opponentProtectedParts.value, playerAttacks.value);
        opponentHp.text = oponentHealth.value.ToString();
    }
}

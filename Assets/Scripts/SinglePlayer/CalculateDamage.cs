using UnityEngine;
using TMPro;

public class CalculateDamage : MonoBehaviour
{
    public Player player;
    public Oponent oponent;
    public TMP_Text playerHp;
    public TMP_Text opponentHp;
    public Hp playerHealth;
    public Hp oponentHealth;

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
    
    public void CalculatePlayersDamage()
    {
        playerHealth.value -=CalculateSum(player.protectedParts, player.playerHitsArray);
        playerHp.text = playerHealth.value.ToString();
    }
    public void CalculateOpponentDamage()
    {
        oponentHealth.value -= CalculateSum(oponent.zonesToDefence, oponent.zonesToAttack);
        opponentHp.text = oponentHealth.value.ToString();
    }
}

using UnityEngine;
using System.Collections;

public class CalculateDamageOnline : MonoBehaviour
{
    [SerializeField]
    private IntVariable playerHealth;
    [SerializeField]
    private IntVariable oponentHealth;
    [SerializeField]
    private BoolArray playerProtectedParts;
    [SerializeField]
    private BoolArray opponentProtectedParts;
    [SerializeField]
    private IntArray playerAttacks;
    [SerializeField]
    private IntArray opponentsAttacks;

    private void Start()
    {
        FightState.OnNextFightLoop += Calclate;
    }

    private void OnDisable()
    {
        FightState.OnNextFightLoop -= Calclate;
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
        //StartCoroutine(CalculateDmg());
    }
    public void CalculatePlayersDamage()
    {
        playerHealth.value -= CalculateSum(playerProtectedParts.value, opponentsAttacks.value);
    }
    public void CalculateOpponentDamage()
    {
        oponentHealth.value -= CalculateSum(opponentProtectedParts.value, playerAttacks.value);
    }
    IEnumerator CalculateDmg()
    {
        yield return new WaitForSeconds(1);
        Debug.Log(CalculateSum(opponentProtectedParts.value, playerAttacks.value));
        CalculatePlayersDamage();
        CalculateOpponentDamage();
    }
}

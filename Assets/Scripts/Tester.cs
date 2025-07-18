using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] CardSO testCard;
    private void Start()
    {
        RaritySelector.PrintRarityWeights();

        if (testCard == null)
        {
            Debug.LogWarning("[TESTER] - Assign a CardSO in the Inspector");
            return;
        }

        CardData original = testCard.ToCardData();
        CardData clone1 = CardData.CloneWithNewGuid(original);
        CardData clone2 = CardData.CloneWithNewGuid(original);

        Debug.Log($"[TESTER] - Original instance ID is: {original.CardInstanceId} Card Name is: {original.CardName}");
        Debug.Log($"[TESTER] - Clone1 instance ID is: {clone1.CardInstanceId} Card Name is: {clone1.CardName}");
        Debug.Log($"[TESTER] - Clone2 instance ID is: {clone2.CardInstanceId} Card Name is: {clone2.CardName}");

        Debug.Log($"[TESTER] - Clone1 == Clone2? {clone1.CardInstanceId} == {clone2.CardInstanceId}");
    }
}

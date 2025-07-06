using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CardDisplayer : MonoBehaviour
{
    [SerializeField] private Image cardP1;
    [SerializeField] private Image cardFrame;
    [SerializeField] private Image cardP2;
    [SerializeField] private Image cardBg;
    
    [SerializeField] private TextMeshProUGUI cardName;

    public void DisplayCard(CardData data)
    {
        cardName.text = data.CardName;

        TakeAddressables(data.CardP1Path, cardP1, data.CardP1MatPath);
        TakeAddressables(data.CardFramePath, cardFrame);
        TakeAddressables(data.CardP2Path, cardP2);
        TakeAddressables(data.CardBgPath, cardBg, data.CardBgMatPath);
    }

    private void TakeAddressables(string cardPiecePath, Image cardPieceImage, string cardPieceMatPath = null)
    {
        Addressables.LoadAssetAsync<Sprite>(cardPiecePath).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                cardPieceImage.sprite = handle.Result;
                Debug.Log($"{cardPieceImage.name} from {cardPiecePath} is correctly loaded!");
            }
            else
            {
                Debug.LogError($"{cardPieceImage.name} from {cardPiecePath} failed to load!");
            }
        };

        if (!string.IsNullOrEmpty(cardPieceMatPath))//Se la stringa non è vuota o null
        {
            Addressables.LoadAssetAsync<Material>(cardPieceMatPath).Completed += matHandle =>
            {

                if (matHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    cardPieceImage.material = matHandle.Result;
                    Debug.Log($"{cardPieceImage.name} material from {cardPieceMatPath} loaded.");
                }
                else
                {
                    Debug.LogError($"{cardPieceImage.name} material from {cardPieceMatPath} failed.");
                }
            };
        }
    }
}

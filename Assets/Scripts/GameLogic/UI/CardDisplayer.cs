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
    private Material cardP1Mat;
    private Material cardFrameMat;
    private Material cardP2Mat;
    private Material cardBgMat;
    
    [SerializeField] private TextMeshProUGUI cardName;

    public void DisplayCard(CardData data)
    {
        cardName.text = data.CardName;

        TakeAddressables(data.CardP1Path, cardP1, cardP1Mat);
        TakeAddressables(data.CardFramePath, cardFrame);
        TakeAddressables(data.CardP2Path, cardP2, cardP2Mat);
        TakeAddressables(data.CardBgPath, cardBg);
    }

    private void TakeAddressables(string cardPiecePath, Image cardPieceImage, Material cardPieceMat = null)
    {
        Addressables.LoadAssetAsync<Sprite>(cardPiecePath).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                cardPieceImage.sprite = handle.Result;
                Debug.Log($"{cardPieceImage.name} from {cardPiecePath} is correctly loaded!");

                if (cardPieceMat != null)
                {
                    cardPieceImage.material = cardPieceMat;
                    Debug.Log($"{cardPieceImage.name} received material {cardPieceMat.name}");
                }

            }
            else
            {
                Debug.LogError($"{cardPieceImage.name} from {cardPiecePath} failed to load!");
            }
        }; 
    }
}

using UnityEngine.UI;
using UnityEngine;

public class CardDisplayer : MonoBehaviour
{
    [SerializeField] private Image cardP1;
    [SerializeField] private Image cardFrame;
    [SerializeField] private Image cardP2;
    [SerializeField] private Image cardBg;

    public async void DisplayCard(CardData data, AssetsLoader assetsLoader)
    {
        if (data == null)
        {
            Debug.LogError("[CardDisplayer - DisplayCard] CardData is null!");
            return;
        }

        if (assetsLoader == null)
        {
            Debug.LogError("[CardDisplayer - DisplayCard] AssetsLoader is null!");
            return;
        }

        if (string.IsNullOrEmpty(data.CardP1Path))
        {
            Debug.LogError("[CardDisplayer - DisplayCard] CardP1Path is null or empty!");
            return;
        }

        if (string.IsNullOrEmpty(data.CardFramePath))
        {
            Debug.LogError("[CardDisplayer - DisplayCard] CardFramePath is null or empty!");
            return;
        }

        if (string.IsNullOrEmpty(data.CardP2Path))
        {
            Debug.LogError("[CardDisplayer - DisplayCard] CardP2Path is null or empty!");
            return;
        }

        if (string.IsNullOrEmpty(data.CardBgPath))
        {
            Debug.LogError("[CardDisplayer - DisplayCard] CardBgPath is null or empty!");
            return;
        }


        Sprite loadedP1Sprite = await assetsLoader.LoadSpriteAsync(data.CardP1Path);
        Sprite loadedFrameSprite = await assetsLoader.LoadSpriteAsync(data.CardFramePath);
        Sprite loadedP2Sprite = await assetsLoader.LoadSpriteAsync(data.CardP2Path);
        Sprite loadedBgSprite = await assetsLoader.LoadSpriteAsync(data.CardBgPath);

        Material loadedP1Material = await assetsLoader.LoadMaterialAsync(data.CardP1MatPath);
        Material loadedFrameMaterial = await assetsLoader.LoadMaterialAsync(data.CardFrameMatPath);
        Material loadedP2Material = await assetsLoader.LoadMaterialAsync(data.CardP2MatPath);
        Material loadedBgMaterial = await assetsLoader.LoadMaterialAsync(data.CardBgMatPath);

        //SPRITES ASSIGN

        AssignImage(cardP1, loadedP1Sprite, "P1");
        AssignImage(cardFrame, loadedFrameSprite, "Frame");
        AssignImage(cardP2, loadedP2Sprite, "P2");
        AssignImage(cardBg, loadedBgSprite, "Background");

        //MATERIALS ASSIGN

        AssignMaterial(cardP1, loadedP1Material, "P1");
        AssignMaterial(cardFrame, loadedFrameMaterial, "Frame");
        AssignMaterial(cardP2, loadedP2Material, "P2");
        AssignMaterial(cardBg, loadedBgMaterial, "Background");
    }

    private void AssignImage(Image target, Sprite sprite, string name)
    {
        if (target == null)
        {
            Debug.LogError($"{name} Image component is not assigned!");
            return;
        }
        if (sprite != null)
        {
            target.sprite = sprite;
        }
        else
        {
            Debug.LogWarning($"{name} sprite failed to load!"); ;
        }
    }

    private void AssignMaterial(Image target, Material material, string name)
    {
        if (target == null)
        {
            Debug.LogError($"{name} Image component is not assigned!");
            return;
        }
        if (material != null)
        {
            target.material = material;
        }
        else
        {
            Debug.LogWarning($"{name} material failed to load!"); ;
        }
    }
}


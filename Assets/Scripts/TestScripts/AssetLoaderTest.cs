using UnityEngine;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class AssetLoaderTest : MonoBehaviour
{
    private AssetsLoader _assetsLoader;

    [SerializeField] private string spritePath;
    [SerializeField] private string materialPath;

    [SerializeField] private Image testRenderer;
    [SerializeField] private bool triggerReload;

    private async void Start()
    {

        _assetsLoader = new AssetsLoader(CacheManager.instance);

        await TestLoading();
    }
    private void Update()
    {
        if (triggerReload)
        {
            triggerReload = false;
            _ = TestLoading(); // Fire and forget
            Debug.Log("[DEBUG] Reload triggered.");
        }
    }

    private async Task TestLoading()
    {
        Sprite loadedSprite = await _assetsLoader.LoadSpriteAsync(spritePath);
        Material loadedMaterial = await _assetsLoader.LoadMaterialAsync(materialPath);

        if (testRenderer != null)
        {
            testRenderer.sprite = loadedSprite;
            testRenderer.material = loadedMaterial;

            Debug.Log($"[APPLY] Sprite: {spritePath}, Material: {materialPath} applied to testRenderer.");

        }
    }
}

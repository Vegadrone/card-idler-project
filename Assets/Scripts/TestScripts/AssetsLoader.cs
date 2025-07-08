using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsLoader
{
    CacheManager _cacheManager;

    public AssetsLoader(CacheManager cacheManager)
    {
        _cacheManager = cacheManager;
    }

    public async Task<Sprite> LoadSpriteAsync(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogWarning("[LOAD] Sprite path is null or empty.");
            return null;
        }
            
        Debug.Log($"[LOAD] Request to load sprite with path: {path}");

        if (_cacheManager.TryGetSprite(path, out Sprite cachedSprite))
        {
            Debug.Log($"[CACHE] Sprite '{path}' retrieved from cache.");
            return cachedSprite;
        }
    
        var handle = Addressables.LoadAssetAsync<Sprite>(path);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            _cacheManager.AddSprite(path, sprite);
            Debug.Log($"[ADDRESSABLES] Sprite '{path}' loaded and cached.");
            return sprite;
        }
        Debug.LogError($"[ERROR] Failed to load sprite at path: {path}");
        return null;
    }

    public async Task<Material> LoadMaterialAsync(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogWarning("[LOAD] Material path is null or empty.");
            return null;
        }

        if (_cacheManager.TryGetMaterial(path, out Material cachedMaterial))
        {
            Debug.Log($"[CACHE] Material '{path}' retrieved from cache.");
            return cachedMaterial;
        }

        var handle = Addressables.LoadAssetAsync<Material>(path);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Material material = handle.Result;
            _cacheManager.AddMaterial(path, material);
            Debug.Log($"[ADDRESSABLES] Material '{path}' loaded and cached.");
            return material;
        }

        Debug.LogError($"[ERROR] Failed to load material path at {path}");
        return null;
    }
}


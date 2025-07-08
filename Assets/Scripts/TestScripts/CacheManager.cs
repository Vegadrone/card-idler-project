using System.Collections.Generic;
using UnityEngine;

public class CacheManager
{
    public static CacheManager _instance;
    /* ??= is equal to  this
    if (variable == null)
    {
        variable = value;
    }*/
    public static CacheManager instance => _instance ??= new CacheManager();
    Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();
    Dictionary<string, Material> materialCache = new Dictionary<string, Material>();
    

    public bool TryGetSprite(string spritePath, out Sprite sprite)
    {
        if (spriteCache.TryGetValue(spritePath, out sprite)) //TryToGetValue it's a function for dictionaries
        {
            return true; //Found it in cache
        }
        sprite = null;
        return false; //Not found it
    }

    public void AddSprite(string spritePath, Sprite sprite)
    {
        if (string.IsNullOrEmpty(spritePath)) return;
        if (sprite == null) return;
        if (!spriteCache.ContainsKey(spritePath))
        {
            spriteCache.Add(spritePath, sprite);
            Debug.Log($"[CACHE] Sprite '{spritePath}' added to cache.");
        }
    }


    public bool TryGetMaterial(string materialPath, out Material material)
    {
        if (materialCache.TryGetValue(materialPath, out material)) //TryToGetValue it's a function for dictionaries
        {
            return true; //Found it in cache
        }
        material = null;
        return false; //Not found it
    }

    public void AddMaterial(string materialPath, Material material)
    {
        if (string.IsNullOrEmpty(materialPath)) return;
        if (material == null) return;
        if (!materialCache.ContainsKey(materialPath))
        {
            materialCache.Add(materialPath, material);
            Debug.Log($"[CACHE] Material '{materialPath}' added to cache.");
        }
    }
}

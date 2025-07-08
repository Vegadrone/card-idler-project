using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableTestLoader : MonoBehaviour
{
    [SerializeField] private string cardP1Address;
    [SerializeField] private Image targetImage;

    private void Start()
    {
        Addressables.LoadAssetAsync<Sprite>(cardP1Address).Completed += OnSpriteLoaded;
    }

    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            targetImage.sprite = handle.Result;
            Debug.Log("Sprite loaded and assigned");
        }
        else
        { 
            Debug.LogError("Failed to load sprite");
        }
    }
}

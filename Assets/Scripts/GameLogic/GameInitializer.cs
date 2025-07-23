using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"[GameInitializer - Awake] Bootstrapping systems...");
        var init = CollectionManager.Instance;
    }
}

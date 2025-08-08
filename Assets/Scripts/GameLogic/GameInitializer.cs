using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"[GameInitializer - Awake] Bootstrapping systems...");
        var initCollection = CollectionManager.Instance;
        var initSetProgress = SetProgressManager.Instance;
    }

    private void Start()
    {
        Application.runInBackground = true;
    }
}

using UnityEngine;

public class ViewerDebugger : MonoBehaviour
{
    [SerializeField] private string cardIdToSearch;
    void Update()
    {
        Debug.Log(CardDatabaseManager.Instance.GetCardSOById(cardIdToSearch).CardName);
    }
}

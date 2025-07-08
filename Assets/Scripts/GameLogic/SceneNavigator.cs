using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    private string shop = "Shop";
    private string collection = "Collection";
    private string exposer = "Exposer";

    public void GoToShop()
    {
        SceneManager.LoadScene(shop);
    }
    public void GoToExposer()
    {
        SceneManager.LoadScene(exposer);
    }
    public void GoToCollection()
    {
        SceneManager.LoadScene(collection);
    }

    public void QuitApplication()
    {
        Application.Quit(); 
    }

}

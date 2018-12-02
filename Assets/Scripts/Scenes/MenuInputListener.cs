using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInputListener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(Constants.Scenes.Level1.ToString());
        }
    }
}
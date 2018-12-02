using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInputListener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(Constants.Scene.Level1.ToString());
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInputListener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);            
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FMODMusicPlayer.GetDontDestroyOnLoadReference().SetParameter(ParametersListEnum.Parameters.StartMainSong, 1);
            SceneManager.LoadScene(Constants.Scenes.WorldMap.ToString());
        }
    }
}
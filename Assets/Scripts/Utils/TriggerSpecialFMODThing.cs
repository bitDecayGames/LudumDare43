using UnityEngine;

namespace Utils {
    public class TriggerSpecialFMODThing : MonoBehaviour {

        public void PressedStart() {
            FMODMusicPlayer.GetDontDestroyOnLoadReference().SetParameter(ParametersListEnum.Parameters.StartMainSong, 1f);
        }

        public void PressedCredits() {
            FMODMusicPlayer.GetDontDestroyOnLoadReference().SetParameter(ParametersListEnum.Parameters.StartMainSong, 1f);
        }
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string LEVEL_KEY = "level_unlocked_";
	const string HIGHSCORE_KEY = "high_score";
	const string PLAYER_NAME_KEY = "player_name";
	const string CURRENT_SCORE_KEY = "current_score";
	
	public static void SetMasterVolume (float volume){
		if (volume >=0f && volume <=1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings -1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1);
		} else {
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	
	public static bool IsLevelUnocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue ==1);

		if (level <= SceneManager.sceneCountInBuildSettings -1){
			return isLevelUnlocked;
		} else {
			Debug.LogError("Trying to query level not in build order");
			return false;
		}	
	}


	public static void SetHighScore (int score){
		if (score >=0 && score <=300){
			PlayerPrefs.SetInt (HIGHSCORE_KEY, score);
		} else {
			Debug.LogError("Score out of range");
		}
	}

	public static int GetHighScore (){
		return PlayerPrefs.GetInt (HIGHSCORE_KEY);
	}

	public static void SetPLayerName (string name){
		PlayerPrefs.SetString (PLAYER_NAME_KEY, name);
	}
	
	public static string GetPlayerName (){
		return PlayerPrefs.GetString (PLAYER_NAME_KEY);
	}

	public static void SetCurrentScore (int score){
		if (score >=0 && score <=300){
			PlayerPrefs.SetInt (CURRENT_SCORE_KEY, score);
		} else {
			Debug.LogError("Score out of range");
		}
	}

	public static int GetCurrentScore (){
		return PlayerPrefs.GetInt (CURRENT_SCORE_KEY);
	}

}

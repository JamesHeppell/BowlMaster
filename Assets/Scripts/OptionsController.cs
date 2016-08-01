using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Text highScore;
	public LevelManager levelManager;
	public InputField playerName;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		playerName.text = PlayerPrefsManager.GetPlayerName();
		//playerName.text = PlayerPrefsManager.GetPlayerName();
		highScore.text = PlayerPrefsManager.GetHighScore().ToString();

	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume (volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetHighScore (int.Parse(highScore.text));
		PlayerPrefsManager.SetPLayerName (playerName.text);

		levelManager.LoadLevel ("01a Start");
	}
	
	public void SetDefaults(){
		volumeSlider.value=0.8f;
		playerName.text = "Unknown";
		highScore.text ="0";

	}
}

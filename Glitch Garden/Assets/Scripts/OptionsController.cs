using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	public Slider difficultySlider;
	public Slider volumeSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start ()
	{
		musicManager = FindObjectOfType<MusicManager> ();
		volumeSlider.onValueChanged.AddListener (delegate {
			musicManager.ChangeVolume (volumeSlider.value);
		});
		LoadPrefs ();
	}

	void LoadPrefs ()
	{
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}

	public void OnSaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty ((int) difficultySlider.value);
		levelManager.LoadLevel ("01a Start");
	}

	public void OnSetDefaults() {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2;
	}
}

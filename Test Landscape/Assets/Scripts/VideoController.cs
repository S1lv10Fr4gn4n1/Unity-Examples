using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {

	public void PlayVideo() {
		// file must be places on StreamingAssets folder
		Handheld.PlayFullScreenMovie("Caminandes-3-Llamigos.mp4", Color.black, FullScreenMovieControlMode.Minimal);
//		Handheld.PlayFullScreenMovie("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4", Color.black, FullScreenMovieControlMode.Minimal);
	}
}

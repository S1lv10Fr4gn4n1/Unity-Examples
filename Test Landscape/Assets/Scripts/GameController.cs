using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private readonly float tileSize = 11.30f;
	private readonly float topPosition = 0.57f;
	private readonly float offsetCameraMovement = 35f;

	private List<Tile> tiles = new List<Tile>();
	private List<GameObject> prefabTiles = new List<GameObject>();
	private float trueHeading = 0f;

	public GameObject animal;
	public Text textDebug;

	// Use this for initialization
	void Start() {
		Init();
		PlaceAnimal();
		StartScenario();
	}

	void Update() {
		float trueHeadingTemp = getTrueHeading();
		float diffTrueHeading = trueHeadingTemp - trueHeading;
		float absDiffTrueHeading = Mathf.Abs(diffTrueHeading);

		UpdateDebugText(diffTrueHeading);
//		Debug.Log("trueHeading " + trueHeading + ", diff: " + diffTrueHeading);

		if (absDiffTrueHeading < offsetCameraMovement) {
			return;
		}

		UpdateScenario(diffTrueHeading);
		trueHeading = trueHeadingTemp;
	}

	void OnDestroy() {
		Input.compass.enabled = false;
	}

	void Init() {
		Input.compass.enabled = true;

		trueHeading = getTrueHeading();

		prefabTiles.Add(Resources.Load<GameObject>("tile1"));
		prefabTiles.Add(Resources.Load<GameObject>("tile2"));
	}

	void UpdateDebugText(float diffTrueHeading) {
		textDebug.text = "trueHeading: " + getTrueHeading() + "\ndiff: " + diffTrueHeading;
	}

	void UpdateScenario(float diffTrueHeading) {
		if (diffTrueHeading < 0) {
			SwichTileToLeft();
		} else {
			SwitchTileToRight();
		}
	}

	void SwichTileToLeft() {
		Tile tile = tiles[tiles.Count - 1];
		tiles.RemoveAt(tiles.Count - 1);

		Tile tileAux = tiles[0];

		float positionX = tileAux.gameObject.transform.position.x - tileSize;
		tile.gameObject.transform.position = new Vector3(positionX, tile.gameObject.transform.position.y, tile.gameObject.transform.position.z);
		tile.trueHeading = getTrueHeading();

		tiles.Insert(0, tile);
	}

	void SwitchTileToRight() {
		Tile tile = tiles[0];
		tiles.RemoveAt(0);

		Tile tileAux = tiles[tiles.Count - 1];

		float positionX = tileAux.gameObject.transform.position.x + tileSize;
		tile.gameObject.transform.position = new Vector3(positionX, tile.gameObject.transform.position.y, tile.gameObject.transform.position.z);
		tile.trueHeading = getTrueHeading();

		tiles.Insert(tiles.Count, tile);
	}

	void StartScenario() {
		float trueHeadingTemp = getTrueHeading();
		GameObject tileObject;
		GameObject prefabTile;
		int tilesTotal = 10; //6;
		float starts = -(tilesTotal * tileSize) / 2; //-39.49f;
		for (int i = 0; i < tilesTotal; i++) {
			prefabTile = prefabTiles[i % prefabTiles.Count];
			float positionX = starts + (tileSize * i);
			tileObject = Instantiate(prefabTile, new Vector3(positionX, topPosition, 0), Quaternion.identity);
			tiles.Add(new Tile(tileObject, trueHeadingTemp));
		}
	}

	void PlaceAnimal() {
		// TODO predic the position of the animal based on 360 position (or strait line of scrolling game)

//		float guessPosition = Random.Range(0f, 360f);
//		float xPosition = Quaternion.;
//		animal.transform.position = new Vector3(xPosition, animal.transform.position.y, animal.transform.position.z);
	}

	float getTrueHeading() {
		if (SystemInfo.deviceType == DeviceType.Handheld) {
			return Input.compass.trueHeading;
		}
		return CameraController.fakeTrueHeading;
	}
}

internal class Tile {
	public GameObject gameObject { get; set; }

	// TODO will it be useful?
	public float trueHeading { get; set; }


	public Tile(GameObject gameObject, float trueHeading) {
		this.gameObject = gameObject;
		this.trueHeading = trueHeading;
	}
}

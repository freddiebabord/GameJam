﻿using UnityEngine;
using System.Collections;

public class GrassUi : MonoBehaviour {

	Pointer point;
	
	TilePlacement tiles;
	
	GameObject tile;
	
	bool grass = false;

	// Use this for initialization
	void Start () {
		
		tiles = GameObject.FindObjectOfType<TilePlacement> ();
		point = GameObject.FindObjectOfType<Pointer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (grass && !tiles.isTrue)
			point.placeTile = false;
		
		if (point.placeTile) 
		{
			tile = point.currentTile;
			//GameObject go = Instantiate (Resources.Load ("Prefabs/tiles/" + index.ToString ()), tile.transform.position, tile.transform.rotation) as GameObject;
			
			if (Input.GetAxis ("TriggerSelectRight") < 1) 
			{
				//Destroy(go);
			}
		} 
		else 
		{
			tile = null;
		}
		
		if (grass && point.placeTile && Input.GetAxis ("TriggerSelectRight") >= 1) 
		{
			if (tile != null)
			{
				if (tile.GetComponent<NodePath>().pathType != NodePath.PathType.Grass)
				{
					Vector3 pos = tile.transform.position;
					Quaternion rot = tile.transform.rotation;

					Destroy(tile.gameObject);

					Instantiate(Resources.Load("Prefabs/Tiles/GrassTile"), pos, rot);

				}
			}
		}
		
		if(Input.GetAxis ("TriggerSelectLeft") >= 1)
		{
			grass = false;
			point.placeTile = false;
		}
	}
	
	public void PlaceGrass()
	{
		point.placeTile = !point.placeTile;
		grass = !grass;
	}
}

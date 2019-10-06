﻿using UnityEngine;

public class MeadowSpawn : MonoBehaviour
{
	[Header("Objects In Meadow")]
	public GameObject[] Meadow;

	[Header("Number of Biome Objects")]
	public int[] meadowRange;

	[Header("Biome Range X(min, max) Z(min, max)")]
	public int[] biomeRange;

	[Header("Max Object Scale")]
	public int maxScale;

	// Start is called before the first frame update
	void Start() {

		// Number of objects in meadow
		int randMeadow = Random.Range(meadowRange[0], meadowRange[1]);

		// Random size of Biome from spawn point
		int randWid = Random.Range(biomeRange[0], biomeRange[1]);
		int randLen = Random.Range(biomeRange[2], biomeRange[3]);

		// Draw All Images
		for (int i = 0; i <= randMeadow; i++) {

			// Choose Model to put into scene (e.g. stone, twig)
			int meadowImg = Random.Range(0, Meadow.Length);

			// Random Position in range
			int randX = Random.Range(-randWid, randWid);
			int randZ = Random.Range(-randLen, randLen);

			// Random Scale Factor
			int scaleFactor = Random.Range(1, maxScale);

			// Create the Position, Rotation and Scale of new object 
			Vector3 newPos = new Vector3(transform.position.x + (randX), 100, transform.position.z + (randZ));
			Quaternion randRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
			Vector3 randScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

			// Find Ground - if Ground exists instantiate on ground
			if (Physics.Raycast(newPos, Vector3.down, out RaycastHit hit)) {
				Vector3 finalPos = hit.point;
				GameObject a = Instantiate(Meadow[meadowImg], finalPos, randRotation);
				a.transform.localScale = randScale;
			}
		}
	}
}

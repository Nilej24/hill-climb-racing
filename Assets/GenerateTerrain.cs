using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GenerateTerrain : MonoBehaviour
{
    public SpriteShapeController spriteShape;
    private Spline terrain;

    public int terrainLength;
    [Range(0, 1)] public float terrainSmoothness;
    public float xMultiplier, yMultiplier;
    public float noiseStep, noiseY;
    public float bottomThickness;

    void OnValidate()
    {

        // reset terrain spline
        terrain = spriteShape.spline;
        terrain.Clear();

        // generate points
        // use perlin noise for point heights
        for (int i = 0; i <= terrainLength; i++) {
            
            float x = i * xMultiplier;
            float y = Mathf.PerlinNoise(i * noiseStep, noiseY) * yMultiplier;

            var newPoint = new Vector3(x, y, 0);

			terrain.InsertPointAt(i, newPoint);

            // set tangents based on smoothness
            if (i != 0 && i != terrainLength) {
                terrain.SetTangentMode(i, ShapeTangentMode.Continuous);
				terrain.SetLeftTangent(i, Vector3.left * terrainSmoothness * xMultiplier);
				terrain.SetRightTangent(i, Vector3.right * terrainSmoothness * xMultiplier);
			}

		}

        // generate base points 
        terrain.InsertPointAt(terrainLength + 1, (Vector3.down * bottomThickness * yMultiplier) + (Vector3.right * terrainLength * xMultiplier));
        terrain.InsertPointAt(terrainLength + 2, Vector3.down * bottomThickness * yMultiplier);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MenuLidarScanner : MonoBehaviour
{
    [SerializeField] private Color lidarColor = Color.white;
    [SerializeField] private Transform rayStartPoint;
    [SerializeField] private float radius = 10;
    [SerializeField] private float iterations = 60;

    public void Scan()
    {
        StartCoroutine(UseCircleLidar());
    }

    private IEnumerator UseWideLidar()
    {
        for (float i = -24; i < 25; i += radius / 10)
        {
            List<Texture2D> textures = new List<Texture2D>();
            Texture2D lastTexture = null;
            NativeArray<Color32> pixels = new NativeArray<Color32>();

            for (float j = -30; j < 31; j += radius / 10)
            {
                rayStartPoint.localEulerAngles = new Vector3(i, j, 0);
                try
                {
                    if (Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hit))
                    {
                        Texture2D currentTexture = (Texture2D)hit.collider.GetComponent<Renderer>().material.mainTexture;
                        if (!currentTexture.isReadable) continue;

                        if (currentTexture != lastTexture)
                        {
                            pixels = currentTexture.GetRawTextureData<Color32>();
                            if (!textures.Contains(currentTexture)) textures.Add(currentTexture);
                            lastTexture = currentTexture;
                        }

                        Vector2 UVcords = hit.textureCoord;
                        UVcords.x *= currentTexture.width;
                        UVcords.y *= currentTexture.height;

                        int pixelIndex = (int)UVcords.y * currentTexture.width + (int)UVcords.x;
                        pixels[pixelIndex] = lidarColor;
                    }
                }
                catch
                {
                    continue;
                }
            }

            foreach (Texture2D tex in textures)
            {
                tex.Apply(false);
            }

            yield return new WaitForSeconds(0.025f);
        }
    }

    private IEnumerator UseCircleLidar()
    {
        for (int l = 0; l < iterations; l++)
        {
            List<Texture2D> textures = new List<Texture2D>();
            Texture2D lastTexture = null;
            NativeArray<Color32> pixels = new NativeArray<Color32>();

            for (float i = 0; i < radius * 2 + 1; i += radius / 2 + (int)(Random.Range(-1f, 1f) * radius))
            {
                rayStartPoint.localEulerAngles = Vector3.right * i;

                for (float j = 0; j < 360; j += radius)
                {
                    rayStartPoint.RotateAround(rayStartPoint.parent.forward, radius + (int)(Random.Range(-0.5f, 0.5f) * radius));

                    try
                    {
                        if (Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hit))
                        {
                            Texture2D currentTexture = (Texture2D)hit.collider.GetComponent<Renderer>().material.mainTexture;
                            if (!currentTexture.isReadable) continue;

                            if (currentTexture != lastTexture)
                            {
                                pixels = currentTexture.GetRawTextureData<Color32>();
                                if (!textures.Contains(currentTexture)) textures.Add(currentTexture);
                                lastTexture = currentTexture;
                            }

                            Vector2 UVcords = hit.textureCoord;
                            UVcords.x *= currentTexture.width;
                            UVcords.y *= currentTexture.height;

                            int pixelIndex = (int)UVcords.y * currentTexture.width + (int)UVcords.x;
                            pixels[pixelIndex] = lidarColor;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            foreach (Texture2D tex in textures)
            {
                tex.Apply(false);
            }

            yield return new WaitForSeconds(0.06f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TextureCleaner : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures;

    public void ClearAllTextures()
    {
        foreach (Texture2D texture in textures)
        {
            ClearTexture(texture);
        }
    }

    public void ClearTexture(Texture2D texture)
    {
        NativeArray<Color32> pixels = new NativeArray<Color32>();
        pixels = texture.GetRawTextureData<Color32>();
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = new Color(pixels[i].r / 255f, pixels[i].g / 255f, pixels[i].b / 255f, 0f);
        }
        texture.Apply();
    }
}

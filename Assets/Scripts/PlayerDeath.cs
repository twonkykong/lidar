using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] components;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private TextureCleaner textureCleaner;
    [SerializeField] private Image blackScreen;

    [SerializeField] private bool nextRoomOnDeath;

    public void Die()
    {
        audioManager.TurnOff();
        blackScreen.color = Color.black;
        audioSource.Play();
        foreach (MonoBehaviour component in components) component.enabled = false;
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Scene nextScene = SceneManager.GetActiveScene();
        if (nextRoomOnDeath) nextScene = SceneManager.GetSceneByBuildIndex(nextScene.buildIndex + 1);
        textureCleaner.ClearAllTextures();
        SceneManager.LoadScene(nextScene.name);
    }
}

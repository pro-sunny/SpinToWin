using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneComponent : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void OpenScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}

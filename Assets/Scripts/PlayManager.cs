using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public void LoadGameScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

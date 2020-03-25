using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        manager.printInventory();

    }

    public void switchTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }
}

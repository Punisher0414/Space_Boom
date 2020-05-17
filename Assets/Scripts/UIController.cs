using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private GameObject victoryScreen;

    private PlayerController player;
    private int currentAmmount;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    void Update()
    {
        currentAmmount = player.MineralAmmount;

        if (victoryScreen != null && currentAmmount == 3)
        {
            victoryScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level_01");
    }
}

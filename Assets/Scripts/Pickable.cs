using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    private int ammount;
    //private int scoreToAdd = 0;


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    PlayerController player = other.gameObject.GetComponent<PlayerController>();

    //    if (player != null)
    //    {
    //        player.ChangeScore(scoreToAdd);
    //        Debug.Log("Earn: " + scoreToAdd);
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeMineral(ammount);
            Destroy(this.gameObject);
        }
    }

}

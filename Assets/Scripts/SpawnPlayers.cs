using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {   
        //if(FindObjectsOfType<PlayerController>().Length == 0)
        //{   
        //    PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(playerPrefab.transform.position.x - 5, playerPrefab.transform.position.y, playerPrefab.transform.position.z), playerPrefab.transform.rotation);
        //    Debug.Log("player 1 in scene");
        //}
        //else
        //{
            
        //    Debug.Log("player 2 in scene");
        //}

        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);

    }
}

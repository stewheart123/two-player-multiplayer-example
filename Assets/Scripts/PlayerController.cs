using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    public int score;
    public bool isPlayerOne;
    private PhotonView photonViewComponent;
    private PlayerController[] playerControllers;
    [SerializeField] Text scoreText;
    
    void Start()
    {
        photonViewComponent = gameObject.GetComponent<PhotonView>();
        playerControllers = FindObjectsOfType<PlayerController>();
        if(playerControllers.Length > 1)
        {
            this.isPlayerOne = false;
        }
        else
        {
            this.isPlayerOne = true;
            gameObject.transform.Translate(new Vector3(-5f, 0f, 0f));
        }

    }

    void Update()
    {
        if(photonViewComponent.IsMine)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            scoreText.text = score.ToString();
        }
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(score);
            stream.SendNext(scoreText.text);
        }
        else
        {
            this.score = (int)stream.ReceiveNext();
            this.scoreText.text = (string)stream.ReceiveNext();
        }
    }
}

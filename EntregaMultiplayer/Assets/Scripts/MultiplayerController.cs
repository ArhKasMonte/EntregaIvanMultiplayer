using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Imports da photon
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerController : MonoBehaviourPunCallbacks
{
    void Start()
    {
       //Define quais s�o as configura��es para se conectar no servidor da photon e realizar a concex�o
       PhotonNetwork.ConnectUsingSettings();
    }


    void Update()
    {
        
    }

    public override void OnConnected()
    {
        Debug.Log("Conectei na photon");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado no Master");
    }
}

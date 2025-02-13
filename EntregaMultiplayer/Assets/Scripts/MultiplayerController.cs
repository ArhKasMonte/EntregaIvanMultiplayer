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
        //Configurar região antes de conectar
        PhotonNetwork.PhotonServerSettings.DevRegion = "sa";

       //Define quais são as configurações para se conectar no servidor da photon e realizar a concexão
        PhotonNetwork.ConnectUsingSettings();
        //StartCoroutine(UpdatePing(1f));
    }
     
    public override void OnConnected()
    {
        Debug.Log("Conectei na photon");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado no Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entrou no lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Finalmente entre em uma room " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(returnCode);
        Debug.Log(message);
        Debug.Log("Não achou nenhuma room");

        string roomName = $"Room_{PhotonNetwork.CloudRegion}_{Random.Range(0, 999)}";

        PhotonNetwork.CreateRoom(roomName);

    }
    IEnumerator UpdatePing(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        float ping = PhotonNetwork.GetPing();
        string localServer = PhotonNetwork.CloudRegion;
        Debug.Log("Ping - " + ping + " Conectado em - " + localServer);
        StartCoroutine(UpdatePing(1f));
    }
}

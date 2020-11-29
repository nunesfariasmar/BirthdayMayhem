using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Scene1Script : MonoBehaviourPunCallbacks
{
    [SerializeField] private bool IsMaster;
    [SerializeField] private bool IsSplit;
    [SerializeField] private bool IsRecovering;
    [SerializeField] private string Group;
    [SerializeField] private int RecoveryIdx;
    [SerializeField] public static bool recovery;
    [SerializeField] public static string TestGroup = "Alpha";

    public static int player1 = -1;
    public static int player2 = -1;
    public static int playerProun1 = -1;
    public static int playerProun2 = -1;

    public static bool BubblesOn = true;

    private int playersInRoom = 0;

    // Start is called before the first frame update
    void Start()
    {
        TestGroup = Group;
        recovery = IsRecovering;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedRoom()
    {
        if (IsMaster)
        {
            PhoneInit.PlayerId = 5;
        }
        GameObject.FindObjectOfType<Text>().text = "Room " + PhotonNetwork.CurrentRoom.Name + " joined.";
        Debug.Log("Status " + PhotonNetwork.IsConnected + " Room: " + PhotonNetwork.CurrentRoom.Name);
        ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable()
            {
                { "StoryText", ""},
                {"Choice0", "" },
                {"Choice1", "" },
                {"Choice2", "" },
                {"Continue", false },
                {"Pick", -1 },
                {"ActorId", PhoneInit.PlayerId },
                {"ActorProuns", PhoneInit.PlayerGender }
            };

        PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
        if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount > 2 && IsMaster)
        {
            if (IsSplit)
                SceneManager.LoadScene("Birthday2");
            else
            {
                SceneManager.LoadScene("Birthday1");
            }
        }
        else if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount > 2 && !IsMaster) SceneManager.LoadScene("PhoneScreen");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount > 2 && IsMaster)
        {
            //SceneManager.LoadScene("Birthday1");
        }

        else if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount > 2 && !IsMaster)
        {
            SceneManager.LoadScene("PhoneScreen");
        }
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.BroadcastPropsChangeToAll = true;
        roomOptions.MaxPlayers = 10;

        roomOptions.PlayerTtl = 60000; // 60 sec
        PhotonNetwork.JoinOrCreateRoom("Test4.1Room", roomOptions, TypedLobby.Default);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (IsMaster)
        {
            Debug.Log("Player entered! ActorId: " + (int)changedProps["ActorId"]);
            if ((int) changedProps["ActorId"] == 1)
            {
                player1 = targetPlayer.ActorNumber;
                playerProun1 = (int) changedProps["ActorProuns"];
            }
            else if ((int) changedProps["ActorId"] == 2)
            {
                player2 = targetPlayer.ActorNumber;
                playerProun2 = (int) changedProps["ActorProuns"];
            }

            if (player1 != -1 && player2 != -1)
            {
                Debug.Log("MARIANA: PLAYER 1: " + player1 + " PLAYER 2: " + player2);
                Debug.Log("MARIANA: PLAYER 1 Proun: " + (playerProun1 == 1? "Masc" : "Fem") + " PLAYER 2 Proun: " + (playerProun2 == 1 ? "Masc" : "Fem"));
                if (recovery)
                {
                    if (RecoveryIdx == 1) SceneManager.LoadScene("Birthday1");
                    else if (RecoveryIdx == 2) SceneManager.LoadScene("Birthday2");
                    else if (RecoveryIdx == 3) SceneManager.LoadScene("Birthday3");
                }
                else if (IsSplit)
                    SceneManager.LoadScene("Birthday2");
                else
                    SceneManager.LoadScene("Birthday1");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

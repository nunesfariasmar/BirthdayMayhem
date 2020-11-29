using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TransitionScript : MonoBehaviourPunCallbacks
{
    private int replies = 0;

    private EventHandler<UserReplyEventArgs> UserReplyReceived;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (!player.Value.IsLocal)
            {
                var properties = new ExitGames.Client.Photon.Hashtable()
                {
                    {"StoryText", "..."},
                    {"Choice0", ""},
                    {"Choice1", ""},
                    {"Choice2", ""},
                    {"Continue", false},
                    {"Pick", -1},
                    {"ActorId", 1}
                };
                player.Value.SetCustomProperties(properties);
            }
        }
    }

    void OnUserReplyReceived(object sender, UserReplyEventArgs e)
    {

    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer.ActorNumber !=
            PhotonNetwork.LocalPlayer.ActorNumber)
        {
            if (changedProps["Continue"] != null && (bool)changedProps["Continue"])
                replies++;
            if (replies == 2)
            {
                if (SceneManager.GetActiveScene().name.Equals("Transition"))
                    SceneManager.LoadScene("Birthday2");
                else
                    SceneManager.LoadScene("Birthday3");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

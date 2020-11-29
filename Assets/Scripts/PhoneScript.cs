using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static Photon.Pun.PhotonNetwork;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhoneScript : MonoBehaviourPunCallbacks
{
    private int playerID;

    private bool isInRoom = true;
    private bool MenuOn = false;
    private bool Vibration = true;
    private bool ThoughtBubble = true;

    private Text textBox;
    private Button btn0, btn1, btn2;

    private GameObject Menu;

    private Toggle VibrationToggle, BubblesToggle;
    private Button Apply, Cancel;

    void Start()
    {
        textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("StoryCanvas"));

        var btns = Resources.FindObjectsOfTypeAll<Button>();
        btn0 = btns.FirstOrDefault(x => x.CompareTag("Choice0"));
        btn1 = btns.FirstOrDefault(x => x.CompareTag("Choice1"));
        btn2 = btns.FirstOrDefault(x => x.CompareTag("Choice2"));
        Apply = btns.FirstOrDefault(x => x.CompareTag("Apply"));
        Cancel = btns.FirstOrDefault(x => x.CompareTag("Cancel"));

        Menu = GameObject.FindGameObjectWithTag("OptionsMenu");
        VibrationToggle = FindObjectsOfType<Toggle>().FirstOrDefault(x => x.CompareTag("Vibration"));
        BubblesToggle = FindObjectsOfType<Toggle>().FirstOrDefault(x => x.CompareTag("Thought Bubbles"));


        var cog = btns.FirstOrDefault(x => x.CompareTag("cog"));
        cog.onClick.AddListener(() =>
        {
            VibrationToggle.isOn = Vibration;
            BubblesToggle.isOn = ThoughtBubble;
            MenuOn = !MenuOn;
            Menu.SetActive(MenuOn);
        });

        Cancel.onClick.AddListener(() =>
        {
            VibrationToggle.isOn = Vibration;
            BubblesToggle.isOn = ThoughtBubble;
            MenuOn = false;
            Menu.SetActive(false);
        });

        Apply.onClick.AddListener(() =>
        {
            Vibration = VibrationToggle.isOn;
            ThoughtBubble = BubblesToggle.isOn;
            MenuOn = false;
            Menu.SetActive(false);
            Hashtable properties = new Hashtable()
            {
                {"Bubbles", ThoughtBubble}
            };

            LocalPlayer.SetCustomProperties(properties);
        });

        Menu.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnLeftRoom();
        var oldText = textBox.text;

        var oldbtn0 = btn0.GetComponentInChildren<Text>().text;
        var oldbtn1 = btn1.GetComponentInChildren<Text>().text;
        var oldbtn2 = btn2.GetComponentInChildren<Text>().text;
        textBox.text = "Disconnected... Trying to reconnect!";
        while (!IsConnected)
        {
            PhotonNetwork.ReconnectAndRejoin();
            Thread.Sleep(10000);
        }

        textBox.text = oldText;

        btn0.GetComponentInChildren<Text>().text = oldbtn0;
        btn1.GetComponentInChildren<Text>().text = oldbtn1;
        btn2.GetComponentInChildren<Text>().text = oldbtn2;
    }

    public override void OnLeftRoom()
    {
        
    }


    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Bubbles"))
        {
            ThoughtBubble = (bool)changedProps["Bubbles"];
            BubblesToggle.isOn = ThoughtBubble;
            return;
        }

        if (targetPlayer.IsLocal)
        {
            if (changedProps.ContainsKey("Vibrate") && Vibration)
            {
                Handheld.Vibrate();
            }
            if (changedProps.ContainsKey("Finished") && ((string)changedProps["Finished"]).Equals("True"))
            {
                textBox.text = "Thank you for playing :)";
            }
            else if ((int) changedProps["Pick"] == -2 || ((string)changedProps["StoryText"]).Equals(""))
            {
                textBox.text = "Loading...";

                btn0.gameObject.SetActive(false);
                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(false);
            }
            else
            {
                if (textBox != null)
                {
                    textBox.text = (string) LocalPlayer.CustomProperties["StoryText"];
                }

                if (!((string) changedProps["Choice0"]).Equals(""))
                {
                    btn0.gameObject.SetActive(true);
                    btn0.GetComponentInChildren<Text>().text = (string) changedProps["Choice0"];
                    btn0.onClick.RemoveAllListeners();
                    btn0.onClick.AddListener(delegate { OnClickChoiceButton(0); });

                    if (!((string) changedProps["Choice1"]).Equals(""))
                    {
                        btn1.gameObject.SetActive(true);
                        btn1.GetComponentInChildren<Text>().text = (string) changedProps["Choice1"];
                        btn1.onClick.RemoveAllListeners();
                        btn1.onClick.AddListener(delegate { OnClickChoiceButton(1); });
                    }

                    if (!((string) changedProps["Choice2"]).Equals(""))
                    {
                        btn2.gameObject.SetActive(true);
                        btn2.GetComponentInChildren<Text>().text = (string) changedProps["Choice2"];
                        btn2.onClick.RemoveAllListeners();
                        btn2.onClick.AddListener(delegate { OnClickChoiceButton(2); });
                    }
                }

                else
                {
                    btn0.gameObject.SetActive(true);
                    btn0.GetComponentInChildren<Text>().text = "Continue";
                    btn0.onClick.RemoveAllListeners();
                    btn0.onClick.AddListener(delegate { OnClickContinueButton(); });
                }
            }
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(int choice)
    {
        btn0.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        Hashtable properties = new Hashtable()
        {
            {"StoryText", ""},
            {"Choice0", ""},
            {"Choice1", ""},
            {"Choice2", ""},
            {"Continue", false},
            { "Pick", choice},
            {"ActorId", PhoneInit.PlayerId }
        };

        LocalPlayer.SetCustomProperties(properties);
    }

    void OnClickContinueButton()
    {
        if ((int)LocalPlayer.CustomProperties["Pick"] == -2)
        {
            textBox.text = "The story has ended (for now :) ).";

            btn0.gameObject.SetActive(false);
            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
        }
        else
        {
            var properties = new Hashtable()
            {
                {"StoryText", ""},
                {"Choice0", ""},
                {"Choice1", ""},
                {"Choice2", ""},
                {"Continue", true},
                {"Pick", -1},
                {"ActorId", PhoneInit.PlayerId }
            };

            LocalPlayer.SetCustomProperties(properties);
            
            btn0.gameObject.SetActive(false);
            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
        }
    }

}

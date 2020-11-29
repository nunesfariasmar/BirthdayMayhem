using System;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SharedScreenScript : MonoBehaviourPunCallbacks 
{
    private EventHandler<UserReplyEventArgs> UserReplyReceived;
    private Story mainStory;
    private Story char1story;
    private Story char2story;
    private Dictionary<int, int> replies = new Dictionary<int,int>();

    [SerializeField] private TextAsset MainInkFile;
    [SerializeField] private TextAsset FirstCharInkFile;
    [SerializeField] private TextAsset SecondCharInkFile;


    [SerializeField] private Sprite Kitchen;
    [SerializeField] private Sprite Claire;


    [SerializeField] private Sprite alexFemDoubtful;
    [SerializeField] private Sprite alexFemHappy;
    [SerializeField] private Sprite alexFemSidelook;
    [SerializeField] private Sprite alexFemSmile;
    [SerializeField] private Sprite alexFemSmug;

    [SerializeField] private Sprite alexMasDoubtful;
    [SerializeField] private Sprite alexMasHappy;
    [SerializeField] private Sprite alexMasSidelook;
    [SerializeField] private Sprite alexMasSmile;
    [SerializeField] private Sprite alexMasSmug;
    
    [SerializeField] private Sprite jesseFemDoubtful;
    [SerializeField] private Sprite jesseFemHappy;
    [SerializeField] private Sprite jesseFemSidelook;
    [SerializeField] private Sprite jesseFemSmile;
    [SerializeField] private Sprite jesseFemSmug;

    [SerializeField] private Sprite jesseMasDoubtful;
    [SerializeField] private Sprite jesseMasHappy;
    [SerializeField] private Sprite jesseMasSidelook;
    [SerializeField] private Sprite jesseMasSmile;
    [SerializeField] private Sprite jesseMasSmug;

    private Image background, textBackground;
    private Image claireSprite, jesseSprite, alexSprite;

    private List<DateTime> times1 = new List<DateTime>();
    private List<DateTime> times2 = new List<DateTime>();

    private int player1 = -10 , player2 = -10;
    private bool other1, other2;

    List<String> tBox = new List<string>();

    Text textBox;
    Text dots1, dots2;
    private GameObject AlexThought, JesseThought;

    // Start is called before the first frame update
    void Start()
    {
        textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("StoryCanvas"));
        var dots = FindObjectsOfType<Text>().Where(x => x.CompareTag("dots"));
        AlexThought = GameObject.FindGameObjectWithTag("TBAlex");
        JesseThought = GameObject.FindGameObjectWithTag("TBJesse");
        dots1 = dots.ElementAt(0);
        dots2 = dots.ElementAt(1);

        JesseThought.SetActive(false); AlexThought.SetActive(false);
        foreach (var VARIABLE in Resources.FindObjectsOfTypeAll<Image>())
        {
            if (VARIABLE.CompareTag("Background"))
            {
                background = VARIABLE;
            }
            else if (VARIABLE.CompareTag("Textbc"))
            {
                textBackground = VARIABLE;
            }

            else if (VARIABLE.CompareTag("Sprite"))
            {
                claireSprite = VARIABLE;
            }

            else if (VARIABLE.CompareTag("BtnAlex"))
            {
                alexSprite = VARIABLE;
            }
            else if (VARIABLE.CompareTag("BtnJesse"))
            {
                jesseSprite = VARIABLE;
            }
        }

        var pNum = PhotonNetwork.LocalPlayer.ActorNumber;

        player1 = Scene1Script.player1;
        player2 = Scene1Script.player2;

        replies.Add(player1, -2);
        replies.Add(player2, -2);


        mainStory = new Story(MainInkFile.text);
        char1story = new Story(FirstCharInkFile.text);
        char2story = new Story(SecondCharInkFile.text);


        Debug.Log("playerproun1 = " + Scene1Script.playerProun1 + " playerProun2 = " + Scene1Script.playerProun2);

        setPronouns();

        char1story.ObserveVariable("Other", (variableName, value) => { other1 = ((string) value).Equals("true"); });
        char2story.ObserveVariable("Other", (variableName, value) => { other2 = ((string) value).Equals("true"); });

        UserReplyReceived += OnUserReplyReceived;
        mainStory.ObserveVariable("Background", (variableName, value) =>
        {
            if (value.Equals("Kitchen"))
                background.sprite = Kitchen;
            else if (value.Equals(""))
            {
                background.sprite = null;
            }
        });

        mainStory.ObserveVariable("Sprite", (variableName, value) =>
        {

            if (value.Equals("Claire"))
            {
                claireSprite.sprite = Claire;
                claireSprite.gameObject.SetActive(true);
            }
            else if (value.Equals(""))
            {
                claireSprite.sprite = null;
                claireSprite.gameObject.SetActive(false);
            }


        });

        mainStory.ObserveVariable("AlexSprite", (variableName, value) =>
        {
            if (Scene1Script.playerProun1 == 1)
            {
                if (value.Equals("Doubtful"))
                {
                    alexSprite.sprite = alexMasDoubtful;
                }
                else if (value.Equals("Happy"))
                {
                    alexSprite.sprite = alexMasHappy;
                }
                else if (value.Equals("Sidelook"))
                {
                    alexSprite.sprite = alexMasSidelook;
                }
                else if (value.Equals("Smile"))
                {
                    alexSprite.sprite = alexMasSmile;
                }
                else if (value.Equals("Smug"))
                {
                    alexSprite.sprite = alexMasSmug;
                }
            }
            else
            {
                if (value.Equals("Doubtful"))
                {
                    alexSprite.sprite = alexFemDoubtful;
                }
                else if (value.Equals("Happy"))
                {
                    alexSprite.sprite = alexFemHappy;
                }
                else if (value.Equals("Sidelook"))
                {
                    alexSprite.sprite = alexFemSidelook;
                }
                else if (value.Equals("Smile"))
                {
                    alexSprite.sprite = alexFemSmile;
                }
                else if (value.Equals("Smug"))
                {
                    alexSprite.sprite = alexFemSmug;
                }
            }

        });

        mainStory.ObserveVariable("JesseSprite", (variableName, value) =>
        {
            if (Scene1Script.playerProun2 == 1)
            {
                if (value.Equals("Doubtful"))
                {
                    jesseSprite.sprite = jesseMasDoubtful;
                }
                else if (value.Equals("Happy"))
                {
                    jesseSprite.sprite = jesseMasHappy;
                }
                else if (value.Equals("Sidelook"))
                {
                    jesseSprite.sprite = jesseMasSidelook;
                }
                else if (value.Equals("Smile"))
                {
                    jesseSprite.sprite = jesseMasSmile;
                }
                else if (value.Equals("Smug"))
                {
                    jesseSprite.sprite = jesseMasSmug;
                }
            }
            else
            {
                if (value.Equals("Doubtful"))
                {
                    jesseSprite.sprite = jesseFemDoubtful;
                }
                else if (value.Equals("Happy"))
                {
                    jesseSprite.sprite = jesseFemHappy;
                }
                else if (value.Equals("Sidelook"))
                {
                    jesseSprite.sprite = jesseFemSidelook;
                }
                else if (value.Equals("Smile"))
                {
                    jesseSprite.sprite = jesseFemSmile;
                }
                else if (value.Equals("Smug"))
                {
                    jesseSprite.sprite = jesseFemSmug;
                }
            }

        });

        if (Scene1Script.recovery)
        {
            Scene1Script.recovery = false;
            mainStory.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1Main.txt"));

            char1story.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1c1.txt"));

            char2story.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1c2.txt"));

            tBox = System.IO.File.ReadAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1screenText.txt")
                .Select(x => (x.Contains("<color=yellow>") ? x.Replace("<color=yellow>", "") : x)).Select(x => x.Contains("</color>") ? x.Replace("</color>", "") : x).ToList();
            foreach (var l in tBox)
            {
                textBox.text += l + "\n";
            }

            if (mainStory.variablesState["Sprite"].Equals("Claire"))
            {
                claireSprite.sprite = Claire;
                claireSprite.gameObject.SetActive(true);
            }

            if (char1story.variablesState["Other"].Equals("True"))
            {
                other1 = true;
            }
            else other1 = false;

            if (char2story.variablesState["Other"].Equals("True"))
            {
                other2 = true;
            }
            else other2 = false;
            if (Scene1Script.playerProun1 == 1)
            {
                if (mainStory.variablesState["AlexSprite"].Equals("Doubtful"))
                {
                    alexSprite.sprite = alexMasDoubtful;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Happy"))
                {
                    alexSprite.sprite = alexMasHappy;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Sidelook"))
                {
                    alexSprite.sprite = alexMasSidelook;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Smile"))
                {
                    alexSprite.sprite = alexMasSmile;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Smug"))
                {
                    alexSprite.sprite = alexMasSmug;
                }
            }
            else
            {
                if (mainStory.variablesState["AlexSprite"].Equals("Doubtful"))
                {
                    alexSprite.sprite = alexFemDoubtful;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Happy"))
                {
                    alexSprite.sprite = alexFemHappy;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Sidelook"))
                {
                    alexSprite.sprite = alexFemSidelook;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Smile"))
                {
                    alexSprite.sprite = alexFemSmile;
                }
                else if (mainStory.variablesState["AlexSprite"].Equals("Smug"))
                {
                    alexSprite.sprite = alexFemSmug;
                }

            }

            if (Scene1Script.playerProun2 == 1)
            {

                if (mainStory.variablesState["JesseSprite"].Equals("Doubtful"))
                {
                    jesseSprite.sprite = jesseMasDoubtful;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Happy"))
                {
                    jesseSprite.sprite = jesseMasHappy;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Sidelook"))
                {
                    jesseSprite.sprite = jesseMasSidelook;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Smile"))
                {
                    jesseSprite.sprite = jesseMasSmile;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Smug"))
                {
                    jesseSprite.sprite = jesseMasSmug;
                }
            }
            else
            {
                if (mainStory.variablesState["JesseSprite"].Equals("Doubtful"))
                {
                    jesseSprite.sprite = jesseFemDoubtful;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Happy"))
                {
                    jesseSprite.sprite = jesseFemHappy;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Sidelook"))
                {
                    jesseSprite.sprite = jesseFemSidelook;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Smile"))
                {
                    jesseSprite.sprite = jesseFemSmile;
                }
                else if (mainStory.variablesState["JesseSprite"].Equals("Smug"))
                {
                    jesseSprite.sprite = jesseFemSmug;
                }
            }
        }

        ContinueStory();

    }
    private void setPronouns()
    {
        if (Scene1Script.playerProun1 == 1)
        {
            mainStory.variablesState["pron_Alex"] = "he";
            char1story.variablesState["pron_Alex"] = "he";
            char2story.variablesState["pron_Alex"] = "he";
            mainStory.variablesState["Pron_Alex"] = "He";
            char1story.variablesState["Pron_Alex"] = "He";
            char2story.variablesState["Pron_Alex"] = "He";
            mainStory.variablesState["poss_pron_Alex"] = "his";
            char1story.variablesState["poss_pron_Alex"] = "his";
            char2story.variablesState["poss_pron_Alex"] = "his";
        }

        else if (Scene1Script.playerProun1 == 2)
        {
            mainStory.variablesState["pron_Alex"] = "she";
            char1story.variablesState["pron_Alex"] = "she";
            char2story.variablesState["pron_Alex"] = "she";
            mainStory.variablesState["Pron_Alex"] = "She";
            char1story.variablesState["Pron_Alex"] = "She";
            char2story.variablesState["Pron_Alex"] = "She";
            mainStory.variablesState["poss_pron_Alex"] = "her";
            char1story.variablesState["poss_pron_Alex"] = "her";
            char2story.variablesState["poss_pron_Alex"] = "her";
        }

        if (Scene1Script.playerProun2 == 1)
        {
            mainStory.variablesState["pron_Jesse"] = "he";
            char1story.variablesState["pron_Jesse"] = "he";
            char2story.variablesState["pron_Jesse"] = "he";
            mainStory.variablesState["Pron_Jesse"] = "He";
            char1story.variablesState["Pron_Jesse"] = "He";
            char2story.variablesState["Pron_Jesse"] = "He";
            mainStory.variablesState["poss_pron_Jesse"] = "his";
            char1story.variablesState["poss_pron_Jesse"] = "his";
            char2story.variablesState["poss_pron_Jesse"] = "his";
        }

        else if (Scene1Script.playerProun2 == 2)
        {
            mainStory.variablesState["pron_Jesse"] = "she";
            char1story.variablesState["pron_Jesse"] = "she";
            char2story.variablesState["pron_Jesse"] = "she";
            mainStory.variablesState["Pron_Jesse"] = "She";
            char1story.variablesState["Pron_Jesse"] = "She";
            char2story.variablesState["Pron_Jesse"] = "She";
            mainStory.variablesState["poss_pron_Jesse"] = "her";
            char1story.variablesState["poss_pron_Jesse"] = "her";
            char2story.variablesState["poss_pron_Jesse"] = "her";
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (player1 == -1)
        {
            player1 = newPlayer.ActorNumber;

            var phoneStoryLine = char1story.currentText;
            string choice0 = "", choice1 = "", choice2 = "";
            if (char1story.currentChoices.Count > 0 && !other1)
            {
                choice0 = char1story.currentChoices[0].text;
            }

            if (char1story.currentChoices.Count > 1 && !other1)
            {
                choice1 = char1story.currentChoices[1].text;
            }

            if (char1story.currentChoices.Count > 2 && !other1)
            {
                choice2 = char1story.currentChoices[2].text;
            }

            var properties = new ExitGames.Client.Photon.Hashtable()
            {
                {"StoryText", phoneStoryLine},
                {"Choice0", choice0},
                {"Choice1", choice1},
                {"Choice2", choice2},
                {"Continue", false},
                {"Pick", -1},
                {"ActorId", 1 }
            };

            newPlayer.SetCustomProperties(properties);
        }
        else if (player2 == -1)
        {
            player2 = newPlayer.ActorNumber;

            var phoneStoryLine = char2story.currentText;
            string choice0 = "", choice1 = "", choice2 = "";
            if (char2story.currentChoices.Count > 0 && !other1)
            {
                choice0 = char2story.currentChoices[0].text;
            }

            if (char2story.currentChoices.Count > 1 && !other1)
            {
                choice1 = char2story.currentChoices[1].text;
            }

            if (char2story.currentChoices.Count > 2 && !other1)
            {
                choice2 = char2story.currentChoices[2].text;
            }

            var properties = new ExitGames.Client.Photon.Hashtable()
            {
                {"StoryText", phoneStoryLine},
                {"Choice0", choice0},
                {"Choice1", choice1},
                {"Choice2", choice2},
                {"Continue", false},
                {"Pick", -1},
                {"ActorId", 1 }
            };

            newPlayer.SetCustomProperties(properties);
        }


    }

    void OnUserReplyReceived(object sender, UserReplyEventArgs e)
    {
        //if (replies[e.SenderId - 2] != -2)
        //{
        //    Debug.Log("This is a big bug lol");
        //}
        //else
        replies[e.SenderId] = e.Choice;

        if (Scene1Script.BubblesOn)
        {
            if (e.SenderId == player1) AlexThought.SetActive(false);
            else JesseThought.SetActive(false);
        }

        if (replies[player1] != -2 && replies[player2] != -2)
        {
            ContinueStory(replies[player1], replies[player2]);
            replies[player1] = -2;
            replies[player2] = -2;
        }

    }

    public void ContinueStory(int firstChoice = -1, int secondChoice = -1)
    {
        if (firstChoice != -1 && secondChoice == -1)
        {
            char1story.ChooseChoiceIndex(firstChoice);
            char2story.ChooseChoiceIndex(firstChoice);
            mainStory.ChooseChoiceIndex(firstChoice);
        }
        else if (firstChoice == -1 && secondChoice != -1)
        {
            char2story.ChooseChoiceIndex(secondChoice);
            char1story.ChooseChoiceIndex(secondChoice);
            mainStory.ChooseChoiceIndex(secondChoice);
        }

        else
        {
            var mStory = mainStory.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1Main.txt", mStory);

            var c1Story = char1story.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1c1.txt", c1Story);

            var c2Story = char2story.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1c2.txt", c2Story);

            System.IO.File.WriteAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT1screenText.txt", tBox);
        }

        if (char1story.canContinue && mainStory.canContinue && char2story.canContinue)
        {
            var line = mainStory.Continue();
            if (textBox != null && !line.Equals("...\n"))
            {
                var tempColor = textBackground.color;
                tempColor.a = 1f;
                textBackground.color = tempColor;
                if (tBox.Count == 18)
                {
                    tBox.RemoveAt(0);
                }

                if (tBox.Count > 0)
                    tBox[tBox.Count - 1] =
                        tBox[tBox.Count - 1].Replace("<color=yellow>", "").Replace("</color>", "").Replace("\n", "");
                tBox.Add("<color=yellow>" + line.Replace("\n", "") + "</color>");
                textBox.text = "";
                foreach (var l in tBox)
                {
                    textBox.text += l + "\n";
                }

                //textBox.text = textBox.text.Replace("<color=yellow>", "").Replace("</color>", "");
                //    textBox.text += "<color=yellow>" + line + "</color>";
            }

            if (line.Equals("...\n"))
            {
                var tempColor = textBackground.color;
                tempColor.a = 0.3f;
                textBackground.color = tempColor;
            }

            foreach (var player in PhotonNetwork.CurrentRoom.Players)
            {
                if (!player.Value.IsLocal)
                {
                    if (player.Value.ActorNumber == player1)
                    {
                        var phoneStoryLine = char1story.Continue();
                        string choice0 = "", choice1 = "", choice2 = "";
                        if (char1story.currentChoices.Count > 0 && !other1)
                        {
                            choice0 = char1story.currentChoices[0].text;
                        }

                        if (char1story.currentChoices.Count > 1 && !other1)
                        {
                            choice1 = char1story.currentChoices[1].text;
                        }

                        if (char1story.currentChoices.Count > 2 && !other1)
                        {
                            choice2 = char1story.currentChoices[2].text;
                        }

                        var properties = new ExitGames.Client.Photon.Hashtable()
                        {
                            {"StoryText", phoneStoryLine},
                            {"Choice0", choice0},
                            {"Choice1", choice1},
                            {"Choice2", choice2},
                            {"Continue", false},
                            {"Pick", -1},
                            {"ActorId", 1}
                        };

                        if (!phoneStoryLine.Equals("...\n"))
                        {
                            properties.Add("Vibrate", true);
                            if (Scene1Script.BubblesOn)
                                AlexThought.SetActive(true);
                        }
                        player.Value.SetCustomProperties(properties);
                    }

                    else
                    {
                        var phoneStoryLine = char2story.Continue();
                        string choice0 = "", choice1 = "", choice2 = "";
                        if (char2story.currentChoices.Count > 0 && !other2)
                        {
                            choice0 = char2story.currentChoices[0].text;
                        }

                        if (char2story.currentChoices.Count > 1 && !other2)
                        {
                            choice1 = char2story.currentChoices[1].text;
                        }

                        if (char2story.currentChoices.Count > 2 && !other2)
                        {
                            choice2 = char2story.currentChoices[2].text;
                        }

                        var properties = new ExitGames.Client.Photon.Hashtable()
                        {
                            {"StoryText", phoneStoryLine},
                            {"Choice0", choice0},
                            {"Choice1", choice1},
                            {"Choice2", choice2},
                            {"Continue", false},
                            {"Pick", -1},
                            {"ActorId", 2}
                        };
                        if (!phoneStoryLine.Equals("...\n"))
                        {
                            properties.Add("Vibrate", true);
                            if (Scene1Script.BubblesOn)
                                JesseThought.SetActive(true);
                        }

                        player.Value.SetCustomProperties(properties);
                    }

                }
            }
        }
        else
        {
            var p1 = PhotonNetwork.CurrentRoom.Players
                .FirstOrDefault(x => x.Value.ActorNumber == player1);
            var p2 = PhotonNetwork.CurrentRoom.Players
                .FirstOrDefault(x => x.Value.ActorNumber == player2);

            var properties = new ExitGames.Client.Photon.Hashtable()
            {
                {"StoryText", ""},
                {"Choice0", ""},
                {"Choice1", ""},
                {"Choice2", ""},
                {"Continue", false},
                {"Pick", -2}
            };
            p1.Value.SetCustomProperties(properties);
            p2.Value.SetCustomProperties(properties);
            List<TimeSpan> timesAvg = new List<TimeSpan>();

            for (int i = 0; i < (times1.Count > times2.Count ? times2.Count : times1.Count); i++)
            {

                if (times1.ElementAt(i).CompareTo(times2.ElementAt(i)) >= 0)
                    timesAvg.Add(times1.ElementAt(i).Subtract(times2.ElementAt(i)));

                else
                    timesAvg.Add(times2.ElementAt(i).Subtract(times1.ElementAt(i)));

            }

            if (timesAvg.Count > 0)
            {
                var text = "Most time taken: " + timesAvg.Max() + " seconds." + "\n" + "Average time taken: " +
                           timesAvg.Average(span => span.TotalSeconds) + " seconds.";


                Debug.Log("Most time taken: " + timesAvg.Max() + " seconds.");
                Debug.Log("Average time taken: " + timesAvg.Average(span => span.TotalSeconds) + " seconds.");

                System.IO.File.WriteAllText(
                    @"D:\tese\TestResults\times\timesG" + Scene1Script.TestGroup + "PT1.txt",
                    text);
            }

            SceneManager.LoadScene("Transition");

        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Bubbles"))
        {
            Scene1Script.BubblesOn = (bool)changedProps["Bubbles"];
            Debug.Log("Bubbles On: " + Scene1Script.BubblesOn);
            JesseThought.SetActive(Scene1Script.BubblesOn);
            AlexThought.SetActive(Scene1Script.BubblesOn);
            return;
        }
        if (targetPlayer.ActorNumber !=
            PhotonNetwork.LocalPlayer.ActorNumber)
        {
            if (changedProps["Pick"] != null && (int)changedProps["Pick"] != -1)
                UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, (int)changedProps["Pick"]));
            else if (changedProps["Continue"] != null && (bool)changedProps["Continue"])
                UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, -1));

            Debug.Log("MARIANA: got answer from player: " + targetPlayer.ActorNumber + " with actorId: " + targetPlayer.CustomProperties["ActorId"]);

            if (targetPlayer.ActorNumber == player1)
            {
                times1.Add(DateTime.Now);
            }
            else
            {
                times2.Add(DateTime.Now);
            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        var tempColor = textBackground.color;
        if (tempColor.a > 0.3)
        {
            tempColor.a -= 0.01f;
            textBackground.color =  tempColor;
        }

        if (Math.Abs(Time.fixedTime % 1) > 0) return;
        if (dots1.text.Equals("..."))
        {
            dots1.text = "";
            dots2.text = "";
        }
        else
        {
            dots1.text += ".";
            dots2.text += ".";
        }
    }
}

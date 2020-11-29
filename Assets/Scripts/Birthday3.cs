using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Birthday3 : MonoBehaviourPunCallbacks
{
    private EventHandler<UserReplyEventArgs> UserReplyReceived;
    private Story mainStory;
    private Story char1story;
    private Story char2story;
    private Dictionary<int, int> replies = new Dictionary<int, int>();

    

    [SerializeField] private TextAsset MainInkFile;
    [SerializeField] private TextAsset FirstCharInkFile;
    [SerializeField] private TextAsset SecondCharInkFile;


    [SerializeField] private Sprite Kitchen;
    [SerializeField] private Sprite ClaireNeutral;
    [SerializeField] private Sprite ClaireHappy;
    [SerializeField] private Sprite ClaireVeryHappy;


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
    private Image alexSprite, jesseSprite, claireSprite;
    private Text textBox;

    private int player1, player2;
    private bool other1, other2;

    List<String> tBox = new List<string>();
    Text dots1, dots2;
    private GameObject AlexThought, JesseThought;

    private List<DateTime> times1 = new List<DateTime>();
    private List<DateTime> times2 = new List<DateTime>();

    // Start is called before the first frame update
    void Start()
    {
        var imageList = Resources.FindObjectsOfTypeAll<Image>();
        var dots = FindObjectsOfType<Text>().Where(x => x.CompareTag("dots"));
        AlexThought = GameObject.FindGameObjectWithTag("TBAlex");
        JesseThought = GameObject.FindGameObjectWithTag("TBJesse");
        dots1 = dots.ElementAt(0);
        dots2 = dots.ElementAt(1);

        JesseThought.SetActive(false); AlexThought.SetActive(false);
        foreach (var VARIABLE in imageList)
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

        textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("StoryCanvas"));

        var pNum = PhotonNetwork.LocalPlayer.ActorNumber;
        player1 = Scene1Script.player1;
        player2 = Scene1Script.player2;

        replies.Add(player1, -2);
        replies.Add(player2, -2);

        mainStory = new Story(MainInkFile.text);
        char1story = new Story(FirstCharInkFile.text);
        char2story = new Story(SecondCharInkFile.text);

        mainStory = new Story(MainInkFile.text);
        char1story = new Story(FirstCharInkFile.text);
        char2story = new Story(SecondCharInkFile.text);

        setPronouns();

        if (Scene1Script.recovery)
        {
            Scene1Script.recovery = false;
            mainStory.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3Main.txt"));

            char1story.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3c1.txt"));

            char2story.state.LoadJson(
                System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3c2.txt"));

            tBox = System.IO.File.ReadAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3screenText.txt").ToList();
            foreach (var l in tBox)
            {
                textBox.text += l + "\n";
            }

            if (mainStory.variablesState["Sprite"].Equals("ClaireN"))
            {
                claireSprite.sprite = ClaireNeutral;
                claireSprite.gameObject.SetActive(true);
            }
            else if (mainStory.variablesState["Sprite"].Equals("ClaireH"))
            {
                claireSprite.sprite = ClaireHappy;
                claireSprite.gameObject.SetActive(true);
            }
            else if (mainStory.variablesState["Sprite"].Equals("ClaireV"))
            {
                claireSprite.sprite = ClaireVeryHappy;
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

        else
        {
            char1story.variablesState["giftJesse"] = GiftsChosen.giftJesse;
            char2story.variablesState["giftJesse"] = GiftsChosen.giftJesse;
            mainStory.variablesState["giftJesse"] = GiftsChosen.giftJesse;

            char1story.variablesState["giftAlex"] = GiftsChosen.giftAlex;
            char2story.variablesState["giftAlex"] = GiftsChosen.giftAlex;
            mainStory.variablesState["giftAlex"] = GiftsChosen.giftAlex;

            char1story.variablesState["numCakes"] = GiftsChosen.numCakes;
            char2story.variablesState["numCakes"] = GiftsChosen.numCakes;
            mainStory.variablesState["numCakes"] = GiftsChosen.numCakes;

            char1story.variablesState["AlexChocolate"] = GiftsChosen.AlexCakeChoc;
            char2story.variablesState["AlexChocolate"] = GiftsChosen.AlexCakeChoc;
            mainStory.variablesState["AlexChocolate"] = GiftsChosen.AlexCakeChoc;

            char1story.variablesState["JesseChocolate"] = GiftsChosen.JesseCakeChoc;
            char2story.variablesState["JesseChocolate"] = GiftsChosen.JesseCakeChoc;
            mainStory.variablesState["JesseChocolate"] = GiftsChosen.JesseCakeChoc;
        }

        char1story.ObserveVariable("Other", (variableName, value) => { other1 = ((string) value).Equals("true"); });
        char2story.ObserveVariable("Other", (variableName, value) => { other2 = ((string)value).Equals("true"); });

        UserReplyReceived += OnUserReplyReceived;
        mainStory.ObserveVariable("Background", (variableName, value) =>
        {
            if (value.Equals("Kitchen"))
                background.sprite = Kitchen;
            else if (value.Equals(""))
                background.sprite = null;
        });

        mainStory.ObserveVariable("Sprite", (variableName, value) =>
        {
            if (value.Equals("ClaireN"))
            {
                claireSprite.sprite = ClaireNeutral;
                claireSprite.gameObject.SetActive(true);
            }
            else if (value.Equals("ClaireH"))
            {
                claireSprite.sprite = ClaireHappy;
                claireSprite.gameObject.SetActive(true);
            }
            else if (value.Equals("ClaireV"))
            {
                claireSprite.sprite = ClaireVeryHappy;
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

    void BeginStory()
    {
        

    }

    void OnUserReplyReceived(object sender, UserReplyEventArgs e)
    {
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
            var choices = char2story.currentChoices;
        }
        else
        {
            var mStory = mainStory.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3Main.txt", mStory);

            var c1Story = char1story.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3c1.txt", c1Story);

            var c2Story = char2story.state.ToJson();
            System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3c2.txt", c2Story);

            System.IO.File.WriteAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT3screenText.txt",
                tBox);
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
                            {
                                AlexThought.SetActive(true);
                            }
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
                            {
                                JesseThought.SetActive(true);
                            }
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
                {"Pick", -2},
                {"Finished", "True"}
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

            var text = "Most time taken: " + timesAvg.Max() + " seconds." + "\n" + "Average time taken: " +
                       timesAvg.Average(span => span.TotalSeconds) + " seconds";
            Debug.Log("Most time taken: " + timesAvg.Max() + " seconds.");
            Debug.Log("Average time taken: " + timesAvg.Average(span => span.TotalSeconds) + " seconds.");

            System.IO.File.WriteAllText(@"D:\tese\TestResults\timesG" + Scene1Script.TestGroup + "PT3.txt", text);


            SceneManager.LoadScene("Birthday4");
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
            if (changedProps.ContainsKey("Bubbles"))
            {
                Scene1Script.BubblesOn = (bool)changedProps["Bubbles"];
                Debug.Log("Bubbles On: " + Scene1Script.BubblesOn);
                if (Scene1Script.BubblesOn) return;
                JesseThought.SetActive(false);
                AlexThought.SetActive(false);
                return;
            }
            if (changedProps["Pick"] != null && (int)changedProps["Pick"] != -1)
                UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, (int)changedProps["Pick"]));
            else if (changedProps["Continue"] != null && (bool)changedProps["Continue"])
                UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, -1));

            if (targetPlayer.ActorNumber == player1)
                times1.Add(DateTime.Now);
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
            textBackground.color = tempColor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using Ink.Runtime;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft;
using Newtonsoft.Json;

namespace Assets.Scripts
{
    class SplitScreenScript : MonoBehaviourPunCallbacks
    {
        private EventHandler<UserReplyEventArgs> UserReplyReceived;
        private Story mainStory1;
        private Story mainStory2;
        private Story char1story;
        private Story char2story;

        [SerializeField] private TextAsset MainInkFile1;
        [SerializeField] private TextAsset MainInkFile2;
        [SerializeField] private TextAsset FirstCharInkFile;
        [SerializeField] private TextAsset SecondCharInkFile;

        [SerializeField] private Sprite Store1;
        [SerializeField] private Sprite Store2;
        [SerializeField] private Sprite Cashier;
        [SerializeField] private Sprite Employee;


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

        private Image backgroundLeft, textBackgroundLeft;
        private Image backgroundRight, textBackgroundRight;
        private Image spriteRight, spriteLeft;

        private Image jesseSprite, alexSprite;

        private int player1, player2;
        private List<String> tBox1 = new List<String>(), tBox2 = new List<String>();

        private DateTime finishTime1 = DateTime.MinValue, finishTime2 = DateTime.MinValue;

        private Text textBox1, textBox2; 

        void Start()
        {
            textBox1 = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("Text1"));
            textBox2 = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("Text2"));

            foreach (var VARIABLE in Resources.FindObjectsOfTypeAll<Image>())
            {
                if (VARIABLE.CompareTag("BackgroundLeft"))
                {
                    backgroundLeft = VARIABLE;
                }
                else if (VARIABLE.CompareTag("BackgroundRight"))
                {
                    backgroundRight = VARIABLE;
                }
                else if (VARIABLE.CompareTag("TextbackgroundLeft"))
                {
                    textBackgroundLeft = VARIABLE;
                }
                else if (VARIABLE.CompareTag("TextbackgroundRight"))
                {
                    textBackgroundRight = VARIABLE;
                }

                else if (VARIABLE.CompareTag("LeftScreen"))
                {
                    spriteLeft = VARIABLE;
                }

                else if (VARIABLE.CompareTag("RightScreen"))
                {
                    spriteRight = VARIABLE;
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

            mainStory1 = new Story(MainInkFile1.text);
            mainStory2 = new Story(MainInkFile2.text);
            char1story = new Story(FirstCharInkFile.text);
            char2story = new Story(SecondCharInkFile.text);
            UserReplyReceived += OnUserReplyReceived;

            setProunouns();

            if (Scene1Script.recovery)
            {
                Scene1Script.recovery = false;
                mainStory1.state.LoadJson(
                    System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2Main1.txt"));
                mainStory2.state.LoadJson(
                    System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2Main2.txt"));

                char1story.state.LoadJson(
                    System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2c1.txt"));

                char2story.state.LoadJson(
                    System.IO.File.ReadAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2c2.txt"));

                tBox1 = System.IO.File.ReadAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2screenText1.txt")
                    .ToList();


                tBox2 = System.IO.File.ReadAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2screenText2.txt")
                   .ToList();
                foreach (var l in tBox1)
                {
                    textBox1.text += l + "\n";
                }

                foreach (var l in tBox2)
                {
                    textBox2.text += l + "\n";
                }

                if (char1story.variablesState["Background"].Equals("Store1"))
                {
                    backgroundLeft.sprite = Store1;
                }

                if (char1story.variablesState["Background"].Equals("Store2"))
                {
                    backgroundLeft.sprite = Store2;
                }

                if (char2story.variablesState["Background"].Equals("Store1"))
                {
                    backgroundRight.sprite = Store1;
                }

                if (char2story.variablesState["Background"].Equals("Store2"))
                {
                    backgroundRight.sprite = Store2;
                }

                if (char1story.variablesState["Sprite"].Equals("Employee"))
                {
                    spriteLeft.sprite = Employee;
                    spriteLeft.gameObject.SetActive(true);
                }

                if (char2story.variablesState["Sprite"].Equals("Cashier"))
                {
                    spriteRight.sprite = Cashier;
                    spriteRight.gameObject.SetActive(true);
                }

                if (Scene1Script.playerProun1 == 1)
                {
                    if (mainStory1.variablesState["AlexSprite"].Equals("Doubtful"))
                    {
                        alexSprite.sprite = alexMasDoubtful;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Happy"))
                    {
                        alexSprite.sprite = alexMasHappy;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Sidelook"))
                    {
                        alexSprite.sprite = alexMasSidelook;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Smile"))
                    {
                        alexSprite.sprite = alexMasSmile;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Smug"))
                    {
                        alexSprite.sprite = alexMasSmug;
                    }
                }
                else
                {
                    if (mainStory1.variablesState["AlexSprite"].Equals("Doubtful"))
                    {
                        alexSprite.sprite = alexFemDoubtful;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Happy"))
                    {
                        alexSprite.sprite = alexFemHappy;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Sidelook"))
                    {
                        alexSprite.sprite = alexFemSidelook;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Smile"))
                    {
                        alexSprite.sprite = alexFemSmile;
                    }
                    else if (mainStory1.variablesState["AlexSprite"].Equals("Smug"))
                    {
                        alexSprite.sprite = alexFemSmug;
                    }

                }

                if (Scene1Script.playerProun2 == 1)
                {

                    if (mainStory2.variablesState["JesseSprite"].Equals("Doubtful"))
                    {
                        jesseSprite.sprite = jesseMasDoubtful;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Happy"))
                    {
                        jesseSprite.sprite = jesseMasHappy;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Sidelook"))
                    {
                        jesseSprite.sprite = jesseMasSidelook;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Smile"))
                    {
                        jesseSprite.sprite = jesseMasSmile;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Smug"))
                    {
                        jesseSprite.sprite = jesseMasSmug;
                    }
                }
                else
                {
                    if (mainStory2.variablesState["JesseSprite"].Equals("Doubtful"))
                    {
                        jesseSprite.sprite = jesseFemDoubtful;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Happy"))
                    {
                        jesseSprite.sprite = jesseFemHappy;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Sidelook"))
                    {
                        jesseSprite.sprite = jesseFemSidelook;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Smile"))
                    {
                        jesseSprite.sprite = jesseFemSmile;
                    }
                    else if (mainStory2.variablesState["JesseSprite"].Equals("Smug"))
                    {
                        jesseSprite.sprite = jesseFemSmug;
                    }
                }

                GiftsChosen.AlexCakeChoc = ((string) char1story.variablesState["Flavor"]).ToLowerInvariant()
                    .Equals("chocolate");
                GiftsChosen.JesseCakeChoc = ((string)char2story.variablesState["Flavor"]).ToLowerInvariant()
                    .Equals("chocolate");

                if (((string) char1story.variablesState["cake"]).ToLowerInvariant().Equals("true") ) GiftsChosen.numCakes++;
                if (((string) char2story.variablesState["cake"]).ToLowerInvariant().Equals("true") ) GiftsChosen.numCakes++;

                GiftsChosen.giftAlex = (int) char1story.variablesState["chosen"];
                GiftsChosen.giftJesse = (int) char2story.variablesState["chosen"];
            }

            char1story.ObserveVariable("Background", (variableName, value) =>
            {
                if (value.Equals("Store1"))
                    backgroundLeft.sprite = Store1;
                else if (value.Equals("Store2"))
                    backgroundLeft.sprite = Store2;
                else if (value.Equals(""))
                    backgroundLeft.sprite = null;
            });

            char1story.ObserveVariable("Sprite", (variableName, value) =>
            {

                if (value.Equals("Cashier"))
                {
                    spriteLeft.sprite = Cashier;
                    spriteLeft.gameObject.SetActive(true);
                }
                else if (value.Equals("Employee"))
                {
                    spriteLeft.sprite = Employee;

                    spriteLeft.gameObject.SetActive(true);
                }
                else if (value.Equals(""))
                {
                    spriteLeft.sprite = null;

                    spriteLeft.gameObject.SetActive(false);
                }

            });

            char1story.ObserveVariable("chosen", (variableName, value) =>
            {
                GiftsChosen.giftAlex = (int)value;
            });

            char2story.ObserveVariable("chosen", (variableName, value) =>
            {
                GiftsChosen.giftJesse = (int)value;
            });


            char1story.ObserveVariable("cake", (variableName, value) =>
            {
                if (((string)value).ToLowerInvariant().Equals("true"))
                    GiftsChosen.numCakes++;
            });

            char2story.ObserveVariable("cake", (variableName, value) =>
            {
                if (((string)value).ToLowerInvariant().Equals("true"))
                    GiftsChosen.numCakes++;
            });


            char1story.ObserveVariable("Flavor", (variableName, value) =>
            {
                if (((string)value).ToLowerInvariant().Equals("chocolate"))
                    GiftsChosen.AlexCakeChoc = true;
            });
            char2story.ObserveVariable("Flavor", (variableName, value) =>
            {
                if (((string)value).ToLowerInvariant().Equals("chocolate"))
                    GiftsChosen.JesseCakeChoc = true;
            });
            char2story.ObserveVariable("Background", (variableName, value) =>
            {
                var images = Resources.FindObjectsOfTypeAll<Image>();
                if (value.Equals("Store1"))
                    backgroundRight.sprite = Store1;
                else if (value.Equals("Store2"))
                    backgroundRight.sprite = Store2;
                else if (value.Equals(""))
                    backgroundRight.sprite = null;
            });

            char2story.ObserveVariable("Sprite", (variableName, value) =>
            {

                if (value.Equals("Cashier"))
                {
                    spriteRight.sprite = Cashier;
                    spriteRight.gameObject.SetActive(true);
                }
                else if (value.Equals("Employee"))
                {
                    spriteRight.sprite = Employee;

                    spriteRight.gameObject.SetActive(true);
                }
                else if (value.Equals(""))
                {
                    spriteRight.sprite = null;

                    spriteRight.gameObject.SetActive(false);
                }
            });

            mainStory1.ObserveVariable("AlexSprite", (variableName, value) =>
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

            mainStory2.ObserveVariable("JesseSprite", (variableName, value) =>
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

            ContinueStory(new UserReplyEventArgs(player1, -1));
            ContinueStory(new UserReplyEventArgs(player2, -1));
        }

        private void setProunouns()
        {
            if (Scene1Script.playerProun1 == 1)
            {
                mainStory1.variablesState["pron_Alex"] = "he";
                mainStory2.variablesState["pron_Alex"] = "he";
                char1story.variablesState["pron_Alex"] = "he";
                char2story.variablesState["pron_Alex"] = "he";
                mainStory1.variablesState["Pron_Alex"] = "He";
                mainStory2.variablesState["Pron_Alex"] = "He";
                char1story.variablesState["Pron_Alex"] = "He";
                char2story.variablesState["Pron_Alex"] = "He";
                mainStory1.variablesState["poss_pron_Alex"] = "his";
                mainStory2.variablesState["poss_pron_Alex"] = "his";
                char1story.variablesState["poss_pron_Alex"] = "his";
                char2story.variablesState["poss_pron_Alex"] = "his";
            }

            else if (Scene1Script.playerProun1 == 2)
            {
                mainStory1.variablesState["pron_Alex"] = "she";
                mainStory2.variablesState["pron_Alex"] = "she";
                char1story.variablesState["pron_Alex"] = "she";
                char2story.variablesState["pron_Alex"] = "she";
                mainStory1.variablesState["Pron_Alex"] = "She";
                mainStory2.variablesState["Pron_Alex"] = "She";
                char1story.variablesState["Pron_Alex"] = "She";
                char2story.variablesState["Pron_Alex"] = "She";
                mainStory1.variablesState["poss_pron_Alex"] = "her";
                mainStory2.variablesState["poss_pron_Alex"] = "her";
                char1story.variablesState["poss_pron_Alex"] = "her";
                char2story.variablesState["poss_pron_Alex"] = "her";
            }

            if (Scene1Script.playerProun2 == 1)
            {
                mainStory1.variablesState["pron_Jesse"] = "he";
                mainStory2.variablesState["pron_Jesse"] = "he";
                char1story.variablesState["pron_Jesse"] = "he";
                char2story.variablesState["pron_Jesse"] = "he";
                mainStory1.variablesState["Pron_Jesse"] = "He";
                mainStory2.variablesState["Pron_Jesse"] = "He";
                char1story.variablesState["Pron_Jesse"] = "He";
                char2story.variablesState["Pron_Jesse"] = "He";
                mainStory1.variablesState["poss_pron_Jesse"] = "his";
                mainStory2.variablesState["poss_pron_Jesse"] = "his";
                char1story.variablesState["poss_pron_Jesse"] = "his";
                char2story.variablesState["poss_pron_Jesse"] = "his";
            }

            else if (Scene1Script.playerProun2 == 2)
            {
                mainStory1.variablesState["pron_Jesse"] = "she";
                mainStory2.variablesState["pron_Jesse"] = "she";
                char1story.variablesState["pron_Jesse"] = "she";
                char2story.variablesState["pron_Jesse"] = "she";
                mainStory1.variablesState["Pron_Jesse"] = "She";
                mainStory2.variablesState["Pron_Jesse"] = "She";
                char1story.variablesState["Pron_Jesse"] = "She";
                char2story.variablesState["Pron_Jesse"] = "She";
                mainStory1.variablesState["poss_pron_Jesse"] = "her";
                mainStory2.variablesState["poss_pron_Jesse"] = "her";
                char1story.variablesState["poss_pron_Jesse"] = "her";
                char2story.variablesState["poss_pron_Jesse"] = "her";
            }
        }

        public void ContinueStory(UserReplyEventArgs reply)
        {
            
            if (reply.SenderId == player1)
            {
                if (reply.Choice > -1)
                {
                    mainStory1.ChooseChoiceIndex(reply.Choice);
                    char1story.ChooseChoiceIndex(reply.Choice);
                }
                else
                {
                    var mStory1 = mainStory1.state.ToJson();
                    System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2Main1.txt", mStory1);


                    var c1Story = char1story.state.ToJson();
                    System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2c1.txt", c1Story);

                    System.IO.File.WriteAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2screenText1.txt", tBox1);
                }

                if (!char1story.canContinue && char1story.currentChoices.Count == 0 && finishTime1 == DateTime.MinValue)
                {
                    finishTime1 = DateTime.Now;
                }

                if (char1story.canContinue && mainStory1.canContinue)
                {
                    var line = mainStory1.Continue();
                    var textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("Text1"));
                    if (textBox != null && !line.Equals("...\n"))
                    {
                        var tempColor = textBackgroundLeft.color;
                        tempColor.a = 1f;
                        textBackgroundLeft.color = tempColor;
                        if (tBox1.Count == 7)
                        {
                            tBox1.RemoveAt(0);
                        }

                        if (tBox1.Count > 0)
                            tBox1[tBox1.Count - 1] =
                                tBox1[tBox1.Count - 1].Replace("<color=yellow>", "").Replace("</color>", "").Replace("\n", "");
                        tBox1.Add("<color=yellow>" + line.Replace("\n", "") + "</color>");
                        textBox.text = "";
                        foreach (var l in tBox1)
                        {
                            textBox.text += l + "\n";
                        }

                        //textBox.text = textBox.text.Replace("<color=yellow>", "").Replace("</color>", "");
                        //textBox.text += "<color=yellow>" + line + "</color>";
                    }

                    if (line.Equals("...\n"))
                    {
                        var tempColor = textBackgroundLeft.color;
                        tempColor.a = 0.3f;
                        textBackgroundLeft.color = tempColor;
                    }

                    var phoneStoryLine = char1story.Continue();
                    string choice0 = "", choice1 = "", choice2 = "";

                    var player = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player1);

                    if (char1story.currentChoices.Count > 0)
                    {
                        choice0 = char1story.currentChoices[0].text;
                    }

                    if (char1story.currentChoices.Count > 1)
                    {
                        choice1 = char1story.currentChoices[1].text;
                    }

                    if (char1story.currentChoices.Count > 2)
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
                    if (!phoneStoryLine.Equals("...\n"))
                    {
                        properties.Add("Vibrate", true);
                    }

                    player.Value.SetCustomProperties(properties);

                }

                else
                {
                    var player = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player1);

                    var properties = new ExitGames.Client.Photon.Hashtable()
                    {
                        {"StoryText", ""},
                        {"Choice0", ""},
                        {"Choice1", ""},
                        {"Choice2", ""},
                        {"Continue", false},
                        {"Pick", -2},
                        {"ActorId", 2 }
                    };

                    player.Value.SetCustomProperties(properties);

                    var otherPlayer = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player2);

                    if ((int) otherPlayer.Value.CustomProperties["Pick"] == -2 &&
                        SceneManager.GetActiveScene().name.Equals("SplitScreen"))
                    {
                        var text = "Time waited: " + (finishTime1 > finishTime2
                                       ? finishTime1.Subtract(finishTime2).TotalSeconds + " seconds."
                                       : finishTime2.Subtract(finishTime1).TotalSeconds + " seconds.") 
                                                   + "\nFinish time of first player: " + finishTime1
                                                   + "\nFinish time of second player: " + finishTime2; 

                        System.IO.File.WriteAllText(@"D:\tese\TestResults\times\timesG" + Scene1Script.TestGroup + "PT2.txt", text);
                        SceneManager.LoadScene("Transition2");
                    }

                }
            }

            else
            {
                if (reply.Choice > -1)
                {
                    mainStory2.ChooseChoiceIndex(reply.Choice);
                    char2story.ChooseChoiceIndex(reply.Choice);
                }

                else
                {
                    var mStory2 = mainStory2.state.ToJson();
                    System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2Main2.txt", mStory2);

                    var c2Story = char2story.state.ToJson();
                    System.IO.File.WriteAllText(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2c2.txt", c2Story);

                    System.IO.File.WriteAllLines(@"D:\tese\RecoveryFiles\G" + Scene1Script.TestGroup + "PT2screenText2.txt", tBox2);
                }

                if (!char2story.canContinue && char2story.currentChoices.Count == 0 && finishTime2 == DateTime.MinValue)
                {
                    finishTime2 = DateTime.Now;
                }

                if (char2story.canContinue && mainStory2.canContinue)
                {
                    var line = mainStory2.Continue();
                    var textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("Text2"));
                    if (textBox != null && !line.Equals("...\n"))
                    {
                        var tempColor = textBackgroundRight.color;
                        tempColor.a = 1f;
                        textBackgroundRight.color = tempColor;

                        if (tBox2.Count == 5)
                        {
                            tBox2.RemoveAt(0);
                        }

                        if (tBox2.Count > 0)
                            tBox2[tBox2.Count - 1] = 
                                tBox2[tBox2.Count - 1].Replace("<color=yellow>", "").Replace("</color>", "").Replace("\n", "");
                        tBox2.Add("<color=yellow>" + line.Replace("\n", "") + "</color>");
                        textBox.text = "";
                        foreach (var l in tBox2)
                        {
                            textBox.text += l + "\n";
                        }
                    }

                    if (line.Equals("...\n"))
                    {
                        var tempColor = textBackgroundRight.color;
                        tempColor.a = 0.3f;
                        textBackgroundRight.color = tempColor;
                    }

                    var phoneStoryLine = char2story.Continue();
                    string choice0 = "", choice1 = "", choice2 = "";

                    var player = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player2);

                    if (char2story.currentChoices.Count > 0)
                    {
                        choice0 = char2story.currentChoices[0].text;
                    }

                    if (char2story.currentChoices.Count > 1)
                    {
                        choice1 = char2story.currentChoices[1].text;
                    }

                    if (char2story.currentChoices.Count > 2)
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
                        {"ActorId", 1}
                    };

                    if (!phoneStoryLine.Equals("...\n"))
                    {
                        properties.Add("Vibrate", true);
                    }
                    player.Value.SetCustomProperties(properties);
                }
                else
                {
                    var player = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player2);

                    var properties = new ExitGames.Client.Photon.Hashtable()
                    {
                        {"StoryText", ""},
                        {"Choice0", ""},
                        {"Choice1", ""},
                        {"Choice2", ""},
                        {"Continue", false},
                        {"Pick", -2},
                        {"ActorId", 2}
                    };

                    player.Value.SetCustomProperties(properties);
                    var otherPlayer = PhotonNetwork.CurrentRoom.Players
                        .FirstOrDefault(x => x.Value.ActorNumber == player1);

                    if ((int) otherPlayer.Value.CustomProperties["Pick"] == -2)
                    {
                        var text = "Time waited: " + (finishTime1 > finishTime2
                                       ? finishTime1.Subtract(finishTime2).TotalSeconds + " seconds."
                                       : finishTime2.Subtract(finishTime1).TotalSeconds + " seconds.") 
                            + "\nFinish time of first player: " + finishTime1 + "\nFinish time of second player: " + finishTime2;

                        System.IO.File.WriteAllText(@"D:\tese\TestResults\times\timesG" + Scene1Script.TestGroup + "PT2.txt", text);
                        SceneManager.LoadScene("Transition2");
                    }

                }
            }
        }

        void OnUserReplyReceived(object sender, UserReplyEventArgs e)
        {
            ContinueStory(e);
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (changedProps.ContainsKey("Bubbles"))
            {
                Scene1Script.BubblesOn = (bool)changedProps["Bubbles"];
                Debug.Log("Bubbles On: " + Scene1Script.BubblesOn);
                return;
            }
            if (targetPlayer.ActorNumber !=
                PhotonNetwork.LocalPlayer.ActorNumber)
            {
                if (changedProps["Pick"] != null && (int)changedProps["Pick"] != -1)
                    UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, (int)changedProps["Pick"]));
                else if (changedProps["Continue"] != null && (bool)changedProps["Continue"])
                    UserReplyReceived?.Invoke(this, new UserReplyEventArgs(targetPlayer.ActorNumber, -1));

                //if (targetPlayer.ActorNumber == player1)
                //{
                //    finishTime1 = DateTime.Now;
                //}

                //else if (targetPlayer.ActorNumber == player2)
                //{
                //    finishTime2 = DateTime.Now;
                //}
                Debug.Log("MARIANA: got answer from player: " + targetPlayer.ActorNumber + " with actorId: " + targetPlayer.CustomProperties["ActorId"]);
            }
        }
        // Update is called once per frame
        void Update()
        {
            var tempColor = textBackgroundLeft.color;
            if (tempColor.a > 0.3)
            {
                tempColor.a -= 0.01f;
                textBackgroundLeft.color = tempColor;
            }

            tempColor = textBackgroundRight.color;
            if (tempColor.a > 0.3)
            {
                tempColor.a -= 0.01f;
                textBackgroundRight.color = tempColor;
            }
        }
    }
}

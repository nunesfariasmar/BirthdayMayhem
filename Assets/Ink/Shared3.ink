VAR Background =""
VAR Sprite =""
VAR JesseFirst = false
VAR giftAlex = -1
VAR giftJesse = -1
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"
VAR numCakes = 0
VAR AlexChocolate = false
VAR JesseChocolate = false
~Background = "Kitchen"
VAR AlexSprite = "Smile"
VAR JesseSprite = "Smile"

~AlexSprite = "Doubtful"
~JesseSprite = "Smug"
Jesse and Alex are hiding behind the kitchen table. One reads a magazine, the other holds a lighter.
The "Claire surprise party" is about to start any minute now.
"What is taking her so long?!" Alex asks, clearly irritated.
...
~JesseSprite = "Sidelook"
~AlexSprite = "Smile"
"Probably traffic... Claire is not the best driver." Jesse answers.
...
~JesseSprite = "Smug"
Alex smiles at Jesse, seemingly amused.
"So..." Jesse says. "What did you get Claire?"

    *[...]
    ~AlexSprite = "Smug"
    "Only the best gift ever!" Alex answers, full of confidence.
    ...
    Jesse is looking at Alex attentively, to which Alex just smiles in response.
    ~JesseSprite = "Smile"
    ...
    "That's nice..." Jesse finally says after a stretched pause.
   ->N2
    *[...]
    ~AlexSprite = "Happy"
    "Nothing special, just a small thing." Alex says, with a small smile.
    ~JesseSprite = "Sidelook"
    ...
    ...
    ...
   ->N2
    *[...]
    ~AlexSprite = "Smug"
    "Ohh... You'll see it soon..." Alex says, smiling sneakily.
    ...
    "Keeping it mysterious... I see..." Jesse answers, with a mischievous smile of {poss_pron_Jesse} own.
   ->N2
    
===N2===
~AlexSprite = "Doubtful"
"What about you?" Alex inquires. "Ready to impress Claire?"

    *[...]
    ~JesseSprite = "Smile"
    "I tried to get something special." Jesse says, seeming genuine.
    Jesse smiles, probably thinking about the gift.
   ->N3
    *[...]
    ~JesseSprite = "Doubtful"
    "I got her a nice gift..." Jesse answers, looking down at {poss_pron_Jesse} nails.
    ...
   ->N3
    *[...]
    ~JesseSprite = "Smug"
    "Soon enough you will find out." Jesse answers, trying to add to the mystery.
    ...
    ~AlexSprite = "Sidelook"
    Alex sticks {poss_pron_Alex} tongue out at Jesse in retaliation.
   ->N3
    
===N3===
~AlexSprite = "Doubtful"
Before they have time to continue with their quirky banter, the friends hear the sound of keys rattling at the door.
Jesse and Alex are startled by this. Alex jumps up instantly, like a scared cat. {Pron_Alex} let's the lighter slip.
The lighter describes an arc in the air and hits Jesse on {poss_pron_Jesse} forehead.
~JesseSprite = "Sidelook"
...
Jesse hands the lighter to Alex with a wink.
~JesseSprite = "Smug"
Both are moving franticly, trying to light the candles on a cupcake they had laying around the kitchen.
...
...
...
...
They manage to light the first candle just in time to see the door starting to open.
...
The person that was opening the door enters the house.
...
...
Both candles are lit. Just in time for Claire to walk into the kitchen.
Birthday chants erupt from both Jesse and Alex as Claire smiles, excited.
~JesseSprite = "Happy"
~AlexSprite = "Happy"
"Happy birthday to you... Happy birthday to you... Happy birthday dear Claire! Happy birthday to you!" They sing in unison.
~Sprite = "ClaireN"
...
~Sprite = "ClaireH"
"A surprise birthday party? For the 4th year in a row? I'm so surprised!!!"  Claire says sarcastically.
...
->N4
===N4===

    *[...]
        "Are you surprised?" Alex asks wide-eyed.
        "Yes! I have never been this surprised, to be honest!" Claire answers, with a chuckle.
        Alex and Jesse laugh.
       ->N4
    *[...]
        "Now, for the main event..." Alex says.
        "Ladies and gentlemen this is the moment we've been waiting for..." Jesse sings.
        ...
       ->N5
        
===N5===
~Sprite = "ClaireN"
~JesseSprite = "Smile"
~AlexSprite = "Smile"
"So... Who is going first?" Claire asks, smiling at her friends.
"Wow, what happened to 'I don't care for the presents?'" Jesse asks, giving her the side-eye.
...
"Well..." Claire says with a sly smile. "I am very excited about the cake." She admits.
...
After a beat, she adds "There is a cake right?"
{numCakes == 0:->NoCake |->ThereIsCake}
===NoCake===
~JesseSprite = "Doubtful"
~AlexSprite = "Doubtful"
Jesse and Alex exchange looks, and Claire watches their eyes grow wider.
"I thought you would buy it..." Jesse starts, timidly.
"Well..." Alex answers. "I thought you would buy it..."
~JesseSprite = "Sidelook"
~AlexSprite = "Sidelook"
...
"It's okay..." Claire finally says after some time.
...
"There is a cupcake..." Jesse tells her, trying to make her feel better.
->AfterCake
===ThereIsCake===
"Of course there is cake!" Alex says, smiling.
{numCakes == 2: Jesse raises two of {poss_pron_Jesse} fingers, winking at her.}
Claire's mouth draws an O, as she is all excited. "Chocolate?"
{AlexChocolate && JesseChocolate: Both Alex and Jesse wink at Claire.}
{AlexChocolate && (!JesseChocolate): Alex winks at Claire.}
{(!AlexChocolate) && JesseChocolate: Jesse winks at Claire yet again.}
{(!AlexChocolate) && (!JesseChocolate):->NoChocolateCake}
Claire claps her hands very enthusiastically.
->AfterCake
===NoChocolateCake===
Jesse points at Alex as if asking 'did you' in between the lines.
Alex shakes her head. They look at Claire, shrugging.
{numCakes == 2: "Well... At least there are two cakes..." Claire says, trying not to sound too disappointed. | "Well... At least there is a cake..." Claire says, clearly disappointed.}
~JesseSprite = "Sidelook"
~AlexSprite = "Sidelook"
...
->AfterCake
===AfterCake===
"So..." Claire finally says after a second. "Who wants to go first?"
~Sprite = "ClaireN"
    *[...]
    ~JesseFirst = true
     "I want to go first!" Jesse says raising {poss_pron_Jesse} arm and shaking it vigorously, clearly enthused.
    "Is that okay Alex?" Claire asks sheepishly.
    "Humm..." Alex starts as if {pron_Alex}'s plotting something. "I will allow it!"->JesseGift
    *[...]
    ~JesseFirst = false
    "Alex can go first!" Jesse answers.
    "Oh? Scared, are we?" Alex asks, with a smirk.
    "Not really... I'm very excited to see your gift tho!" They banter.
   ->AlexGift
    
===JesseGift===
~Sprite = "ClaireH"
{giftJesse == 1:->JesseBeans}
{giftJesse == 2:->JessePaint}
{giftJesse == 3:->JesseDictionary}
->END

===JesseBeans===
Jesse removes a big colorful bag from {pron_Jesse} bag and raises it.
Claire and Alex's eyes widen as Jesse raises the bag.
"I bestow upon thee the gift of diabetes!" Jesse declares faking some trumpet sounds.
Alex claps her hands. It's a big bag of jelly beans.
~Sprite = "ClaireH"
~JesseSprite = "Smile"
~AlexSprite = "Smile"
"Wow! Thank you, Jesse! That's pretty cool!" Claire says, smiling, nudging Jesse lightly with her arm.
"You should share that!" Alex adds quickly.
In response, Claire unwraps her present and throws a bean in Alex's direction.

    *[...]
   ->WrongDirection
    *[...]
   ->RightDirection
    *[...]
   ->WrongDirection
===WrongDirection===
~JesseSprite = "Happy"
~AlexSprite = "Doubtful"
Everyone watches the bean as it flies across Alex and hits the floor.
...
->AfterBean

===RightDirection===
Everyone watches the bean as it flies and Alex opens {pron_Alex} mouth, just at the right time to catch it!
"Ohhh!!!" surprised chants erupt from Jesse and Claire, as they clap in admiration.
~JesseSprite = "Happy"
~AlexSprite = "Happy"
~Sprite = "ClaireV"
Alex crosses {poss_pron_Alex} arms with a smug smirk on {poss_pron_Alex} lips, chewing on the bean.
...
->AfterBean
===AfterBean===
{JesseFirst:->AlexGift}
->Reaction
===JessePaint===
Jesse picks a pastel colored package in the shape of a box and gives it to Claire.
Claire begins ripping the wrapping apart. Jesse and Alex hear a faint gasp as realization downs on her.
Claire has just received a box set of guaches. Her smile grows wider.
~Sprite = "ClaireV"
~JesseSprite = "Happy"
~AlexSprite = "Happy"
"This is great, it is exactly what I wanted!" Claire says hugging Jesse. "Thank you."
{JesseFirst && (giftAlex == 1): ...->AlexGift}
{(JesseFirst == false) && giftAlex == 1: "This is awesome!!! Did you guys plan the best gift ever together?" Claire asks.}
...
{JesseFirst:->AlexGift}
->Reaction
===JesseDictionary===
Jesse removes a package from {poss_pron_Jesse} bag and hands it to Claire.
Claire begins ripping the wrapping apart.  She seems confused.
~Sprite = "ClaireN"
~JesseSprite = "Doubtful"
~AlexSprite = "Doubtful"
...
"It's a..." Alex starts, waiting for someone to finish the sentence.
"A dictionary?" Claire asks.
...
"Yeah... Because you like big words!" Jesse tries to explain.
"Wow... That's nice. Thank you, Jesse, it's pretty nice." Claire says with a faint smile.
...
Everyone is feeling a bit awkward.
{JesseFirst:->AlexGift |->Reaction}
->Reaction
===AlexGift===
~Sprite = "ClaireH"
{giftAlex == 1:->AlexCanvas}
{giftAlex == 2:->AlexBat}
{giftAlex == 3:->AlexBook}
->END

===AlexCanvas===
Alex picks up a very large package and gives it to Claire.
...
Claire promptly attacks the wrapping paper savagely. Her eyes start to shine.
Jesse gives Claire a side look. Claire reveals the set of canvases and brushes.
~Sprite = "ClaireV"
~JesseSprite = "Happy"
~AlexSprite = "Happy"
{JesseFirst && (giftJesse == 2): "This is awesome!!! Did you guys plan the best gift ever together?" Claire asks.}
{(!JesseFirst) && (giftJesse == 2): ...}
Claire gives Alex a big hug, messing up {poss_pron_Alex} hair. "Thank you so much, Al! This is an awesome gift!"
...
{JesseFirst:->Reaction}
->JesseGift
===AlexBat===
Alex removes a package conveniently shaped as a bat of some sort from behind the table.
...
Alex hands the gift to Claire, who starts unwrapping the gift.
~Sprite = "ClaireN"
~JesseSprite = "Doubtful"
~AlexSprite = "Doubtful"
"Oh... A softball bat... To had it to my Softball bat collection... Thanks!" Claire says, awkwardly.
The silence that follows is uncomfortable. Jesse laughs trying to make it better "You don't like it?" Alex asks.
"No! No! I like it... I just have... A lot of them already." Claire explains.
...
{JesseFirst:->Reaction}
->JesseGift
===AlexBook===
Alex picks up a discrete package from {poss_pron_Alex} bag, wrapped in a shinny green paper.
"I hope you like it!" Alex says, handing it to Claire.
She picks up the package like it is something precious and carefully releases it from the wrapping.
...
~Sprite = "ClaireH"
~JesseSprite = "Smile"
~AlexSprite = "Smile"
"Oh... Alice in Wonderland!" Claire says, showing off the book. "I used to love this book!"
"That's adorable!" Jesse adds, with a smile.
"Thank you!" Claire says at last.
{JesseFirst:->Reaction}
->JesseGift
===Reaction===
{numCakes > 0: Claire takes a deep breath and looks at both Jesse and Alex with a smile. "Now we can have cake!!!" | }
{numCakes > 0: Jesse gestures at the cake and says "Let's go!"}
...
~JesseSprite = "Sidelook"
"Did you enjoy your gifts?" Alex asks, almost upset.
"I loved them!" Claire starts, smiling at her friends. "But I liked that you guys are here even more!"
"Sure..." Alex answers, totally unconvinced. After a beat, {pron_Alex} adds. "Lame..."
~JesseSprite = "Smile"
{giftAlex == 1 && giftJesse == 2: "I mean it... Plus your gifts were amazing! And they complement each other." Claire says, all smiles.}
{(giftAlex != 1) || (giftJesse != 2): "Ok then..." Claire says, defeated. "How about I tell you my favorite gift after dinner?"}
...
~Sprite = "ClaireV"
~AlexSprite = "Smile"
"Now... Can we please get this party started?" Claire asks finally.
The friends smile at each other.
~JesseSprite = "Happy"
~AlexSprite = "Happy"
...
...
...
Jesse, Claire, and Alex have a nice night {numCakes > 0: eating cake and celebrating. | celebrating.}
->END
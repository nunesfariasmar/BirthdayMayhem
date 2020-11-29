VAR giftAlex = -1
VAR giftJesse = -1
VAR Other = "false"
VAR JesseFirst = false
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"
VAR numCakes = 0
VAR AlexChocolate = false
VAR JesseChocolate = false







...
Alex is sitting across from you, visibly distressed. Almost shaking.
...
That is Alex's brand, always worried about something. Must be exhausting.


...
You're not being mean for saying that... You're being realistic. 

You have sworn to never get into her car ever again.
...
~Other = "true"
    *[...]
    
    ...
    Alex seems very confident in {poss_pron_Alex} present. 
    ...
    
    Claire will for sure love it!
    ...
   ->N2
    *[...]
    
    ...
    
    You're almost sure it has to be something special.
    Alex's gifts are always so thoughtful.
    You decide not to say anything and just smile to yourself.
   ->N2
    *[...]
    
    ...
    It sounds kind of ominous... You wonder why {pron_Alex} wants to keep it mysterious.  
    ...
   ->N2
    
===N2===

...
~Other = "false"
    *["I tried to get something special."]
    
    ...
    Hopefully, Claire will agree that it is something special!
   ->N3
    *["I got her a nice gift..."]
    
    ...
    Alex doesn't say anything to that.
   ->N3
    *["Soon enough you will find out."]
    
    ...
    You only want to leave Alex curious!
    
    ...
   ->N3
    
===N3===

...
Claire's here!!! Time to get everything ready!
...

"I'm sorry!!" you hear Alex whispers loudly, clearly distressed... As usual.
...

You whisper "Hurry Up!" as you get up.
It's a bit of a tradition you three have. On a birthday, you always light up two candles on a cupcake.
Just a plain old and stale cupcake you have in your kitchen, usually for that purpose only.
You can see Alex's handshaking, trying to light up the candles.
That's probably a fire hazard... You look up trying to figure out if there are fire detectors.
Unfortunately, there are none... Fortunately, there's only one candle left to light up.
The erratic look in Alex's eyes is very worrisome, so much so that you catch yourself whispering "Oh no..."
Alex's hand is shaking so much that you wonder what is preventing the flame from being extinguished.
Of course that shaking that hard the candle won't lit up.
You consider holding Alex's arm and steadying it but at the last instant the candle lights.
It's a miracle because at that exact moment Claire walks in.
...


...

Claire's hands fly instinctively to her face in mock surprise.

...
She does have a way with words. Must be why you three are friends.
->N4
===N4===
~Other = "true"
    *[...]
        ...
    Surely Claire has stopped being surprised by the third year...
        ...
       ->N4
    *[...]
        ...
        ...
        As soon as you sing it, you regret it. You feel Alex and Claire judging you, it's not pleasant.
       ->N5
        
===N5===



...
...
Claire always argues that "you don't need to" get her a present because it's not what her birthday is about.
...
Knowing Claire as you do, she's probably telling the truth.
...
{numCakes == 0:->NoCake |->ThereIsCake}
===NoCake===


Did Alex also not get a cake? That can't be good.
...
...


Well... It can't be helped now... 
...
But it is a bit sad to have a birthday party without a cake.
...
->AfterCake
===ThereIsCake===
...
{numCakes == 2: ...}
...
{AlexChocolate && JesseChocolate:  Of course being the great friend you are, you remembered Claire loves chocolate!}
{AlexChocolate && (!JesseChocolate): ...}
{(!AlexChocolate) && JesseChocolate:  Of course being the great friend you are, you remembered Claire loves chocolate!}
{(!AlexChocolate) && (!JesseChocolate):->NoChocolateCake}
...
->AfterCake
===NoChocolateCake===
...
...
{numCakes == 2:...|...}


It's a bit sad there isn't a chocolate cake... But at least there is cake.
->AfterCake
===AfterCake===
...
~Other = "false"
    *["I want to go first!"]
    ~JesseFirst = true
   ...
    ...
    ...->JesseGift
    *["Alex can go first!"]
    ...
    You know how excited Alex is to show {poss_pron_Alex} gift!
    ...
   ->AlexGift
    
===JesseGift===

{giftJesse == 1:->JesseBeans}
{giftJesse == 2:->JessePaint}
{giftJesse == 3:->JesseDictionary}
->END

===JesseBeans===
...
...
...
You think both Alex and Jesse look excited!



You'd probably be excited too if you got that gift!
...
...
~Other = "true"
*[...]
   ->WrongDirection
    *[...]
   ->RightDirection
    *[...]
   ->WrongDirection
===WrongDirection===


...
Oh, so close... You're sure you would have caught it if it were you! 
->AfterBean

===RightDirection===
...
...



...
You gotta admit... That was pretty impressive!
->AfterBean
===AfterBean===
{JesseFirst:->AlexGift}
->Reaction
===JessePaint===
...
...
Just looking at the box, the colors look very pretty!



...
{AlexGift == 1 && JesseFirst: Jesse seems really happy!->AlexGift}
You feel great for having picked up the guaches now! Claire has loved your gift!
{(!JesseFirst) && AlexGift == 1: ...}
{JesseFirst:->AlexGift}
->Reaction
===JesseDictionary===
...
...



As you see her unwrap the book, you start to become concerned.
...
...
What were you thinking? 
...
...
Why would you have bought that? You feel bad but Claire is still smiling, trying to reassure you.
...
{JesseFirst:->AlexGift}
->Reaction
===AlexGift===

{giftAlex == 1:->AlexCanvas}
{giftAlex == 2:->AlexBat}
{giftAlex == 3:->AlexBook}
->END

===AlexCanvas===
...
Wow... What could be Alex's gift? You know surprise is all over your face.
...
...



{JesseFirst && giftJesse == 2: ...}
{giftJesse == 2 && (!JesseFirst): Oh wow! That's great... It's almost as if you guys have picked your gifts together!}
...
You gotta give props to Alex for {poss_pron_Alex} gift!
{JesseFirst:->Reaction}
->JesseGift
===AlexBat===
...
When did Alex have the time to hide it behind the table?
...



...
...
...
Suddenly you feel sad about Alex's expression.
{JesseFirst:->Reaction}
->JesseGift
===AlexBook===
...
...
...
You try to see what the gift is over Claire's shoulder.



"Oh... Alice in Wonderland!" Claire says, delighted. "I used to love this book!"
You can't help but smile. "That's adorable!"
...
{JesseFirst:->Reaction}
->JesseGift
===Reaction===
{numCakes > 0:...}
{numCakes > 0:...}
Now, time for dinner...

...
...
You get the feeling Alex is not convinced at all!


{giftAlex == 1 && giftJesse == 2: ...}
{(giftAlex != 1) || (giftJesse != 2): ...}
You don't care about that... You're just happy to be here celebrating with your friends!
...

...


You silently agree that maybe Claire is right.
Maybe being together is the best gift that can be...
That makes you happy!
But for now, it's time to celebrate!
->END
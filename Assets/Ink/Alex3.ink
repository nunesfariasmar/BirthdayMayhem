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
Jesse seems to be distracted by the magazine. You wish you could be as calm and collected.
...
She is always late... Even to her own surprise birthday party.


...
Last time you were in the same car as Claire, you swore you would get life insurance.

Thinking about that makes you want to smile.
...
~Other = "false"
    *["Only the best gift ever!"]
 
    ...
    You are sure, 100% positive that Claire will absolutely love your gift.
    ...
 
    You wonder is Jesse is feeling a bit worried now.
    ...
   ->N2
    *["Nothing special, just a small thing."]

    ...
 
    You were a lot more sure about your gift when you left the store... Now, not so much.
    You sense Jesse looking at you and avoid the stare.
    You still hope Claire likes it.
   ->N2
    *["Ohh... You'll see it soon..."]
 
    ...
    You savor the feeling of knowing something Jesse doesn't. It's sweet.
    ...
   ->N2
 
===N2===

...
~Other = "true"
    *[...]
 
    ...
    Yeah, whatever! It can be as special as possible as long as your gift is better!
   ->N3
    *[...]
 
    ...
    A short yet humble response.
   ->N3
    *[...]
 
    ...
    You're trying to understand if Jesse's answer is a good sign or not...
 
    ...
   ->N3
 
===N3===

...
Oh no!!! Claire is here!!! Panic mode on!
...

"I'm sorry!!" You whisper (shout) very fast.
...

"Hurry up!" {Pron_Jesse} whispers to you, trying to make you less nervous.
You have less than 0.5 seconds to light the candles on the cupcake.
It's a bit of a tradition you three have. On a birthday, you always light up two candles on a cupcake.
Just a plain old and stale cupcake you have in your kitchen, usually for that purpose only.
The tension is excruciating... It's like you're seeing everything unfold in slow motion.
...
You can hear a faint "Ohh" from Jesse, that is distorted by the slow-motion you're experiencing.
You point the lighter at the second candle and are all of a sudden glad Claire is not a centenary lady.
The candle won't work! It just won't light up! Light is coming in from the hallway.
Finally, at the last possible moment, the candle catches on fire.
Just as Claire walks in the room you and Jesse start singing.
...


...

Claire covers her mouth with both hands in surprise, or some feeling similar.

...
If she just knew the distressed she just caused you for being older than 10 and therefore needing two candles.
->N4
===N4===
~Other = "false"
    *["Are you surprised?"]
    It's a rhetorical question, you're pretty sure she's not surprised at all.
    ...
    ...
   ->N4
    *["Now, for the main event..."]
    ...
    ...
    Ugh... You really do hate that song!
   ->N5
  
===N5===



...
...
Oh please, Jesse... You also want to get to the gifts as soon as possible!
...
Oh please... As if Claire isn't excited to know who the big winner (you) is!
...
{numCakes == 0:->NoCake |->ThereIsCake}
===NoCake===


Did... Jesse not get a cake?!
...
...


Oh no! This is already a disaster! How could you both forget to get a birthday cake?!
...
It's actually not okay... We're off to a bad start...
...
->AfterCake
===ThereIsCake===
...
{numCakes == 2: ...}
...
{AlexChocolate && JesseChocolate: Of course being the great friend you are, you remembered Claire loves chocolate!}
{AlexChocolate && (!JesseChocolate): Of course being the great friend you are, you remembered Claire loves chocolate!}
{(!AlexChocolate) && JesseChocolate: ...}
{(!AlexChocolate) && (!JesseChocolate):->NoChocolateCake}
...
->AfterCake
===NoChocolateCake===
...
No... I didn't...
{numCakes == 2: ... | ...}


Oh... You should have remembered to pick up a chocolate cake... At least there's cake...
->AfterCake
===AfterCake===
...
~Other = "true"
    *[...]
    ~JesseFirst = true
    ...
    ...
    We should always save the best for last...->JesseGift
    *[...]
    ...
    Of course {pron_Jesse} would be...
    ...
   ->AlexGift
 
===JesseGift===

{giftJesse == 1:->JesseBeans}
{giftJesse == 2:->JessePaint}
{giftJesse == 3:->JesseDictionary}
->END

===JesseBeans===
...
Soon you realize that the bag isn't colorful, its' content is... Jelly beans!
...
...



...
A challenge presents itself!
You try to anticipate the bean trajectory. You think it is going...
~Other = "false"
    *[... to your right.]
   ->WrongDirection
    *[... right to your mouth.]
   ->RightDirection
    *[... to your left.]
   ->WrongDirection
===WrongDirection===


...
Argh!! So close!! 
->AfterBean

===RightDirection===
...
...



Yes! You're amazing! 
You're the best!!! Or at least you feel like it right now! 
->AfterBean
===AfterBean===
{JesseFirst:->AlexGift}
->Reaction
===JessePaint===
...
...
You can see a colorful package... It looks very pretty!



...
{giftAlex == 1 && JesseFirst: Oh wow! That's great... It's almost as if you guys have picked your gifts together!->AlexGift}
{(!JesseFirst) && giftAlex == 1: ...}
Even tho you want to win... You can't help but commend Jesse for {poss_pron_Jesse} amazing gift!
{JesseFirst:->AlexGift}
->Reaction
===JesseDictionary===
...
...



What is it? A book?
...
...
A dictionary? What kind of gift is that? 
...
...
You feel a tiny bit sad for Jesse... Even if this means you get to win... Claire's reaction is a bit underwhelming.
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
Since you have purchased various canvases in various sizes, your gift is a rather large package.
...
...



{JesseFirst && JesseGift == 2: ...}
{JesseGift == 2 && (!JesseFirst): The glint in Claire's eyes makes you happy! }
...
You're really happy with your choice.
{JesseFirst:->Reaction}
->JesseGift
===AlexBat===
...
So much for surprises... 
...



...
Claire looks disappointed...
...
You are a bit sad, a bit disappointed, and too ashamed to look at Jesse.
{JesseFirst:->Reaction}
->JesseGift
===AlexBook===
...
...
Time for the big reveal!
You can see from the corner of your eye Jesse looking over your shoulder, curious.



...
Claire's response fills your heart and makes you really happy.
...
{JesseFirst:->Reaction}
->JesseGift
===Reaction===
{numCakes > 0: ...}
{numCakes > 0: ...}
So... what about the gifts?! Who is the winner?

...
...
Is Claire being annoying on purpose?!

{giftAlex == 1 && giftJesse == 2: ...}
{(giftAlex != 1) || (giftJesse != 2): ...}
You smile at her... At least Claire is happy... You'll enjoy the party now and rate the gifts later.


...
...


You silently agree that maybe Claire is right.
Maybe being together is the best gift that can be...
Which of course won't stop the competition next year.
But for now, it's time to celebrate!
->END
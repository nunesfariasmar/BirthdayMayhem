VAR jesse_lied = false
VAR Background =""
VAR Pepper = false
VAR Sprite =""
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"
VAR AlexSprite = "Smile"
VAR JesseSprite = "Smile"

~AlexSprite = "Smile"
~JesseSprite = "Smile"
~Background = "Kitchen"
Two teens sit around their kitchen table, in their house. Cold pizza lays at the table near half-empty cups of energy drinks.
One of them, Alex looks mindfully at the pizza. The other, Jesse, reads a magazine.
...
...
~AlexSprite = "Doubtful"
    *[...]
        ~Pepper = true
        ->Pepper_Choice_Yes
    *[...]
        ->Pepper_Choice_No
===Pepper_Choice_Yes===
~JesseSprite = "Doubtful"
...
...
->AfterPepper
===Pepper_Choice_No===
~JesseSprite = "Doubtful"
...
...
->AfterPepper
===AfterPepper==
~AlexSprite = "Sidelook"
    *[...]
        "Why would you put bell pepper on pizza?" Alex asks Jesse, suddenly.
        ->N2
        
    *[...]
        "Do you think bell pepper is a fruit or a vegetable?" Alex asks Jesse, suddenly.
        ~JesseSprite = "Doubtful"
        ...
        ...
        {Pepper: ...}
        {(!Pepper): ...}
        
        **[...]
            ~JesseSprite = "Smug"
            "It's a fruit!" Jesse answers. "It comes from a tree!"
            Alex nods slightly.
            ->N3
            
        **[...]
            ~JesseSprite = "Smug"
            "It's a vegetable!" Jesse answers. "It goes on pizza"
            ...
            "Pineapple also goes on pizza and it's a fruit.." Alex promptly replies.
            "That's debatable..." Jesse adds sharply.
            ->N3
        
        **[...]
            "I don't know." Jesse says with a shrug of the shoulder.
            ...
            ->N3
            
    *[...]
        ~AlexSprite = "Sidelook"
        "This is the most disgusting thing I've ever laid eyes on..."Alex says, clearly disgusted looking at the pizza.
        ->N2
    
===N2===
...
...
{Pepper: ...}
{(!Pepper): ...}
->N3

===N3===
~JesseSprite = "Smug"
"It's not that bad!" Jesse argues, taking a piece of pizza from the box and biting into it. 

    *[...]
        ~JesseSprite = "Smile"
        "Next time I'll let you pick the toppings." Jesse adds.
        ~AlexSprite = "Smug"
        Alex gives Jesse a suspicious look.
        ->N4
    
    *[...]
        "Just pick them out of the slices." Jesse says.
        {Pepper: Alex starts picking out the bell peppers.}
        {(!Pepper): Alex starts picking out the bell peppers.}
        ->N4
        
    *[...]
    
        "Don't be such a baby about it!" Jesse says, mockingly.
        ~JesseSprite = "Sidelook"
        ~AlexSprite = "Sidelook"
        **[...]
           "DoN'T bE sUcH A bAby!" Alex adds in a baby voice. 
           ...
            ->N4
        
        **[...]
            ...
            ->N4

===N4===
~AlexSprite = "Smile"
~JesseSprite = "Smile"
Jesse starts reading the magazine again. Alex picks up a cup of soda and takes a sip.
...
...
"Claire is a Leo, right?" Jesse asks suddenly.
...
~AlexSprite = "Sidelook"
"Her birthday is coming up!" Alex concludes, surprised.
~JesseSprite = "Sidelook"
The two friends look at each other.
...
...
... 
...
"So, do you have a gift yet?" Alex asks, looking straight at Jesse.
~AlexSprite = "Doubtful"
...
~JesseSprite = "Doubtful"
    *[...]
    ~JesseSprite = "Smug"
    "Yeah..." Jesse answers.
    ~AlexSprite ="Sidelook"
    Surprise crosses Alex's face, but only for a fraction of a second.
    ~jesse_lied = true
    ->N5
    *[...]
    "Not really..." Jesse answers.
    ~AlexSprite = "Smile"
     A flash of a smile crosses Alex's face, but just as quickly fades away.
    ~jesse_lied = false
    ->N5
    
===N5===
~JesseSprite = "Doubtful"
"What about you?" Jesse asks.
    
    *[...]
    ~AlexSprite = "Smug"
    "I have bought something yes." Alex says.
    ...
    ->N6
    
    *[...]
    "I forgot..." Alex admits.
    ->N6

===N6===
...
A third friend enters the house, in a hurry. It's Claire.
~JesseSprite = "Happy"
~AlexSprite = "Happy"
She's the third housemate of Alex and Jesse. She's just returned from work.
~Sprite = "Claire"
"I'm so sorry I'm late!" Claire says, entering the kitchen in a hurry. "Traffic was crazy!"
Both Jesse and Alex say hi. Claire picks up a slice of pizza, biting into it immediately.
"Who puts bell pepper on pizza?" Claire asks, sounding disgusted.
Alex points at Jesse just as fast! Jesse simply shrugs.
{(!Pepper): ...}
{Pepper: ...}
Claire walks around the table as if looking for something.
"Oh..." She says almost like she's disappointed. "There is no chocolate?"
...
The rest of the night progresses uneventfully. It's Friday so you stay up late, chatting.
During the night, Claire shows off some new portraits she's been working on.
...
The friends spend the rest of the night laughing, reading comic books, and eating cold pizza.
->END
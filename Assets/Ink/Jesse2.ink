VAR visitA1 = false
VAR visitA2 = false
VAR visitA3 = false
VAR chosen = 0
VAR Background = ""
VAR Sprite = ""
VAR StoreName = ""
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"
VAR cake = "false"
VAR Flavor = ""


It's early in the morning. A sunny Saturday morning... Perfect to spend inside a store.
Notice the irony.
...
Time for some sale hunting.
Why are there always so many people in places like this?
It almost makes you wish some unforeseen event would send everyone home for a couple of weeks...
Almost...
Time to choose what store to visit! Both stores are big department stores where you can find different things.
You know what they say... Quantity over Quality!
    *Cranny's Nook
        ~StoreName = "Cranny's Nook"
        ->Store
    *The Invulnerable Vagrant 
        ~StoreName = "The Invulnerable Vagrant"
        ->Store
===Store===
~Background = "Store1"
...
...
You need to think carefully about what to get to Claire.
Something that Claire will love would be best! 
If only people made a habit of telling each other what they want for their birthday...
Luckily for you, {StoreName} has a big variety of goods at your disposal.
...


->Aisle_Selection
===Aisle_Selection===
{!Which Aisle do you want to visit?|You wonder what Alex might be buying... Which Aisle do you want to visit?|Which Aisle do you want to visit?}
    *Aisle 1 - Candy
    
        ~visitA1 = true
        ...
        ...
        ...
        You do know Claire doesn't enjoy liquor tho...
        ...
        
        With the money you have, you can probably get 3 kgs of Jelly Beans.
        Would Claire like that as a birthday gift?
        You certainly would like that for yourself... In all honesty, you believe anyone would enjoy that!
        ->Aisle_Selection
    *Aisle 2 - DIY materials
        ~visitA2 = true
        ...
        ...
        You find the ladybug pattern especially appealing.
        ...
        ...
        That would be a sick gift to give Claire, with her blossoming artist career.
        It would be even better if you could give it with a set of canvas to use on...
        But unfortunately, you don't have enough money to buy both gifts.
        However, it would be very nice if Alex thought about it! It would make the perfect gift.
        ->Aisle_Selection
    *Aisle 3 - Books
        ~visitA3 = true
        ...
        You look around but you were never a person who enjoyed reading, so you feel a bit lost.
        You don't know what type of literature Claire is into if any at all.
        ...
        Maybe Wuthering Heights is a good book? 
        Pride and Prejudice has a movie, right?
        ...
        Dictionaries... Words... Claire likes big words right?
        Well... It's an option.
        ->Aisle_Selection
    *{visitA2 || visitA1 || visitA3} [I've already decided what to buy!]
        ->BuyItem
    *->BuyItem
    
===BuyItem===
You have decided to buy
    *{visitA1} A gigantic bag of Jelly Beans.
    ~chosen = 1
    ->Payment
    *{visitA2} A set of gouaches.
    ~chosen = 2
    ->Payment
    *{visitA3} A dictionary.
    ~chosen = 3
    ->Payment
    
===Payment===
You approach the girl at the cashier with {chosen==1: the bag of Jelly Beans}{chosen==2: the box set of gouaches}{chosen==3: the dictionary}. 
~Sprite = "Cashier"
...
"Is this a gift? Do you want me to wrap it?" She asks you.
    *[Yes and yes!]
    ...
        {chosen==1 || chosen==2: ...}
        {chosen==3: ...}
        {chosen==3: ...}
        {chosen==3: ...}
    You leave the store with your purchase, a satisfied smile, and the feeling of accomplishment!
    ->OutStore
    
    *[Yeah... I guess you could say that. It's my housemate!]
    ...
        {chosen==1 || chosen==2: ...}
        {chosen==3: ...}
        {chosen==3: ...}
        {chosen==3: ...}
    You leave the store with your purchase, a satisfied smile, and the feeling of accomplishment!
    ->OutStore
    
    *[That's none of your business.]
    ...
    That answer catches her by surprise.
    ...
    You leave the store with your purchase, a satisfied smile, and the feeling of accomplishment!
    ->OutStore
===OutStore==

After leaving the store you consider if you should order a birthday cake for Claire.
Will Alex order it? Or should you do it?
    *[Order it!]
    ~cake = "true"
    You decide to order a cake! If Alex decides to order a cake... Well... more cake!
    What flavor would you like your cake to be?
        **[Strawberry]
        Strawberry it is!
        ...
        ->END
        **[Chocolate]
        ~Flavor = "Chocolate"
        Chocolate it is!
        ...
        ->END
        **[Vanila]
        Vanilla it is!
        ...
        ->END
    
    *[Don't order it.]
    You're sure Alex has thought of the cake... Hopefully, it won't be some weird flavor cake...
    Can you imagine a Bell Pepper flavored cake?
    The thought makes you wheeze.
    ...
->END
VAR visitA1 = false
VAR visitA2 = false
VAR visitA3 = false
VAR chosen = 0
VAR StoreName = ""
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"
VAR JesseSprite = "Smile"

~JesseSprite = "Smile"

It's an early Saturday morning.
...
Jesse picks up {poss_pron_Jesse} backpack and leaves the house in search of adventure!
~JesseSprite = "Happy"
...
On the way to the store, {pron_Jesse} crosses some people. Mostly joggers and dog walkers.
When Jesse reaches {poss_pron_Jesse} destination, there are already some people roaming around.
~JesseSprite = "Sidelook"
...
...
...
~JesseSprite = "Doubtful"
    *...
        ~StoreName = "Cranny's Nook"
        ->Store
    *...
        ~StoreName = "The Invulnerable Vagrant "
        ->Store
===Store===
~JesseSprite = "Smile"
Jesse enters {StoreName} slowly. The bell attached to the door chims.
The girl standing behind the counter winks at Jesse as {pron_Jesse} crosses the door.
...
...
...
...
There are 3 aisles Jesse can visit.
~JesseSprite = "Doubtful"
->Aisle_Selection
===Aisle_Selection===
{!...|...|...}
    *...
    ~JesseSprite = "Smug"
        ~visitA1 = true
        Jesse approaches the first Aisle, which is mainly composed of a vast assortment of candies.
        There are numerous types of gummies in shapes and colors that resemble real food but somehow all taste the same.
        There are a diversity of liquor chocolates on the shelve.
        ...
        And of course, there are the classic Jelly Beans.
        ~JesseSprite = "Sidelook"
        ...
        ...
        Jesse seems deep in thoughts over what {pron_Jesse} is seeing in the aisle.
        ->Aisle_Selection
    *...
    ~JesseSprite = "Smug"
        ~visitA2 = true
        Jesse walks into the DIY materials aisle and is quickly submerged in a world of bright colors and glue guns.
        There are cardboards with different textures and patterns.
        ...
        There are many different jars filled with bits and beads... And even glitter.
        And then Jesse sees it. A box of 32 Gouaches, beautiful colors.
        ~JesseSprite = "Happy"
        ...
        ...
        Jesse seems to be doing some calculations with no calculator.
        ...
        ->Aisle_Selection
    *...
    ~JesseSprite = "Smug"
        ~visitA3 = true
        Jesse enters the Book aisle. Various shelves are populated with big long books.
        ...
        ...
        {Pron_Jesse} looks and looks but no title picks {poss_pron_Jesse} attention.
        ~JesseSprite = "Sidelook"
        ...
        ...
        Jesse's eyes lay on a big dictionary.
        ...
        Jesse looks around and does a little scratch of the head.
        ->Aisle_Selection
    *{visitA2 || visitA1 || visitA3} [...]
        ->BuyItem
    *->BuyItem
    
===BuyItem===
~JesseSprite = "Smile"
...
    *{visitA1} Jesse has decided what to buy.
    ~chosen = 1
    ->Payment
    *{visitA2} Jesse has decided what to buy.
    ~chosen = 2
    ->Payment
    *{visitA3} Jesse has decided what to buy.
    ~chosen = 3
    ->Payment
    
===Payment===
Jesse approaches the girl at the cashier with the item. 

The girl smiles at Jesse. The plaque on her chest informs Jesse she's named Grace.
"Is this a gift? Do you want me to wrap it?" She asks {poss_pron_Jesse}.
    *[...]
    "Yes and yes!" Jesse tells her and smiles.
    ~JesseSprite = "Happy"
        {chosen==1 || chosen==2: "It's a very nice gift!" she tells Jesse with a smile of her own.}
        {chosen==3: "Oh... It's an... Interesting gift!" she tells Jesse.}
        {chosen==3: She scans the book and looks at Jesse again. "Is your friend a foreigner?"}
        {chosen==3: "No." Jesse answers, getting upset with this conversation.}
    Jesse leaves the store with a satisfied smile!
    ->OutStore
    
    *[...]
    ~JesseSprite = "Doubtful"
    "Yeah... I guess you could say that. It's my housemate!" Jesse tells her and smiles.
        {chosen==1 || chosen==2: "It's a very nice gift!" she tells {poss_pron_Jesse} with a smile of her own.}
        {chosen==3: "Oh... It's an... Interesting gift!" she tells Jesse.}
        {chosen==3: She scans the book and looks at Jesse again. "Is your friend a foreigner?"}
        {chosen==3: "No." Jesse answer, getting upset with this conversation.}
    Jesse leaves the store with a satisfied smile!
    ->OutStore
    
    *[...]
    ~JesseSprite = "Sidelook"
    "That's none of your business." Jesse tells her with a straight face.
    Suddenly the cashier looks serious. Jesse seems to have upset her.
    She simply scans the item and Jesse catches her rolling her eyes.
    Jesse leaves the store with a satisfied smile!
    ->OutStore
===OutStore==
~JesseSprite = "Smile"
...
...
    *[...]
    
    ...
    ...
        **[...]
        ...
        Jesse is seen visiting the bakery before {pron_Jesse} heads home. What could {pron_Jesse} be doing there?
        ->END
        **[...]
        
        ...
        Jesse is seen visiting the bakery before {pron_Jesse} heads home. What could {pron_Jesse} be doing there?
        ->END
        **[...]
        ...
        Jesse is seen visiting the bakery before {pron_Jesse} heads home. What could {pron_Jesse} be doing there?
        ->END
    
    *[...]
    ...
    ...
    ...
    Jesse heads straight home after leaving the store.
->END
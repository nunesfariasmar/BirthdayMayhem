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

It's early Saturday morning and time is running out. 
You would never admit this but you are a bit nervous about the race to get the best present!
So you've picked up your money, traced the map from the house to the mall, and devised a strategy.
It is fundamental to get a good gift! A different gift from Jesse's! And most importantly...
A better Gift than Jesse's!
...
...

What store would you like to visit? Choose wisely for you only have time to visit one store.
  *Cloud 9 Superstore
  ~StoreName = "Cloud 9 Superstore"
    ->Store
  *Gnome Depot
  ~StoreName = "Gnome Depot"
    ->Store
===Store===
~Background = "Store2"
...
...

Ok, you need to think rationally about what to get. That's the only way you will be able to beat Jesse.
Just thinking about winning this competition makes you want to evil laugh.
...
->Aisle_Selection
===Aisle_Selection===
{!Which Aisle do you want to visit?|You wonder what Jesse might be buying... Which Aisle do you want to visit next?|Which Aisle do you want to visit next?}
    ~Sprite = ""
  *Aisle 1 - Office Materials
    ~visitA1 = true
    ...
    ...
    ~Sprite = "Employee"
    ...
      **["I'm not sure."]
        ...
        ...
        You are not... But you do know one artist... Aspiring one, at least.
        ...
        If you add some brushes... It would be perfect with a set of paint, but unfortunately, they are sold out!
        
        ...
        ...
        So you have a set of canvases and brushes to give out. It might seem a bit cheap without paint.
        But Jesse knows Claire is an artist... Maybe you should text Jesse, give them a tip about the gift.
        Only that... What if Jesse was to backstab you?! And you buy some brushes and they come out with something grander?
        Like... A car? What if Jesse buys a new Tesla for Claire's birthday? 
        No! Better be safe than sorry!
        It would be nice nonetheless.
        ->Aisle_Selection
      **["I'm looking for a birthday gift."]
        ...
        ...
        ...
        ...
        Humm... What is Claire like? Claire is a dear friend that enjoys sunny afternoons, chocolate cake, and art.
        ...
        ...
        Even you, who have no idea what the usual price of the item is impressed.
        If you add some brushes... It would be perfect with a set of paint, but unfortunately, they are sold out!
        ...
        ...
        
        So you have a set of canvases and brushes to give out. It might seem a bit cheap without paint.
        But Jesse knows Claire is an artist... Maybe you should text Jesse, give them a tip about the gift.
        Only that... What if Jesse was to backstab you?! And you buy some brushes and they come out with something grander?
        Like... A car? What if Jesse buys a new Tesla for Claire's birthday? 
        No! Better be safe than sorry!
        It would be nice nontheless.
        ->Aisle_Selection
  *Aisle 2 - Sports
    ~visitA2 = true
    ...
    ...
    ...
    ...
    {visitA1: Now would be a good time to have the help of a store employee.}
    What would be a good sports gift for Claire that would beat Jesse's gift?
    Claire was part of the softball team when she was younger.
    Maybe bringing back memories with a softball bat would be nice... And enough to beat Jesse.
    ->Aisle_Selection
  *Aisle 3 - Books
    ~visitA3 = true
    The books aisle is, as you expected, filled to the brim with books.
    Your first instinct is to look for comic books and manga.
    Unfortunately, this section of the aisle is seriously lacking in all aspects.
    What else could she like? How much you would give to know what Jesse is going to give her.
    You notice a special hardcover edition of Alice in Wonderland and suddenly you remember how much Claire liked that book.
    Seems like a very cool alternative.
    ->Aisle_Selection
  *{visitA1 || visitA2 || visitA3} I've already decided what to buy.
    ->BuyItem
  *->BuyItem
  
===BuyItem===
You have decided to buy...
  *{visitA1} A set of canvases and brushes.
  ~chosen = 1
  ->Payment
  *{visitA2} A softball bat.
  ~chosen = 2
  ->Payment
  *{visitA3} An Alice in Wonderland book.
  ~chosen = 3
  ->Payment

===Payment===

You're almost sure this year is yours!
After leaving the store, you remember you should probably get a birthday cake for Claire.
Do you really think Jesse, middle name Airhead, will remember to get a cake?
  *[I'll get a cake.]
  ~cake = "true"
  There is no such thing as too many cakes anyway!
  What flavor should you get?
    **[Chocolate.]
    ~Flavor = "chocolate"
    You can't really go wrong with a chocolate cake, especially for Claire.
    ...
    ->END
    **[Lemon.]
    Lemon, because you have a refined taste!
    ...
    ->END
    **[Birthday cake flavor with a bunch of funfetti.]
    Go crazy!! Add all of the funfetti!
    ...
    ->END
  *[Jesse probably will get a cake.]
  Surely Jesse has already bought a cake... Best not to worry about it.
  ...
->END
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
VAR AlexSprite = "Smile"

~AlexSprite = "Smile"
It's an early Saturday morning. 
...
...
...
...
Alex heads to  the mall
As Alex enters the complex, {pron_Alex} sees some people roaming around... Which is odd considering the time of day...
~AlexSprite = "Doubtful"
Alex is considering what store to visit.
    *...
    ~StoreName = "Cloud 9 Super Store"
        ->Store
    *...
    ~StoreName = "Gnome Depot"
        ->Store
===Store===

Alex enters {StoreName}. {Pron_Alex} sees some people already roaming the corridors, enjoying the items on sale.
Some employees are also roaming around, helping costumers and replenishing stock.
~AlexSprite = "Smile"
...
...
Alex looks carefully at the aisle directory and picks up 3 {pron_Alex} finds appropriate.
->Aisle_Selection
===Aisle_Selection===
{!...|...|...}
~AlexSprite = "Doubtful"
    *...
        ~visitA1 = true
        Alex heads into the Office Materials aisle and looks around.
        All of a sudden a store employee that has been restocking shelves approaches {poss_pron_Alex}.
        
        "Hello!" He says, a wide smile on his lips. "Do you need help?"
            **[...]
                "I'm not sure." Alex tells him, with an unsure look on {poss_pron_Alex} face.
                "Well, we are having a huge sale on canvases... Are you perchance an artist?" He asks Alex.
                ...
                Alex looks at the price of the canvases and even {pron_Alex}, who has no idea what the usual price of the item is impressed.
                {pron_Alex} looks at the employee satisfied. 
                ~AlexSprite = "Happy"
                "Thanks!" {pron_Alex} says, to which the employee answers with a triumphant smile and a thumbs up!
                ...
                ...
                Alex picks up the phone, typing something... A text, perhaps?
                ...
                Alex puts the phone away with a vigorous shake of the head.
                ...
                Alex seems conflicted.
                ->Aisle_Selection
            **[...]
                "I'm looking for a birthday gift." Alex tells him.
                "Ohh... Someone special?" He asks with a mock tone.
                "Yeah... I guess you could say that... It's for my housemate." {pron_Alex} answers.
                "So... What are they like? What do they like?"
                ...
                "I guess she likes... Arts?"
                The employee seems delighted with Alex's answer. "Well, we are having a huge sale on canvases..."
                Alex looks at the prices of the items the employee pointed out.
                ...
                {pron_Alex} looks at the employee satisfied. 
                ~AlexSprite = "Happy"
                "Thanks!" {pron_Alex} says, to which the employee answers with a triumphant smile and a thumbs up!
                ...
                Alex picks up the phone, typing something... A text, perhaps?
                ...
                Alex puts the phone away with a vigorous shake of the head.
                ...
                Alex seems conflicted.
                ->Aisle_Selection
    *...
        ~visitA2 = true
        Alex heads in the direction of the sports aisle.
        There are shelves on shelves on shelves of different types of balls.
        Soccer balls, Football balls, tennis balls, golf balls... Colorful bouncy balls.
        There are also many different types of shoes for different kinds of sports.
        {visitA1:...}
        ...
        ...
        Alex nods at no one.
        ->Aisle_Selection
    *...
        ~visitA3 = true
        Alex heads in the direction of the books aisle.
        ...
        ...
        ...
        ...
        Alex seems to have reached a conclusion and is satisfied.
        ->Aisle_Selection
    *{visitA1 || visitA2 || visitA3} ...
        ->BuyItem
    *->BuyItem
    
===BuyItem===
...
    *{visitA1} Alex has decided what to buy.
    ~chosen = 1
    ->Payment
    *{visitA2} Alex has decided what to buy.
    ~chosen = 2
    ->Payment
    *{visitA3} Alex has decided what to buy.
    ~chosen = 3
    ->Payment

===Payment===
~AlexSprite = "Smile"
Alex exits the store with {poss_pron_Alex} purchase.
...
...
    *[...]
    
    ...
    ...
        **[...]
        
        ...
        Alex heads in into the bakery at the mall... What could {pron_Alex} possibly be buying there?
        ->END
        **[...]
        ...
        Alex heads in into the bakery at the mall... What could {pron_Alex} possibly be buying there?
        ->END
        **[...]
        ...
        Alex heads in into the bakery at the mall... What could {pron_Alex} possibly be buying there?
        ->END
    *[...]
    ...
    Alex heads hope straight away.
->END
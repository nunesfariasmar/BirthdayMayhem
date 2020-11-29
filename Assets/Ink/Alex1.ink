VAR jesse_lied = false
VAR Other = "false"
VAR Pepper = false
VAR pron_Alex = "they"
VAR Pron_Alex = "They"
VAR poss_pron_Alex = "their"
VAR pron_Jesse = "they"
VAR Pron_Jesse = "They"
VAR poss_pron_Jesse = "their"






...

Jesse sits at the table across from you reading a magazine.
You deliberate if you should take another piece of pizza but after giving it a second look, you remember the pieces of bell pepper on it.
Do you like bell pepper on pizza?
~Other = "false"
     *[Yes]
        ~Pepper = true
        ->Pepper_Choice_Yes
    *[No]
        ->Pepper_Choice_No
===Pepper_Choice_Yes===

Jesse must have remembered you really like Pepper on pizza.
Even so, you wanna mess with Jesse and pretend you don't like pepper!
->AfterPepper
===Pepper_Choice_No===

What kind of psychopath puts pepper on pizza?
The kind to be called Jesse, that's who.
->AfterPepper
===AfterPepper===
~Other = "false"
     *[Why would you put bell pepper on pizza?]
        ...
        ->N2
        
     *[Do you think bell pepper is a fruit or a vegetable?]
         ...
        
        You see Jesse's eyes studying you, almost playfully.
        You get the feeling that the choice to put bell Peppers on the pizza was deliberate.
         {Pepper: Jesse must have thought you didn't like peppers after all!}
        {(!Pepper): Jesse likes "pranks" like that.}
        ~Other = "true"
         **[...]
        
            ...
            You have no objections to that argument.
            ->N3

         **[...]
        
            ...
             Since when is that a good criterion for vegetables?
            ...
            ...
            ->N3
        
        **[...]
            ...
            You think it is probably a fruit.
            ->N3
            
    *[This is the most disgusting thing I've ever laid eyes on...]
    
        ...
        ->N2
        
===N2===
You see Jesse's eyes studying you, almost playfully.
You get the feeling that the choice to put Bell Peppers on the pizza was deliberate.
{Pepper: Jesse must have thought you didn't like peppers after all!}
{(!Pepper): Jesse likes "pranks" like that.}
->N3

===N3===

...
        ~Other = "true"
    *[...]
    
        ... 
        
        You're already plotting what could be very gross on pizza. Banana maybe? This will require some planning.
        ->N4
        
        *[...]
            ...
            {Pepper: Should you take the peppers out and keep messing with Jesse? Maybe...}
            {(!Pepper): It's not like you didn't know that already... How much pepper pieces can a slice of pizza have?!}
            ->N4
        
        *[...]
        ~Other = "false"
        ...
        
        
            **[DoN'T bE sUcH A bAby!]
                ...
                Jesse just gives you a roll of the eyes.
                ->N4
                
            **[Say nothing.]
                What Jesse said upset you a bit but you have learned to not take it personally.
                ->N4

===N4===


...
The bubbles fizz in your nose and you wrinkle it.
You kind of enjoy that sensation.
...
You nod absently until you realize what that means. 

...
Your eyes lock on each other for a fraction of a second. Sparks seem to fly. You both look down.

This is good. It means you still have time.
Neither you nor Jesse would ever admit to it but Claire's birthday has a bit of a tradition behind it.
It's like a competition... Each year you try to get the best possible present you can for Claire.
You win if your present is better than Jesse's. You have won 3 out of the 6 last years, according to your own parameters.
...

Jesse sounds almost worried.
    ~Other = "true"
    *[...]
    
    ...
    
    Damn it! You're already at a disadvantage... You need to act fast if you want to buy the best gift!
    ~jesse_lied = true
    ->N5
    *[...]
    ...
    
    That's good! It gives you time to prepare. You still have a chance after all!
    ~jesse_lied = false
    ->N5
    
===N5===

...
    ~Other = "false"
    *[I have bought something yes...]
    
    ...
    You lie.
    ->N6
    
    *[{jesse_lied: I forgot...| I also forgot...}]
    ...
    ->N6
    
===N6===
Jesse simply nods and seems to forget all about the topic.
You need to get to it as soon as possible. This is a tie-breaking year.


You will go shopping tomorrow first thing in the morning.

...
...
...
...
{(!Pepper): Yes, at least two of you have some common sense!}
{Pepper: You're unsure if Claire truly dislikes bell peppers or if she's just like you!}
...
...
You look at Jesse... Claire is a known chocoholic. Unfortunately, there's no chocolate in sight!
...
...
She's been improving at a very fast pace.
Eventually, one by one, you all retire to bed to rest for a couple of hours.
->END
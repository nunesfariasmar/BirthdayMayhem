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

You're reading a random magazine you found in the bathroom earlier.
You've reached the zodiac page... Time to see how the week is gonna go...
Not that you believe it, it's more like you find it fun... Also, when has a little bit of orientation ever hurt anyone?
~Other="true"
     *[...]
          ~Pepper = true
          ->Pepper_Choice_Yes
     *[...]
          ->Pepper_Choice_No
===Pepper_Choice_Yes===

As for Sagittarius, you get the insight that you probably should be avoiding stairs.
Very Interesting... Let's hope the building's elevator doesn't break down.
->AfterPepper
===Pepper_Choice_No===

As for Sagittarius, you get the insight that you probably should be avoiding stairs.
Very Interesting... Let's hope the building's elevator doesn't break down.
->AfterPepper
===AfterPepper===
     ~Other = "true"
     *[...]
          ...
          ->N2
          
     *[...]
          ...
          
          You lift your eyes from the magazine and look at Alex. In truth, you chose bell peppers only because you knew Alex would be annoyed by them.
          Not that bell peppers on pizza are bad...
          {Pepper: From a scale of 0 to pepperoni, Bell peppers on pizza is probably a 6, a 4.5 at a minimum. }
          {(!Pepper): From a scale of 0 to pepperoni, Bell peppers on pizza is probably a 6, a 4.5 at a minimum. }
          ~Other = "false"
          **[Fruit!]
          
               ...
               Alex seems to agree with you.
               ->N3
               
          **[Vegetable!]
          
               ...
               Alex seems surprised by your answer.
               ...
               ...
               ->N3
          
          **[I don't know.]
              ...
               Alex doesn't press you on the matter.
               ->N3
               
     *[...]
     
         ...
          ->N2
     
===N2===
You lift your eyes from the magazine and look at Alex. 
Bell peppers on pizza are not bad...
{Pepper: From a scale of 0 to pepperoni, Bell peppers on pizza is probably 6, a 4.5 at a minimum.}
{(!Pepper): From a scale of 0 to pepperoni, Bell peppers on pizza is probably 6, a 4.5 at a minimum.}
->N3

===N3===

...
     ~Other = "false"
     *[Next time I'll let you pick the toppings.]
     
          ...
          
          The look Alex gives you next is worrisome. You may come to regret this decision.
          ->N4
     
     *[Just pick them out of the slices...]
          ...
          {Pepper: Alex does as you suggested, but with a resentful expression. You were just trying to be helpful.}
          {(!Pepper): Alex does as you suggested, but with a resentful expression. You were just trying to be helpful.}
          ->N4
          
     *[Don't be such a baby about it!]
          ~Other = "true"
          ...
          
          
          **[...]
              ...
              So mature as usual...
               ->N4
          
          **[...]
               Alex says nothing and you decide to drop the subject.
               ->N4

===N4===


You know that Alex is a Pisces so you take a quick peek at that horoscope.
'Eat more vegetables' it advises... And you find that very appropriate.
You start to wonder about other friends to check their horoscope. You look up at Alex.
...
Alex nods slowly, realization slowly downing on {poss_pron_Jesse} features. 

...

Your eyes lock on each other for a fraction of a second. Sparks seem to fly. You both look down.
How could you have forgotten? Again?
Yeah, last year you picked a gift 30 minutes before the party.
And because of that, Claire didn't really like your gift. 
But Alex always puts a lot of effort into the gifts {pron_Alex} give Claire.
...

Could it be that you're not the only one that forgot?
     ~Other = "false"
     *[Yeah!]

     ...

     You lie.
     ~jesse_lied = true
     ->N5
     *[Not really...]
     ...

     ...
     ~jesse_lied = false
     ->N5
     
===N5===

...
     ~Other = "true"
     *[...]

     ...
     You're not sure you believe it.
     ->N6
     
     *[...]
     ...
     ->N6

===N6===
You nod at Alex and try to appear unbothered by it.
At least this time you have time to think about a gift. Maybe you and Alex could team-up.


You could both get a gift together or somehow two gifts that complement each other.

...
...
...
...
{(!Pepper): Maybe you should consider getting more mature friends.}
{Pepper: Maybe you should consider getting more mature friends.}
...
...
You and Alex exchange a look. Claire is a known chocoholic. Unfortunately, there's no chocolate in sight!
...
...
She's been improving at a very fast pace.
Eventually, one by one, you all retire to bed to rest for a couple of hours.
->END
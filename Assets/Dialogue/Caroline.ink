EXTERNAL addQuest(questName)
# speaker Caroline
VAR completable_carolinestart = false
VAR completed_chipstrawberrywatering = false
VAR completed_carolinestart = false
VAR completable_carolinefishing = false
VAR completable_carolinesecretquest = false
VAR completed_carolinesecretqueststart = false
VAR completable_carolinesecretqueststart = false
VAR completable_helpfromcaroline = false
VAR completed_helpfromcaroline = false
VAR completable_getcaroline = false
VAR completed_getcaroline = false
VAR completed_carolinefishing = false


{

    - completed_getcaroline == true:
        -> CantWait
    - completable_getcaroline == true:
        -> FirstTalk
    - completable_helpfromcaroline == true || completed_carolinestart == false:
        -> FirstTalk
    - completed_helpfromcaroline == true:
        -> ApplePieLater
    - completed_carolinefishing == true:
        -> ThanksForHelp
    - completable_carolinefishing == true:
        -> FinishQuest
}


=== FirstTalk ===

Oh, hey Ethan! What a surprise! What brings you here?

+ {completable_getcaroline} Nosh-Up is about to start!
    -> NoshUp
+ {completable_helpfromcaroline} Darcy told me that you can make an apple pie.
    -> ApplePie
+ {completable_carolinestart} Chip told me that you have a problem.
    -> TellProblem
+ Never mind.
    -> NeverMind


=== ThanksForHelp ===

Hey Ethan! Thank you again for helping me with my dish!
    -> END


=== FinishQuest ===

Hey Ethan, did you manage to catch some fish?

+ {completable_carolinefishing} Yes, here they are!
    -> GiveFish
+ Just wanted to check on you.
    -> CheckCaroline


=== GiveFish ===

# completeQuest CarolineFishing

Thank you so much, Ethan! I'm so happy that you helped me out! You can come by again some time if you want!
    -> END


=== CheckCaroline ===

That's so sweet of you, Ethan! I'm doing great, thank you for asking!
    -> END


=== TellProblem ===

 Yes, that's right! The thing is, I want to make a fish filet for Nosh-Up, but I don't know how to fish any fish. That's where you come into play.

+ What should I do?
    -> AcceptQuestOne


=== AcceptQuestOne ===

Could you fish up four fish for me on the beach? It doesn't have to be done today, another day is fine as long as I can get that meal done before Nosh-Up begins!

    + Sure, I can do that!
        -> AcceptQuest
    + Maybe later.
        -> NotAcceptQuest



=== AcceptQuest ===

# addQuest CarolineFishing
# completeQuest CarolineStart

Thank you, Ethan! I appreciate it a lot! Just go to the beach via horse carriage next to my house and fish at the peer! I'll be waiting for you!
    -> END


=== NotAcceptQuest ===

Alright, just come by again later!
    -> END


=== NeverMind ===

Alright, have a good day!

    -> END


=== SecretQuest ===

Oh hey Ethan! I'm so happy to see you! How are you doing?

    + Doing great, how about you?
        -> GreatAnswer
    + Could be better...
        -> BadAnswer


=== GreatAnswer ===

That's good to here! I'm doing great as well, thanks for asking! Anyways, I wanted to tell you a legend I've liked since I'm a kid. It's about a fish that is called 'Elaine'. It is said, that this fish was so beautiful, they symbolized it with love. They are rarely seen in the water but in the legends they say when the village is getting together, the fish will appear!

    + That sounds like a great legend!
        -> StartSecret


=== BadAnswer ===

That's not good to hear... How about a little legend to cheer you up? I've liked it since I was a kid! It's the most beautiful fish in the world 'Elaine'. In the legends they say that this fish was so beautiful, they symbolized it with love! They are rarely seen in the water, but they say that this fish will appear, when the village is about to get together!

    + Sounds like a great legend!
        -> StartSecret


=== StartSecret ===

# completeQuest CarolineSecretQuestStart
# addQuest CarolineSecretQuest

I hope I'll see an 'Elaine' one day. But the best thing would be if a specific person would bring it to me! That would mean a lot to me!

    -> END


=== FinishSecret ===

Hey Ethan! How can I help you?

    + {completable_carolinesecretquest} I've found something very special to you!
        -> FinishSecretQuest
    + Just wanted to check on you.
        -> CheckCarolineTwo
    

=== FinishSecretQuest ===

Oh my god! You caught an 'Elaine'? I never would have thought that they actually exist! Thank you so much for this experience, I appreciate it a whole lot! I have one more thing to ask though!

    + What is it?
        -> Favour


=== CheckCarolineTwo ===

Nawww, that's so sweet!

    -> END


=== Favour ===

Would you mind sitting next to me during Nosh-Up? I would really appreciate it!

    + Sure, sounds like fun!
        -> Promise


=== Promise ===

# completeQuest CarolineSecretQuest

Hooray! That's a promise! See you there! a

    -> END


=== ApplePie ===

Yes, I can bake an excellent apple pie just hand me over the apples!

    + Here!
        -> Apples


=== Apples ===

# completeQuest HelpFromCaroline

Perfect! I'll bring you the apple pie at the start of Nosh-Up! See you there!

    + See you there!
        -> END
    

=== ApplePieLater ===

Hey Ethan, I'll bring you the apple pie at the start of Nosh-Up!
    -> END


=== NoshUp ===

# completeQuest GetCaroline
# teleport GetCaroline

Fantastic! I hope I'll see you there soon!
    -> END


=== CantWait ===

I can't wait for it to start soon!
    -> END
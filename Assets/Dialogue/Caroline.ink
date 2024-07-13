EXTERNAL addQuest(questName)
# speaker Caroline
VAR completable_carolinestart = false
VAR completed_chipstrawberrywatering = false
VAR completed_carolinestart = false
VAR completable_carolinefishing = false


{
    -completed_carolinestart == false:
        -> FirstTalk
    - completable_carolinefishing == true:
        -> FinishQuest
}


=== FirstTalk ===

Oh, hey Ethan! What a surprise! What brings you here?

+ {completable_carolinestart} Chip told me that you have a problem.
    -> TellProblem
+ Never mind.
    -> NeverMind


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

 Yes, that's right! The thing is, I want to make a fish filet for Nosh-Up, but I don't know how to fish any fish. That's where you come into play. Could you fish up four fish for me on the beach? It doesn't have to be done today, another day is fine as long as I can get that meal done before Nosh-Up begins!

+ Sure, I can do that for you!
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
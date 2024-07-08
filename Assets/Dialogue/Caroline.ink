EXTERNAL addQuest(questName)
# speaker Caroline
VAR completable_carolinefishing = false
VAR 

Oh, hey Ethan! What a surprise! What brings you here?

+ "Ok."
    -> StartQuest
+ "No."
    -> DidntAccept
+ {finished_carolinefishing} "Here."
    -> FinishQuest

=== StartQuest ===

# addQuest CarolineFishing
 Now go to beach and catch fish.

    -> END

=== FinishQuest ===

# completeQuest CarolineFishing
Thank you for fish.

    -> END

=== DidntAccept ===

Oke.

    -> END
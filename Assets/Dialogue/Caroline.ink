EXTERNAL addQuest(questName)
# speaker Caroline
VAR completable_carolinefishing = false
VAR completed_chipstrawberryplanting = false

Oh, hey Ethan! What a surprise! What brings you here?

+ "Ok."
    -> StartQuest
+ "No."
    -> DidntAccept
+ {completable_carolinefishing} "Here."
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
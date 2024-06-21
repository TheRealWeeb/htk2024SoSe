EXTERNAL addQuest(questName)
# speaker Caroline
VAR finished_carolinefishing = false

Give Fish, four fish.

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
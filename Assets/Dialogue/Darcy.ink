EXTERNAL addQuest(questName)
# speaker: Darcy
VAR completable_darcyapplepie = false


Give apple, three apple.

+ "Ok."
    -> StartQuest
+ "No."
    -> DidntAccept
+ {completable_darcyapplepie} "Here."
    -> FinishQuest

=== StartQuest ===

# addQuest DarcyApplePie
 Now go shake apple tree.

    -> END

=== FinishQuest ===

# completeQuest DarcyApplePie
    Thank you for apple.

    -> END

=== DidntAccept ===

Oke.

    -> END


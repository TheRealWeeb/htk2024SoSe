EXTERNAL addQuest(questName)

Mayor Kato: Hey Ethan! How are you doing today? 

+ "I'm doing great!"
    -> TellProblem
+ "Didn't sleep well last night..."
    -> TellProblemBad

=== TellProblem ===

Mayor Kato: That's very nice to hear Ethan! Unfortunately I don't have great news for you. It's about Nosh-Up.

+ "Oh no, did something happen?"
    -> ContinueProblem

=== TellProblemBad ===

Mayor Kato: Oh, thats not great to hear. Unfortunately, I don't have great news for you... it's about Nosh-Up.

+ "What happened?"
    -> ContinueProblem

=== ContinueProblem ===

Mayor Kato: Our people didn't have enough time to prepare for Nosh-Up and will end up not bringing their favourite dishes to the table. Could you help them with their remaining preparations, so that everyone can enjoy Nosh-Up like we always did?

+ "Sure thing!"
    -> StartHelping
+ "Not interested."
    -> END

=== StartHelping ===

Mayor Kato: Thank you so much, Ethan! You could start by helping Chip out. He is just around the corner in front of his parents' house.

-> END
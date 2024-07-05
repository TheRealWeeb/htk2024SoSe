EXTERNAL addQuest(questName)
#speaker: MayorKato
VAR finished_ChipStrawberry = false


Hey Ethan! How are you doing today?

+ "I'm doing great!"
    -> TellingProblem
+ "Didn't sleep well last night..."
    -> TellingProblemBad


=== TellingProblem ===

That's very nice to hear Ethan! Unfortunately I don't have great news for you. It's about Nosh-Up.

+ "Oh no, did something happen?"
    -> ContinuingProblem
+ "Nosh-Up? What's that?"
    -> ExplainingNoshUp


=== TellingProblemBad ===

Oh, thats not great to hear. Unfortunately, I don't have great news for you... it's about Nosh-Up.

+ "What happened?"
    -> ContinuingProblem
+ "Nosh-Up? What's that?"
    -> ExplainingNoshUp


=== ContinuingProblem ===

Our people didn't have enough time to prepare for Nosh-Up and will end up not bringing their favourite dishes to the table. Could you help them with their remaining preparations, so that everyone can enjoy Nosh-Up like we always did?

+ "Sure thing!"
    -> StartHelping
+ "I'm sorry, but I'm not interested."
    -> DoNotHelp


=== ExplainingNoshUp ===

Don't you remember? It's our yearly meal we enjoy together as one village since we found you! Everyone brings their favourite dishes to the table and we enjoy the festivities that come with it!

+ "Ohh alright, now I remember again!"
    -> ContinuingProblem


=== StartHelping ===
 #addQuest ChipStrawberry

Thank you so much, Ethan! You could start by helping Chip out. He is just around the corner of his parents' house. Their home is located at the end of the pathway.

-> END


=== DoNotHelp ===

That's alright, I know that you have your own things to worry about as well.

-> END
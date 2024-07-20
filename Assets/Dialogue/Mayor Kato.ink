EXTERNAL addQuest(questName)
#speaker: MayorKato
VAR completable_chipstart = false
VAR completed_chipstart = false
VAR completed_chipstrawberrywatering = false

{
    - completed_chipstrawberrywatering == true:
        -> ThankYouForHelping
    - completable_chipstart == true:
        -> AcceptedQuest
    - completable_chipstart == false && completed_chipstart == false:
        -> NotAcceptedQuest
    - completed_chipstart == true:
        -> StartedHelpingChip
}


=== NotAcceptedQuest ===

Hey Ethan! How are you doing today?

+ I'm doing great!
    -> TellingProblem
+ Didn't sleep well last night...
    -> TellingProblemBad


=== AcceptedQuest ===

Remember to check on Chip, he had a problem regarding Nosh-Up!
    -> END


=== StartedHelpingChip ===

Thank you for helping Chip out, Ethan!
    -> END


=== TellingProblem ===

That's very nice to hear Ethan! Unfortunately I don't have great news for you. It's about Nosh-Up.

+ Oh no, did something happen?
    -> ContinuingProblem
+ Nosh-Up? What's that?
    -> ExplainingNoshUp


=== TellingProblemBad ===

Oh, thats not great to hear. Unfortunately, I don't have great news for you... it's about Nosh-Up.

+ What happened?
    -> ContinuingProblem
+ Nosh-Up? What's that?
    -> ExplainingNoshUp


=== ContinuingProblem ===

Our people didn't have enough time to prepare for Nosh-Up and will end up not bringing their favourite dishes to the table. Could you help them with their remaining preparations, so that everyone can enjoy Nosh-Up like we always did?

+ Sure thing!
    -> StartHelping
+ I'm sorry, but I'm not interested.
    -> DoNotHelp


=== ExplainingNoshUp ===

Don't you remember? It's our yearly meal we enjoy together as one village since we found you! Everyone brings their favourite dishes to the table and we enjoy the festivities that come with it!

+ Ohh alright, now I remember again!
    -> ContinuingProblem


=== StartHelping ===

# completeQuest Introduction
# addQuest chipstart

Thank you so much, Ethan! You could start by helping Chip out. He is just around the corner of his parents' house. Their home is located at the end of the pathway.
    -> END


=== DoNotHelp ===

That's alright, I know that you have your own things to worry about as well.
    -> END


=== ThankYouForHelping ===

Hey Ethan! Thank you for helping us out, it means a lot to us!
    -> END
EXTERNAL addQuest(questName)
# speaker: Chip
VAR completable_chipstart
VAR completed_chipstart
VAR completable_chipstrawberryplanting


Hey Ethan! How can I help you?

+ {completable_chipstart} Mayor Kato told me that you have a problem.
    -> TellingProblem
+ Just wanted to check on you.
    -> TellingMood



=== TellingProblem ===

Yes, that's right! It's about my favourite dish. You know, I want to bring a strawberry pie to Nosh-Up, yet I can't cultivate any strawberries in my garden. No matter how hard I try, they always turn out rotten.

+ Alright, how can I help?
    -> HelpOut
+ I'm sorry, but I don't have time for that...
    -> DoNotHelpOut


=== TellingMood ===

That's nice of you, thank you!
    -> END
    

=== HelpOut ===

# addQuest ChipStrawberryPlanting
# completeQuest ChipStart
# addItem ChipStart
Thank you so much, Ethan! Here, take those strawberry seeds. I don't think my garden is 'clean' enough to grow strawberries, but I bet yours is! I'll wait for you in front of your garden, we can continue talking there!

+ Alright, see you there!
    -> HelpOutTwo


=== DoNotHelpOut ===

That's alright! But if you do have time, please come by, it's very important.

+ Will do!
    -> END


=== HelpOutTwo ===

See you there!
    -> END
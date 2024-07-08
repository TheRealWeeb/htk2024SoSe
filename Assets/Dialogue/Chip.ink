EXTERNAL addQuest(questName)
# speaker: Chip
VAR completable_chipstart = false
VAR completed_chipstart = false
VAR completable_chipstrawberrytalk = false
VAR completed_chipstrawberrytalk = false
VAR completable_chipstrawberryplanting = false
VAR completed_chipstrawberryplanting = false
VAR completable_chipstrawberrywatering = false
VAR completed_chipstrawberrywatering = false
VAR completable_carolinetalk = false

{
    - completed_chipstart == true && completable_chipstrawberrytalk == true:
        -> StartPlanting
    - completable_chipstart == true && completed_chipstart == false:
        -> StartQuest
    - completable_chipstrawberryplanting == true && completed_chipstrawberryplanting == false:
        -> TellToWater
    - completable_chipstrawberrywatering == true && completed_chipstrawberrywatering == false:
        -> TellWait
    - completed_chipstrawberrytalk == true:
        -> ReminderPlanting
    - completable_carolinetalk == true:
        -> ThankingForHelp
}

// ChipStart Quest

=== StartQuest ===

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

# addQuest ChipStrawberryTalk
# completeQuest ChipStart
Thank you so much, Ethan! I don't think my garden is 'clean' enough to grow strawberries, but I bet yours is! I'll wait for you in front of your garden, we can continue talking there!

+ Alright, see you there!
    -> HelpOutTwo


=== HelpOutTwo ===

See you there!
    -> END


=== DoNotHelpOut ===

That's alright! But if you do have time, please come by, it's very important.

+ Will do!
    -> END


// ChipStrawberryTalk Quest

=== StartPlanting ===

# addQuest chipstrawberryplanting
# completeQuest chipstrawberrytalk
# addItem chipstrawberrytalk
Here, take those strawberry seeds, Ethan! Now you have to plant those strawberries and after that, come and talk to me again!
    -> END


// ChipStrawberryPlanting

=== TellToWater ===

# completeQuest chipstrawberryplanting
# addQuest chipstrawberrywatering
Perfect, Ethan! Now you have to get your watering can and start watering them!
    -> END


=== ReminderPlanting ===

Just plant the strawberries in your garden!
    -> END


=== TellWait ===

# completeQuest chipstrawberrywatering

Thank you again for your help, Ethan! Remember to water them tomorrow to be able to harvest them on the day of Nosh-Up!

    + I'll try to remember that!
        -> OneMoreThing


=== OneMoreThing ===

Alright! Oh, one more thing! I've heard that Caroline needs help with something. Maybe you can help her out too?

    + Sure, do you know where she currently is?
        -> HelpCaroline
    + I can do that when I find the time for it.
        -> DontHelpCaroline


=== HelpCaroline ===

# addQuest CarolineTalk
Yes! She is at her house, it's between my house and the horse carriage!
    -> END


=== DontHelpCaroline ===

# addQuest CarolineTalk
No problem, I know that you may have your own things to take care of first. If you find the time for it, she currently is in her house. It's the one between my house and the horse carriage.
    -> END


=== ThankingForHelp ===

Thank you again for helping me! Remember to water them tomorrow to be able to harvest then on the day of Nosh-Up!
    -> END







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
VAR completable_carolinestart = false
VAR completed_gotobed = false
VAR completable_chiptalktwo = false
VAR completed_chiptalktwo = false
VAR completable_chiptalkthree = false
VAR completed_gotobedtwo = false
VAR completable_chipstrawberrywateringtwo = false


{
    - completed_chipstrawberrywateringtwo == true:
        -> SeeYouTomorrow
    - completable_chipstrawberrywateringtwo == true:
        -> ThanksForWateringAgain
    - completed_chiptalktwo == true:
        -> ReminderWateringTwo
    - completed_gotobedtwo == true && completable_chiptalkthree == true:
        -> HarvestingStrawberry
    - completed_gotobed == true && completable_chiptalktwo == true:
        -> WateringNextDay
    - completed_chipstart == true && completable_chipstrawberrytalk == true:
        -> StartPlanting
    - completable_chipstrawberryplanting == true && completed_chipstrawberryplanting == false:
        -> TellToWater
    - completable_chipstrawberrywatering == true && completed_chipstrawberrywatering == false:
        -> TellWait
    - completed_chipstrawberryplanting == true:
        -> ReminderWatering
    - completed_chipstrawberrywatering == true:
        -> ThankingForHelp
    - completed_chipstrawberrytalk == true:
        -> ReminderPlanting
    - completed_chipstart == false:
        -> StartQuest
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
# teleport ChipStart

Thank you so much, Ethan! I don't think my garden is 'clean' enough to grow strawberries, but I bet yours is! I'll wait for you in front of your garden, we can continue talking there!

    -> END


=== DoNotHelpOut ===

That's alright! But if you do have time, please come by, it's very important.

+ Will do!
    -> END


// ChipStrawberryTalk Quest

=== StartPlanting ===

# addQuest ChipStrawberryPlanting
# completeQuest ChipStrawberryTalk

Here, take those strawberry seeds, Ethan! Now you have to plant those strawberries and after that, come and talk to me again!

    -> END


// ChipStrawberryPlanting

=== TellToWater ===

# addQuest ChipStrawberryWatering
# completeQuest ChipStrawberryPlanting

Perfect, Ethan! Now you have to get your watering can and start watering them!

    -> END


=== ReminderPlanting ===

Just plant the strawberries in your garden!

    -> END


=== ReminderWatering ===
Just water the strawberries in your garden!

    -> END


=== TellWait ===

# completeQuest ChipStrawberryWatering

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

# addQuest CarolineStart
# addQuest GoToBed

Yes! She is at her house, it's between my house and the horse carriage!

    -> END


=== DontHelpCaroline ===

# addQuest CarolineStart
# addQuest GoToBed

No problem, I know that you may have your own things to take care of first. If you find the time for it, she currently is in her house. It's the one between my house and the horse carriage.

    -> END


=== ThankingForHelp ===

Thank you again for helping me! Remember to water them tomorrow to be able to harvest them on the day of Nosh-Up!

    -> END


=== WateringNextDay ===

Hey Ethan, thank you again for watering the strawberries yesterday! Don't forget to water them today to be able to harvest them tomorrow!

    + I will do that!
        -> Darcy


=== Darcy ===

I think that Darcy needs help with something, because she looked worried this morning. Maybe you could go and check on her.

    + Sure thing!
        -> HelpDarcy
    + Maybe later.
        -> DontHelpDarcy


=== HelpDarcy ===

# completeQuest ChipTalkTwo
# addQuest ChipStrawberryWateringTwo
# addQuest DarcyTalk

Thank you! Darcy is currently next to the horse carriage.

    -> END


=== DontHelpDarcy ===

# completeQuest ChipTalkTwo
# addQuest ChipStrawberryWateringTwo
# addQuest DarcyTalk

That's alright! If you have time, go check on them. Darcy is currently next to the horse carriage.

    -> END


=== HarvestingStrawberry ===

Thank you Ethan for helping me with those strawberries! I'm very happy that they turned out great. Could you harvest them and bring them to me please?

    + Yes, I can do that!
        -> ThankingForHarvesting
    + Maybe later.
        -> MaybeLater


=== MaybeLater ===

That's oke, just don't forget them!
    -> END


=== ThankingForHarvesting ===

# completeQuest ChipTalkThree
# addQuest ChipStrawberryWateringTwo

Great! I'm looking forward to this year's Nosh-Up, it's gonna be fun! And one more thing, Mayor Kato was looking for you earlier, he told me that he'll be waiting for you at the big table!
    -> END


=== ReminderWateringTwo ===

Don't forget to water the strawberries today, Ethan!
    -> END


=== ThanksForWateringAgain ===

# completeQuest ChipStrawberryWateringTwo

Thank you so much, Ethan! I'll see you tomorrow for the harvest!
    -> END


=== SeeYouTomorrow ===

See you tomorrow, Ethan!
    -> END
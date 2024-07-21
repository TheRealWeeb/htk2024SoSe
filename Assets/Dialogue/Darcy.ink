EXTERNAL addQuest(questName)
# speaker: Darcy
VAR completable_darcyapplepie = false
VAR completable_darcytalk = false
VAR completed_darcytalk = false
VAR completed_darcyapplepie = false
VAR completable_getdarcy = false
VAR completed_getdarcy = false

{
    - completed_getdarcy == true:
        -> HappyForNoshUp
    - completable_getdarcy == true:
        -> FirstDialogue
    - completed_darcyapplepie == true:
        -> ReminderCaroline
    - completed_darcytalk == true:
        -> FirstDialogue
    - completed_darcytalk == false:
        -> FirstDialogue
}

=== FirstDialogue ===

Hello dear, how can I help you?

    + {completable_getdarcy} Nosh-Up is about to start!
        -> GetDarcy
    + {completable_darcyapplepie} I got the apples for your apple pie!
        -> ContinueQuest
    + {completable_darcytalk} I've heard from Chip that you are worried about something.
        -> TellingWorries
    + Just wanted to check on you.
        -> CheckDarcy


=== TellingWorries ===

Oh, did he notice that? Well, what can I say, I've gotten to old to make my favourite dish for Nosh-Up, my beloved apple pie, on my own.

    + Can I help you with that?
        -> OfferHelp
    + I can help you later if you want!
        -> HelpLater


=== CheckDarcy ===

That's so sweet of you, dear! Old Darcy is doing just fine.

    -> END


=== OfferHelp ===

That would be great! I've witnessed Nosh-Up and its beauty for multiple centuries, it would make me very sad to not be able to bring my favourite dish to this year's Nosh-Up.

    -> GetInfo


=== HelpLater ===

Oh dear, that would be fantastic! I'll be here if you find the time for an old lady like me.

    -> END


=== GetInfo ===

For my apple pie I need three apples in total. To get those apples, could you shake the apple tree next to my house? My house is right in front of your house.

    + Of course, I can do that!
        -> StartQuest
    + I can do that, when I find the time for it.
        -> StartQuestLater


=== StartQuest ===

# completeQuest DarcyTalk
# addQuest DarcyApplePie

Thank you, dear. Old Darcy will be waiting for you here.

    -> END


=== StartQuestLater ===

Don't worry, dear. Do your things first before helping me out. If you find the time for my case, just come by.

    -> END


=== ContinueQuest ===

# completeQuest DarcyApplePie
# addQuest HelpFromCaroline

That's great, dear! But I'm sorry to tell you that I'm not capable of making the apple pie, I'm too old for this... But I know someone who might be able to make this apple pie. Here, take those apples and go to Caroline, she can help us out!

    -> END


=== ReminderCaroline ===

Hello dear, I hope Caroline will be able to make the apple pie before Nosh-Up starts...

    -> END


=== GetDarcy ===

# completeQuest GetDarcy
# teleport GetDarcy

Is that so? Well, I'll be on my way then!
    -> END


=== HappyForNoshUp ===

Oh dear, I'm so happy to be able to witness another Nosh-Up!
    -> END
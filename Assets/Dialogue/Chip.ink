#speaker: Chip


Hey Ethan! How can I help you?

+ "Mayor Kato told me that you have a problem."
    -> TellingProblem
+ "Just wanted to check on you."
    -> TellingMood
+ "Never mind."
    -> END


=== TellingProblem ===

Yes, that's right! It's about my favourite dish. You know, I want to bring a strawberry pie to Nosh-Up, yet I can't cultivate any strawberries in my garden. No matter how hard I try, they always turn out rotten.

+ "Alright, how can I help?"
    -> HelpOut
+ "I'm sorry, but I don't have time for that..."
    -> DoNotHelpOut


=== TellingMood ===

I feel kinda stressed and sad, because I can't seem to grow any strawberries in my garden...

+ "Why do you want strawberries?"
    -> WhyStrawberry
+ "I'm sorry to hear that, good luck with your strawberries, fingers crossed!
    -> END
    

=== HelpOut ===

Thank you so much, Ethan! Here, take those strawberry seeds. I don't think my garden is 'clean' enough to grow strawberries, but I bet yours is! I'll wait for you in front of your garden, we can continue talking there!

+ "Alright, see you there!"
    -> END


=== DoNotHelpOut ===

That's alright! But if you do have time, please come by, it's very important.

+ "Will do!"
    -> END


=== WhyStrawberry ===

I need those strawberries for my favourite dish that I want to bring to Nosh-Up. I want to make a strawberry pie, yet I can't manage to cultivate any in my garden. Could you help me out?

+ "Sure, just tell me what I need to do!"
    -> HelpOut
+ "I'm sorry, but I don't have time for that..."
    -> DoNotHelpOut
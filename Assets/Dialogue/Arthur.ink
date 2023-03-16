INCLUDE Globals.Ink

-> main

=== main ===
#speaker: Arthur
A sillhouette in the dark corner of the room. A creature hunches over a small table.
    +Approach

-All I see is a big hat and what looks from afar to be big dreadlocks coming from within. The dreadlocks are firmly gripping the darkened body of the creature that sits before you. The humanoid holds its face between palms, seemingly hiding it.
    +"Sir, do you have your coins on you?"
        -> nice001
    +I stand before him silently, breathing heavily and twisting my face in an angry stare.
        -> beaweirdo

=== beaweirdo ===
The creature wails. It's discomforting, to say the least.
    +"Sir, I will need to see that you have coins and are adequate to finish your journey."
        -> nice001
    +"Coins. Now." I slam my fist on the table, just hard enough to make an impression.
        -> mean001
        
=== nice001 ===
He finally looks up at me. Dried-up skin and milky white eyes that sparkle at me in what I can only categorize as a sadness that is almost aggressive in its imposition.

"Hello? Can you hear me?"
    +"What game are you playing? Do you have any coins at all?"
    -> showscoin
    +"Don't be stupid. Show me that you have coins or you're gone."
    -> showscoin

=== mean001 ===
This startles the creature. It shrieks, emerges from its darkened frame and allows me my first good look at its face. Milky white eyes, widened in frozen shock.

Old Man:

"Please, take pity on this poor fool." Now, his hands rise up once again in an attempt of protecting the already beaten up face.
    +"Sir, don't make this harder than it has to be."
        -> showscoin
    +"I will not say it again."
        -> showscoin
    
=== showscoin ===
The man doesn't say anything, he merely starts bending over towards his grummy sock, sticks his fingers in and fiddles for a second. His quiet moans echo across the pits of your stomach. Sickening.

He brings one hand up.

"Here it is." In his dirty open palm, he shows you a single gold coin.
    +"I suppose you get to stay in the boat for now."
        -> yougettostay
    +"It's a long, long way down."
        -> yougettostay
        
=== yougettostay ===
Will: "Look at him, he's pathetic. He'll get his coin stolen in no time. Wanna bet how long?"
    +"Hope those dreads can protect you."
        ->whatisthisplace
    +I chuckle and decide to come back in an hour to throw him out.
        ->whatisthisplace

=== whatisthisplace ===
"Sir?" He raises his eyes to me, just enough for me to catch a glimmer of the striking green tint in the eyes. Your stomach rolls over. "Would you mind telling me where I am?"

Will: "Shit, he don't even know what's up. Ain't it just like you to make a living off giving the good old news to these pathetic fools."
    +"This is Stygian Crossing. The cruise that you never leave behind."
        -> stygianintro
    +"You're dead, loser. Get over it."
        -> stygianintro

=== stygianintro ===
Snivels. Slowly removes the hat to reveal the true nature of those strange dreadlocks. Dark green, spotted, slimy. I can clearly see the cracks they left in the back of the skull from when they burst out of it. Sticky blood drying around the roots.

He scratches the top of his bald head. Mutters something under his breath.

"What?" His eyes roll up once more. "Sir... Please. I have to go see my daughter. Penelope. Have you seen her? I need to find her. I lost her..."
    +"I doubt you'll find her here, old man."
        -> idoubtit
    +"This place is only for sad old fools like you."
        -> idoubtit

=== idoubtit ===
"You might be right... I swear I've tried, but it seems impossible. I've tried for so long, but my thoughts keep getting more confusing." He rubs his temples. "You can't imagine the pain..."
    +"I suppose death is a pain, just like any other. It doesn't have to be so complicated."
        ->deathisbenign
    +"It should hurt, you piece of shit."
        ->itshouldhurt
        
=== deathisbenign ===
"Nothing can be worse than this." He touches the back of his skull, strokes the dreadlocks carefully. "I disagree... If this is death... It's never-ending. It's badly written. Where is the peace they always spoke of? Where's the silence?"
    +"No rest for the wicked."
        ->wicked
    +"Not here. The ship always bustles with information and whatever other nonsense that echoes through your head. You might as well get used to it."
        -> getusedtoit

=== itshouldhurt ===
"I suppose I deserve that. They all deserved more. When can I say I've paid for my sins?" He moves forward and grips my shirt collar."
    +"Behave yourself!" I gently remove his shriveled hand from me.
        -> behave
    +Don't touch me." I pull away aggressively.
        -> behave

=== wicked ===
"I have so many regrets, sir. All I wanted in the world was to fix it, but... I couldn't... She didn't let me. I told her I was going to end it but she... She cursed me." He starts crying again.

Will:

"All this crying makes me wanna lock him up in a bathroom somewhere."
    +"Your daughter cursed you?"
        ->askabouther
    +"You can't really fix much anymore."
        ->voices

=== getusedtoit ===
Shrivels. "But the voices... The voices, they are so loud. They mock me. I can't hear myself in the middle of them. She... She cursed me... There can be no other explanation..." He starts mumbling, more to himself than at me. Has this silent conversation with whatever voice is responding in his head.
    +"Your daughter cursed you?"
        ->askabouther
    +"What voices do you hear?"
        ->voices

=== behave ===
Straightens himself. "I'm sorry. I didn't mean to... I never really understood people. Even when she... When she cursed me... I still can't come to grips on why she would do such a thing."
    +"Your daughter cursed you?"
        ->askabouther
    +"What voices do you hear?"
        ->voices

=== askabouther ===
"No... Not her. She... She was just a baby. No..." His dreads unwrap his body. Four dark tentacles open to me. His monstrous figure rises. "Margaret... She knew about everything. She hates me. Please, don't tell her I'm here..."
    +"Who's Margaret?"
        ->margaret

=== voices ===
"The voices, they don't stop... They started speaking when these appeared..." His dreads unwrap his body. Four dark tentacles open to me. "They just keep getting louder and louder. I can't seem to make them be quiet for even a second. Her voice is the loudest. Margaret..."
    +"Who's Margaret?"
        ->margaret

=== margaret ===
""Margaret... She.... She took everything away from me." He folds over the table once more, crashes down moaning."
    +"She can't hurt you anymore."
        ->END
    +"I don't think that matters."
        ->END

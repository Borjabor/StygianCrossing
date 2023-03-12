INCLUDE Globals.ink

-> main

=== main === 
#speaker:LampGuy
In our dialogue system, we can add Rich Text Tags to change <color=\#005500>color</color> or effect, like <b>BOLD</b> or <i>italic</i> text, so we can add emphasis on specific parts of the dialogue.
+ <color=\#9A330B>That's cool!</color>
        -> Advance
        
=== Advance ===
And as you also noticed, we added some flair by making our dialogues type themselves out at a constant (editable) speed. As long as its contents are being filled, the options and "continue" button will be hidden from the player. If they so wish, they may click the little <color=\#9A330B>arrow</color> below to finish the text instantly if they so wish (so impatient). I'll add more random words in here just so you have time to understand what's going on, and test it out without missing any other possible important bits I'll talk about. Text dialogue, blah blah blah, hello my darling, hello my honey, hello my ragtime gaaaaaallll!! Ok, I think this should be enough, let's move on? 

Ok. These are the changes for now. Thanks for listening (reading, actually) to my TED talk.

~ text_color = true

-> END

    
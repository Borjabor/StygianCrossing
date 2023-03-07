-> main

=== main === 
Whch Pokemon do you choose?
    + [Charmander]
        -> charmander("Charmander")
    + [Bulbasaur]
        -> notChosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")
        
=== chosen(Pokemon) ===
You chose {Pokemon}!
-> END

=== notChosen(Pokemon) ===
Yoiu did not choose {Pokemon}
-> END

=== charmander(Pokemon) ===
Are you sure?
    *Yes
        -> END
    *No
        -> END

    
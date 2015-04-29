# ToyCommander

--- Aaron
1) Automatically choose level
2) Randomly choose team rather than let player choose
3) Team score fixing
4) Add SFX to powerups
5) Powerups need to rotate in levels
6) Divide Y component of player spawn locations by 3 to fix vehicles sticking in floor upon spawn

--- Jeremy
1) Clamp movement for first half-second after respawned
2) Add a missile weapon with sound effect
3) Add tracer bullets to machine gun - bullet prefab needs instantiation and refinement
6) Halos over network

--- Jay
1) Fix Fireplace Mantle, Solo Cups, Bookcase
2) Put lifespan on bullet holes

--- respawn
1) Respawn locations
2) Ammo bar and values on UI dont reset upon respawn until first shot is fired in new life. 

the truck is able to get stuck in too many things, not sure why im guessing its manily that front gaud rail and the varied heighs of its windsheild and such, perhaps if the model had a canopy and the gaurd rail shrank it would fix the issues

tank still pulls to the right when moving forward

reloading and ammo:
the reload sound doesnt play when the 32 clip runs out but it does when the ammo count is 0/0, also it loops the reload sound until more ammo is gotten

ammo powerup: if a player collides with the ammo powerup when they havent fired a single shot on that life, an exception is thrown and the ammo box fails to reinstantiate for the rest of the game.  this does not occur with the health powerup

upon running out of ammo the ammo values say 0/32 leading me to believe i still have 32 shots left but actually empty, then the reloading sound looped forever

interesting bug: you can use the living room lamp bases as ramps and if you hit the wall just right you can then drive up the walls (with directional limits) and not fall off due to gravity

Maybe have and auto-upright mechanism in place for upside down cars

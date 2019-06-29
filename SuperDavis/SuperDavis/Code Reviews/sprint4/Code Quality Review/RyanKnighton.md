# Ryan Knighton code quality review for sprint 4

1. Ryan Knighton
2. 6/28/19
3. Sprint 4
4. DavisBlockCollisionHandler.cs
5. Jason Xu
6. 15 minutes
7. Specific Comments - Some code smells that I was looking for in particular are classes with too much code, similar looking code and unused or redundant variables.  After reviewing the code I can see that the class is somewhat long (around 120 lines of code).  The class does have some repeating/similiar code but I think that is just the nature of the beast with this game/file.  The variables have a clear naming convention that makes it easy to know what the vairable is used for.


8. Hypothetical Change - A change that might make this file smaller and more compact would be to use switch cases instead of all the nested if/else if statements.  I think nested switch statements would make the file more cpompact and concise.  I can see Jason used switch statements to see what side the collision was happeningon and that is great, but then it seems like the complexity of the file jumps with all the nested if/else statements.  Again, this just might be the nature of the beast but maybe we can reduce the complexity in fututre sprints.
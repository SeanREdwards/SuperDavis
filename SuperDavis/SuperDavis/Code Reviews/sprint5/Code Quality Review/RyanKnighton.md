# Ryan Knighton code quality review for sprint 5
1. Ryan Knighton
2. 7/12/19
3. Sprint 5
4. CollisionDetection.cs
5. Jason Xu
6. 20 minutes
7. Comments - Some code smells that I was looking for are repeating code, long classes and redundant/clear variable names.  At first glance I can see the file is a tad on the long side with some code being repeated with just a few minor canges.  There are also some complex nested loops that can make the readability suffer somewhat.  All varaibles have clear names as to what they are with no redundancy.
8. Hypothetical change - A hypothetical change that I might make would be to create a function that takes two parameters, the mover and the world.  Then we could use this fucntion to check the "movers" surrounding box and set the hitbox accordingly.  This would greatly reduce the file length and decrease complexity.  
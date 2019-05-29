1. Ryan Knighton
2. 5/29/2019
3. Sprint 2
4. DavisSpriteFacorty.cs
5. Jason Xu
6. 20 min
7. Some code smells that I was looking for in particular are duplicated code, classes with too much code and similar looking code sections that vary only a few percent.  I see some duplicated code with the coordinate lists.  The same varable "coordinateList" is in a lot of different methods with the only thing changing is the coordinates.  Might be better to make this data driven in future sprites.  This class does contain too much code as it would be difficult to put all the code on one screen.  There are asle code sections that only differ by a few percent throughout the code, mainly the coordiante lists.  
A hypothetical change would be to make a getCoordinates function that takes what we are trying to draw as a parameter to make the coordinates more data driven and would imporve overall code quality.  If we wanted to add a new sprite to be drawn, we would have to manually enter the coordinates as the files stands now.  This would become tedious if/when we have a lot of coordinates to update.
# PathFollowingAlgorithm
Windows Forms application for path following algorithm for ASCII maps

## Requirements
- .Net Framework 4.5.2
- Visual Studio
- Windows OS

## Application set up
1. Open solution in Visual studio
2. Build solution
3. Run application

## Application usage
1. Click button "Add ASCII map"
2. Select ASCII map (.txt) file from your drive
3. Click button "Process map"
4. Result is shown in "Path" and "Letters" textboxes

## Basic application (algorithm) functionality
Application input is ASCII map in format like this or similar:
```
  @---+
      B
K-----|--A
|     |  |
|  +--E  |
|  |     |
+--E--Ex C
   |     |
   +--F--+
```
Symbol "@" represents starting point of the path, symbol "x" represents end of the path. Idea is to follow path from start to end and during that save chars which are on the path and also save chars which are uppercase letters (letters are only saved at first run, if letter is crossed second time it shouldn't be saved). Symbol "+" represents change of direction, but uppercase letter can also change direction of the path.

For the given input, expected result should be:  
Path:```@---+B||E--+|E|+--F--+|C|||A--|-----K|||+--E--Ex```  
Letters:```BEEFCAKE```

## Unit Tests
Basic unit tests are included in solution. They can be run from Test Explorer in Visual Studio.

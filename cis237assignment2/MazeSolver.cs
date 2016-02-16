using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool solve;

        // declare and instatiate a Maze Printer
        mazePrinter printing = new mazePrinter();

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class.
            //It is possible that you will not need these class level ones and can get all of the work done
            //with the local ones. Regardless of how you implement it, here are the class level assignments.
            //Feel free to remove the class level variables and assignments if you determine that you don't need them.
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            this.solve = false;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            Console.WriteLine("Hello, we will begin traversing the maze!");

            mazeTraversal(maze, xStart, yStart);
            // Then Print out the solved maze ( if not done with the recursive method
            // Ask Teacher if we would print out the maze EVERY iteration?
            //mazePrinter(this.maze);

            //// call the ui class again to ask what to do
            //// or just print it out
            //console.writeline("press a button to exit?");

        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(char[,] maze, int x, int y)
        {
            // declare and instatiate a Maze Printer
            mazePrinter printOut = new mazePrinter();

            printOut.printing(maze);
            
            //Implement maze traversal recursive call
            
            // Establish the maze and where we are beginning as a point
            char current = this.maze[x, y];

            // Now do a bunch of cases on what would happen

            //First I should check if where I'm at is valid
            // otherwise I should drop an x
            // Assuming its not already a # (wall)
            if (current == '.')
            {
                this.maze[x, y] = 'X';
                printOut.printing(maze);
            }
            //If its a wall or an O we would exit the loop
            //if (current == '#' || current == 'X')
            //{
            //    //How to exit recursive loop?
            //    //exit;
            //}

            //basically I would first want to check if there is a '#' below, if not change pointer to there.
            if (maze[x, y - 1] == '.')
            {
                if (solve == false)
                {
                    // And shouldnt I make current = 'O' before I exit the loop
                    // by declaring it here?
                    this.maze[x, y] = 'X';
                    mazeTraversal(maze, x, y - 1);

                    if (solve == false)
                    {
                        this.maze[x, y - 1] = 'O';
                    }
                }

                // How should I be calling the multiple ones?
                if (maze[x, y - 1] == '.')
                {
                    // this one is if not left move forward
                    // How would I check if the forward one isnt a #
                    // Isnt that the one handled by the default in the recursive call?
                    this.maze[x, y] = 'X';
                    mazeTraversal(maze, x, y + 1);
                }

                if (maze[x, y - 1] == '.')
                {
                    // This one is to move right
                    // Assuming the previous idea of recalling the correct method works
                    this.maze[x, y] = 'X';
                    mazeTraversal(maze, x + 1, y);
                }

                if (maze[x, y - 1] == '.')
                {
                    // This one is to move back
                    // This would be a last resort
                    this.maze[x, y] = 'X';
                    mazeTraversal(maze, x - 1, y);
                }

                // This would be if we knew we were done
                if (maze.GetLength(0) - 1 == x)
                {
                    // This one woudl be assuiming there are no moves left
                    // Would use the damn printArray method to print it out
                    // and tell the user that we are done
                    Console.WriteLine(" Congrats! \n The maze is completed and your path is below");
                    this.maze[x - 1, y] = 'X';
                    Console.ReadLine();
                    printOut.printing(maze);
                }

                if (maze.GetLength(1) - 1 == y)
                {
                    Console.WriteLine(" Congrats! \n The maze is completed and your path is below");
                    this.maze[x, y - 1] = 'O';
                    printOut.printing(maze);
                    Console.ReadLine();

                }

                if (maze[0, y] == x)
                {
                    Console.WriteLine(" Congrats! \n The maze is completed and your path is below");
                    this.maze[x, y] = 'O';
                    printOut.printing(maze);
                    Console.ReadLine();
                }

                if (maze[x, 0] == y)
                {
                    Console.WriteLine(" Congrats! \n The maze is completed and your path is below");
                    this.maze[x, y] = 'O';
                    printOut.printing(maze);
                    Console.ReadLine();
                }
                //This is the end of the Maze recursive call to traverse the maze
            }
        }
    }
}

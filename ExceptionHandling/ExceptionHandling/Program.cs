namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Computer programs, if not coded properly or with the correct safeguards,
            // may throw what are called Runtime Exceptions.
            // These are errors that occur while the
            // program is running ("run time")

            // An exception is a type of computer error that occurs when a program is
            // trying to do something, but can't.
            // For example, we get an exception when we try an parse a sentence to an int

            // int.Parse("HELLO");

            // the above line will throw an exception because the program cannot convert
            // "HELLO" to an integer.

            // There are hundreds and hundreds of exceptions built into programming languages
            // and we can even create our own.

            // Here are some examples of exceptions and the multiple ways we can handle them.

            /**** Divide by Zero Exception ****/

            int i = 5;
            int j = 0;

            // If we run the following line, we will get a DivideByZeroException and the program will quit.
            // (uncomment the line and see for yourself)

            // Console.WriteLine(i / j);

            // There are a couple ways we can avoid this problem.
            // Using logic:

            if (j != 0)
            {
                Console.WriteLine(i / j);
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }

            // Using logic will work, but it may not always be the best choice for resolving the problem.
            // The other way to do this is to use a Try/Catch to "catch" the exception

            // A try/catch works in the following way. We place the code we want to run in the "try block"
            // If an exception is thrown in the "try block", then all remaining code in the try block will
            // be skipped, and the code in the "catch block" will execute instead.

            // If an exception is not thrown, then the code in the catch block will not execute.

            // Using the same "divide by zero" example:
            try
            {
                //if this throws an exception, we will go to the catch block 
                Console.WriteLine(i / j);
            }
            catch
            {
                // Execute our custom code when an exception is caught
                Console.WriteLine("Cannot divide by zero.");
            }

            // One of the better parts of using a try/catch instead of logic to prevent exceptions
            // is a try/catch can provide us with more information about the error.

            try
            {
                Console.WriteLine(i / j);
            }
            catch (Exception ex)
            {
                // The Exception class can provide us with many options to help us diagnose the issue
                // One of the most commonly used is ex.Message
                Console.WriteLine("Failed to divide by zero.");

                //ex.Message is a property that contains the error message. Very useful for logging!
                Console.WriteLine(ex.Message);
            }
            /***** Parsing Exception *****/
            // let's look at another example where we ask the user their age
            // we will also place this inside of a while loop so that we can execute the same code over
            // and over until a user enters a valid input.

            int userAge;
            bool validInput = false;

            // Ask the user for their age
            Console.Write("Enter your age: ");
            while (!validInput)
            {
                try
                {
                    // if the user does not enter an integer, the exception will throw.
                    userAge = int.Parse(Console.ReadLine());

                    // If a user enters a negative number
                    // we can throw our own exception because you can't be negative years old
                    // using "throw" we force the code to enter the catch block
                    // adding  "new Exception(customErrorMessage)" we can add our custom error message
                    if (userAge < 0)
                        throw new Exception("You can't be negative years old.");
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // If the user did not enter a valid age
                    Console.WriteLine("Invalid Input. Please re-enter age: ");
                }
            }
            /****** TryParse ******/
            // Up until now, we have been using the Parse method to convert our string data to other
            // data types. However, as we have seen, Parse opens us up to potential unhandled exceptions,
            // which can cause problems in our programs.
            // A more used way of parsing that can reduce the chance of this is the TryParse() method.

            // TryParse actually returns a boolean value. If the parsing was successful, then the value of
            // "true" is returned. If the parsing failed, then "false" will be returned.
            // TryParse() takes two parameters, the first is the string to be parsed, the second is the variable that
            // will hold the parsed value.
            // Make sure to include the "out" keyword in the second parameter.

            Console.Write("Enter a number again to test the TryParse method: ");
            string input = Console.ReadLine();
            int userInt; // declare the int variable so it can be used in the TryParse method

            //                                  string       variable
            //                                     |            |
            //                                     |            |
            //                                     V            V
            bool parsingSuccessful = int.TryParse(input, out userInt);

            // If the parsing is successful, the variable "userInt" will contain the parsed value.
            if (parsingSuccessful)
                Console.WriteLine($"Hooray, {userInt} was parsed!");
            else
                Console.WriteLine($"Failed to parse {input} to an integer. Sad....");

            // TryParse is a safer way of parsing strings as well as the preferred method.
        }
    }
}

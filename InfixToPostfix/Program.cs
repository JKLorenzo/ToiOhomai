internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter infix notation: ");
        Conversion(Console.ReadLine());

        Console.ReadLine();
    }

    static void Conversion(string infixExpression)
    {
        Stack<char> stack = new Stack<char>();
        Queue<char> queue = new Queue<char>();

        // Push a left parenthesis '(' onto a stack. 
        stack.Push('(');
        // And append a right parenthesis ')' to the end of the infix expression. 
        infixExpression += ")";

        // While the stack is not empty
        while (stack.Count > 0)
        {
            // read infix expression from left to right
            char currentChar = infixExpression[0];

            if (currentChar >= '0' && currentChar <= '9')
            {
                // If the current character in infix is a digit, append it to postfix. 
                queue.Enqueue(currentChar);
            }
            else if (currentChar == '(')
            {
                // Push the current character onto the stack. 
                stack.Push(currentChar);
            }
            else if (IsOperator(currentChar))
            {
                char stackValue;
                bool IsEqualOrHigherPrecThanCurOp;
                do
                {
                    // Pop operators (if there are any) at the top of the stack
                    stackValue = stack.Pop();

                    // while they have equal or higher precedence than the current operator
                    IsEqualOrHigherPrecThanCurOp = IsOperator(stackValue) && OpPrecedence(currentChar, stackValue);

                    if (IsEqualOrHigherPrecThanCurOp)
                    {
                        // append the popped operators to postfix
                        queue.Enqueue(stackValue);
                    }
                    else
                    {
                        // Push the stack back
                        stack.Push(stackValue);
                    }
                } while (IsEqualOrHigherPrecThanCurOp);

                // Push the current character onto the stack. 
                stack.Push(currentChar);
            }
            else if (currentChar == ')')
            {
                // Pop operators from the top of the stack
                char stackValue = stack.Pop();

                // until a left parenthesis is at the top of the stack
                while (stackValue != '(')
                {
                    // append them to postfix
                    queue.Enqueue(stackValue);

                    // Pop operators from the top of the stack
                    stackValue = stack.Pop();
                }
            }

            // Remove the current char
            infixExpression = infixExpression.Substring(1);
        }

        // Display postfix
        while (queue.Count != 0)
        {
            Console.Write(queue.Dequeue());
        }
    }

    static bool IsOperator(char ch)
    {
        char[] operators = { '+', '-', '*', '/' };
        return operators.Contains(ch);
    }

    static bool OpPrecedence(char operator1, char operator2)
    {
        char[] highOpPrecedence = { '*', '/' };
        return !(highOpPrecedence.Contains(operator1) && !highOpPrecedence.Contains(operator2));
    }
}
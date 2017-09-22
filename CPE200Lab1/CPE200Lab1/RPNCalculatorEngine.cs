using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == null || str == "" )
            {
                return "E";
            }
            
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            int number = 0;
            int op = 0;

            
            foreach (string token in parts)
            {

                if (!isNumber(token) && !isOperator(token) && token != "") return "E";
                
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                    number++;
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    op++;
                    //firstOperand = rpnStack.Pop();

                    
                    if (op == number)
                    {
                        return "E";
                    }
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                    }
                    catch { return "E"; }
                    
                    result = calculate(token, firstOperand, secondOperand, 4);
                    
                    if (secondOperand == null || firstOperand == null)
                    {
                        return "E";
                    }
                    if (rpnStack == null)
                    {
                        return "E";
                    }

                    if (result is "E")
                    { 
                        return result;
                    }
                    
                    rpnStack.Push(result);
                    if (isOpera(token))
                    {
                        return "E";
                    }

                }

                          
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (number - 1 != op) return "E";
            if (rpnStack.Count == 0 || rpnStack.Count > 1) { return "E"; }
            result = rpnStack.Pop();
            if (result == "0") { return result; }
            else
            {
                if (op == 0) { return "E"; }
            }
            return result;
        }
    }
}

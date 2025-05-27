namespace Calculator.Domain;
public class Calculator
{
    public int Add(int x, int y) => x + y;
    public int Subtract(int x, int y) => x - y;
    public int Multiply(int x, int y) => x * y; 
    public int Divide(int x, int y)         
    {
        if (y == 0)
        {
            throw new DivideByZeroException("No se puede dividir por cero.");
        }
        return x / y;
    }
}
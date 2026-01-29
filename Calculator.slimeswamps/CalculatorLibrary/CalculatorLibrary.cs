using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            double radians = num1 * (Math.PI / 180);
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            if (op != "r" && op != "t" && op != "sin" && op != "cos" && op != "tan")
            {
                writer.WritePropertyName("Operand2");
                writer.WriteValue(num2);
            }
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    writer.WriteValue("Divide");
                    break;
                case "r":
                    result = Math.Sqrt(num1);
                    writer.WriteValue("Square root");
                    break;
                case "p":
                    result = Math.Pow(num1,num2);
                    writer.WriteValue("Power");
                    break;
                case "t":
                    result = num1 * 10;
                    writer.WriteValue("10x");
                    break;
                case "sin":
                    result = Math.Sin(radians);
                    writer.WriteValue("Sine");
                    break;
                case "cos":
                    result = Math.Cos(radians);
                    writer.WriteValue("Cosine");
                    break;
                case "tan":
                    result = Math.Tan(radians);
                    writer.WriteValue("Tangent");
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
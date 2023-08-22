var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    if(context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int firstNumber = 0, secondNumber = 0;
        string? operation = null;
        long? result = null;

        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            string firsNumberS = context.Request.Query["firstNumber"][0];
            if(string.IsNullOrEmpty(firsNumberS))
            {
                context.Response.StatusCode = 500;
                context.Response.WriteAsync
                ("Invalid Input for FirstNumber");
            }
            else
            {
                firstNumber = int.Parse(firsNumberS);
                context.Response.StatusCode = 200;
            }
        }

        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            string secondNumberS = context.Request.Query["secondNumber"][0];
            if (string.IsNullOrEmpty(secondNumberS))
            {
                context.Response.StatusCode = 500;
                context.Response.WriteAsync
                ("Invalid Input for SecondNumber");
            }
            else
            {
                secondNumber = int.Parse(secondNumberS);
                context.Response.StatusCode = 200;
            }
        }

        if (context.Request.Query.ContainsKey("operation"))
        {
            string operationS = context.Request.Query["operation"][0];
            operation = operationS.ToString();
            if (string.IsNullOrEmpty(operationS))
            {
                context.Response.StatusCode = 500;
                context.Response.WriteAsync
                ("Invalid Input for Operation");
            }
            else
            {
                if(operationS == "add")
                {
                    result = firstNumber + secondNumber;
                }
                else if(operationS == "subtract")
                {
                    result = firstNumber - secondNumber;
                }
                else if(operationS == "multiply")
                {
                    result = firstNumber * secondNumber;
                }
                else if(operationS == "divide")
                {
                    result = firstNumber / secondNumber;
                }
                else if(operationS == "mod")
                {
                    result = firstNumber % secondNumber;
                }
                else{
                    context.Response.StatusCode = 500;
                    context.Response.WriteAsync("Invalid Input for Operation");
                }
                context.Response.StatusCode = 200;
            }
        }
        if(result.HasValue)
        {
            await context.Response.WriteAsync(result.Value.ToString());
        }
    }
}) ;

app.Run();

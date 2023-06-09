﻿namespace Bridge;

// Each Concrete Implementation corresponds to a specific platform and
// implements the Implementation interface using that platform's API.
public class ConcreteImplementationB : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA: The result in platform B.\n";
    }
}
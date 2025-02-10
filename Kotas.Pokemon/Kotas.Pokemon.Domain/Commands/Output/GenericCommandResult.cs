﻿using Kotas.Pokemon.Infra.Common.Contracts;

namespace Kotas.Pokemon.Domain.Commands.Output;

public class GenericCommandResult : ICommandResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public virtual object Data { get; set; }

    public GenericCommandResult(bool success, string message, object data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}

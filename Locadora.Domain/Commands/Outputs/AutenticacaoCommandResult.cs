﻿using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Commands.Outputs
{
    public class AutenticacaoCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AutenticacaoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}

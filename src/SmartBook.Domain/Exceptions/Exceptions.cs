using System;

namespace SmartBook.Domain.Exceptions;

public class BusinessRuleException : Exception {
    public BusinessRuleException(string message) : base(message) { }
}

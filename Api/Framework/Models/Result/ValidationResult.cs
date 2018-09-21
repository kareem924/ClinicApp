using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Models.Result
{
    public class ValidationResult 
    {
        private readonly List<ValidationError> _erros;
        public bool IsValid => !_erros.Any();
          public bool IsExceptionMessage {get;set;}=false;
        public object ObjectModel { get; set; }
        public object EntityId {get;set;}
        public IEnumerable<ValidationError> Errors => _erros;
        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }
        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(string errorMessage, string errorMessageType)
        {
            _erros.Add(new ValidationError(errorMessage, errorMessageType));
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _erros.AddRange(result.Errors);

            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_erros.Contains(error))
                _erros.Remove(error);
            return this;
        }
        public ValidationResult Add(Exception ex){
             _erros.Add(new ValidationError(ex));
             IsExceptionMessage=true;
            return this;
        }
    }
}